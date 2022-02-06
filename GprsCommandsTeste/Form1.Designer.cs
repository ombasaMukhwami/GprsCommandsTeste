namespace GprsCommandsTeste
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtimei = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtcommandText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboCommandType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.cboUrl = new System.Windows.Forms.ComboBox();
            this.txtformmattedcmd = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server Url";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Imei";
            // 
            // txtimei
            // 
            this.txtimei.Location = new System.Drawing.Point(110, 145);
            this.txtimei.Name = "txtimei";
            this.txtimei.Size = new System.Drawing.Size(312, 20);
            this.txtimei.TabIndex = 3;
            this.txtimei.Text = "865362041818814";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(110, 248);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 33);
            this.button1.TabIndex = 4;
            this.button1.Text = "&Send Command";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_ClickAsync);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(269, 248);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(153, 33);
            this.button2.TabIndex = 5;
            this.button2.Text = "&Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // txtcommandText
            // 
            this.txtcommandText.Location = new System.Drawing.Point(110, 196);
            this.txtcommandText.Name = "txtcommandText";
            this.txtcommandText.Size = new System.Drawing.Size(312, 20);
            this.txtcommandText.TabIndex = 6;
            this.txtcommandText.Text = "045501";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Command Value";
            // 
            // cboCommandType
            // 
            this.cboCommandType.FormattingEnabled = true;
            this.cboCommandType.Location = new System.Drawing.Point(110, 171);
            this.cboCommandType.Name = "cboCommandType";
            this.cboCommandType.Size = new System.Drawing.Size(312, 21);
            this.cboCommandType.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Command Type";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(110, 54);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(312, 20);
            this.txtUsername.TabIndex = 9;
            this.txtUsername.Text = "baraka";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Username";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Username";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(110, 79);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(312, 20);
            this.txtPassword.TabIndex = 11;
            this.txtPassword.Text = "baraka";
            // 
            // cboUrl
            // 
            this.cboUrl.FormattingEnabled = true;
            this.cboUrl.Items.AddRange(new object[] {
            "http://62.12.119.221:8082/api/",
            "http://localhost:8082/api/"});
            this.cboUrl.Location = new System.Drawing.Point(110, 27);
            this.cboUrl.Name = "cboUrl";
            this.cboUrl.Size = new System.Drawing.Size(312, 21);
            this.cboUrl.TabIndex = 13;
            // 
            // txtformmattedcmd
            // 
            this.txtformmattedcmd.Location = new System.Drawing.Point(110, 222);
            this.txtformmattedcmd.Name = "txtformmattedcmd";
            this.txtformmattedcmd.ReadOnly = true;
            this.txtformmattedcmd.Size = new System.Drawing.Size(312, 20);
            this.txtformmattedcmd.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(0, 226);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Formatted Command";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 288);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtformmattedcmd);
            this.Controls.Add(this.cboUrl);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboCommandType);
            this.Controls.Add(this.txtcommandText);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtimei);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test GPRS Commnads";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtimei;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtcommandText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboCommandType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ComboBox cboUrl;
        private System.Windows.Forms.TextBox txtformmattedcmd;
        private System.Windows.Forms.Label label7;
    }
}

