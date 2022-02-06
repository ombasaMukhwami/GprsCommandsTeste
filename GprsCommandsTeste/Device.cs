using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GprsCommandsTeste
{
    public class Device
    {
        public int id { get; set; }
        public int groupId { get; set; }
        public string name { get; set; }
        public string uniqueId { get; set; }
        public string status { get; set; }
        public DateTime lastUpdate { get; set; }
        public int positionId { get; set; }
        public IList<object> geofenceIds { get; set; }
        public object phone { get; set; }
        public object model { get; set; }
        public object contact { get; set; }
        public object category { get; set; }
        public bool disabled { get; set; }
    }
    public class Attributes
    {
        public int amount { get; set; }
    }

    public class Command
    {
        public int id { get; set; }
        public Attributes attributes { get; set; }
        public int deviceId { get; set; }
        public string type { get; set; }
        public bool textChannel { get; set; }
        public string description { get; set; }
        public string result { get; set; } = "500";
        public string formattedCommand { get; set; }
    }
}
