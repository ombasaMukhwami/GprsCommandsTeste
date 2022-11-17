using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace GprsCommandsTeste
{
    public partial class Form1 : Form
    {
        public string TcUsername = ConfigurationManager.AppSettings["TcUsername"].ToString();
        public string TcPassword = ConfigurationManager.AppSettings["TcPassword"].ToString();


        public Form1()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void Button1_ClickAsync(object sender, EventArgs e)
        {
            txtformmattedcmd.Clear();
            TcUsername = txtUsername.Text;
            TcPassword = txtPassword.Text;
            if (string.IsNullOrWhiteSpace(txtimei.Text))
            {
                txtimei.SelectAll();
                txtimei.Focus();
                return;
            }
            //var lst = await GetAndCacheDevicesOLD();

            var imei = GetTraccarDeviceID(txtimei.Text, cboUrl.Text);
            var result = await SendGPRSCommandAsync(txtcommandText.Text.Trim(), cboUrl.Text, imei);
            txtformmattedcmd.Text = result.formattedCommand;
            MessageBox.Show(result.result,"Command Status",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        public Task<Command> SendGPRSCommandAsync(string commandText, string url, Device device)
        {

            string commandType = cboCommandType.Text;
            return Task.Run(async () =>
           {
               Command cmd = new Command();
               try
               {
                   string serilized = string.Empty;
                   switch (commandType)
                   {
                       case "Custom command":
                           var postData = new
                           {
                               id = 0,
                               deviceId = device.id,
                               description = commandType,
                               type = "custom",
                               attributes = new
                               {
                                   data = commandText
                               }
                           };
                           serilized = JsonConvert.SerializeObject(postData, Formatting.None);
                           break;
                       default:
                           var dev = new
                           {
                               id = 0,
                               deviceId = device.id,
                               description = "New",
                               type = commandType,
                               attributes = new 
                               {
                                   amount = commandText
                               }
                           };
                           serilized = JsonConvert.SerializeObject(dev, Formatting.None);
                           break;
                   }


                   string UrlStr = $"commands/send";
                   var byteArray = Encoding.ASCII.GetBytes(TcUsername + ":" + TcPassword);
                   using (var client = new HttpClient())
                   {
                       client.BaseAddress = new Uri(url);
                       client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                       client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                       client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                       var inputMessage = new HttpRequestMessage
                       {
                           Content = new StringContent(serilized, Encoding.UTF8, "application/json"),
                           Method = HttpMethod.Post,
                       };

                       inputMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                       var response = await client.PostAsync(UrlStr, inputMessage.Content);
                       string res = await response.Content.ReadAsStringAsync();                       
                       switch (response.StatusCode)
                       {
                           case HttpStatusCode.Accepted:
                               cmd = JsonConvert.DeserializeObject<Command>(res);
                               cmd.result = "The command has been received. It will be send when the device next reports "; //Command sent but queued. Perhaps the Device is offline.
                               cmd.formattedCommand = cmd.description;
                               break;
                           case HttpStatusCode.OK:
                               cmd = JsonConvert.DeserializeObject<Command>(res);
                               cmd.result = "Command Sent successfuly";
                               cmd.formattedCommand = cmd.description;
                               break;
                           case HttpStatusCode.BadRequest:
                               cmd.result = "Administrator permission required to access the resource"; //Could happen when the user doesn't have permission for the device
                               break;                           
                           case HttpStatusCode.Forbidden:
                               cmd.result = "This command is a reply from the device";
                               break;
                           case HttpStatusCode.NotAcceptable:
                               cmd.result = "wrong command format";
                               break;
                           case HttpStatusCode.MethodNotAllowed:
                               cmd.result = "The command is not supported";
                               break;
                       }

                   }
               }
               catch (Exception ex)
               {
                   cmd.result= ex.StackTrace;
               }
               return cmd;
           });
        }
        public string SendGPRSCommandToTracar(string commandText, string url, Device device)
        {
            string result = "";
            string _deviceId;
            Uri address = new Uri(url + "commands/send");
            HttpWebRequest request;
            //Data To Post
            var postData = new
            {
                id = 0,
                deviceId = device.id,
                description = "Custom Command",
                type = "custom",
                attributes = new
                {
                    data = commandText
                }
            };
            var data = Encoding.ASCII.GetBytes(postData.ToString());
            // Create and initialize the web request
            request = WebRequest.Create(address) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            request.UserAgent = "WebApp";
            request.KeepAlive = true;
            String encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(TcUsername + ":" + TcPassword));
            request.Headers.Add("Authorization", "Basic " + encoded);
            request.Timeout = 15000;
            var param = JsonConvert.SerializeObject(postData);
            byte[] byteArray = Encoding.UTF8.GetBytes(param);
            try
            {
                using (var writer = request.GetRequestStream())
                {
                    writer.Write(byteArray, 0, byteArray.Length);
                }
                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode == HttpStatusCode.Accepted)
                    {
                        result = "202"; //Command sent but queued. Perhaps the Device is offline.
                    }
                    else if (response.StatusCode == HttpStatusCode.OK)
                    {
                        result = "200"; //Command Sent successfuly
                    }
                    else if (response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        result = "400"; //Could happen when the user doesn't have permission for the device
                    }
                    else if (response.StatusCode == HttpStatusCode.NotAcceptable)
                    {
                        result = "406"; //wrong command/command failed
                    }

                    MessageBox.Show($"{result} {address.AbsolutePath} {address.AbsoluteUri} {address.Authority}");
                }
            }
            catch (WebException ex)
            {
                result = "501";
            }
            return result;
        }
        public Device GetTraccarDeviceID(string uniqueId, string url)
        {
            Device device = new Device();
            try
            {
                Uri address = new Uri(url + "devices?uniqueId=" + uniqueId);
                //Uri address = new Uri(url + "api/devices/130");
                HttpWebRequest request;
                StreamReader reader;
                StringBuilder sbSource;
                request = WebRequest.Create(address) as HttpWebRequest;
                request.KeepAlive = false;
                string encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(TcUsername + ":" + TcPassword));
                request.Headers.Add("Authorization", "Basic " + encoded);
                request.Timeout = 15 * 1000;
                // Get response
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (request.HaveResponse == true && response != null)
                    {
                        try
                        {
                            // Get the response stream
                            reader = new StreamReader(response.GetResponseStream());
                            // Read it into a StringBuilder
                            sbSource = new StringBuilder(reader.ReadToEnd());
                            var _device = JsonConvert.DeserializeObject<List<Device>>(sbSource.ToString());
                            device = _device.Where(d=>d.status.Equals("online", StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                            if (device == null)
                                device = _device.FirstOrDefault();
                            //convert to an xml stream
                            reader.Close();
                            reader.Dispose();
                        }
                        catch (WebException ex)
                        {
                            device = new Device();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                device = new Device();
            }
            return device;
        }
        private async Task<List<TcDevices>> GetAndCacheDevicesOLD()
        {
            List<TcDevices> lstOfTcDevices = new List<TcDevices>();
            try
            {
                string url = cboUrl.Text + "devices/";
                var byteArray = Encoding.ASCII.GetBytes(TcUsername + ":" + TcPassword);
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = await client.GetAsync(url);
                    HttpStatusCode statusCode = response.StatusCode;
                    switch (statusCode)
                    {
                        case HttpStatusCode.OK:
                            {
                                response.EnsureSuccessStatusCode();
                                string res = await response.Content.ReadAsStringAsync();
                                lstOfTcDevices = JsonConvert.DeserializeObject<List<TcDevices>>(res);
                            }
                            break;
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
            return lstOfTcDevices;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cboCommandType.Items.Add("Custom command");
            cboCommandType.Items.Add("queryFixedPointReportingTime");
            cboCommandType.Items.Add("setFixedPointReportingTime");
            cboCommandType.Items.Add("setReportingPeriod");
            cboCommandType.Items.Add("topUp");
            cboCommandType.Items.Add("setAccumulativeFlow");            
            cboCommandType.Items.Add("queryBalance");
            cboCommandType.Items.Add("switchOn");
            cboCommandType.Items.Add("switchOff");
            cboCommandType.Items.Add("queryReportFrequency");
            cboCommandType.SelectedIndex = 0;
            cboUrl.SelectedIndex = 0;
        }
    }
}
