using System;

namespace GprsCommandsTeste
{
    
    public class TcDevices
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string UniqueId { get; set; }
        public string DeviceId { get; set; }
        public string Status { get; set; }
        public DateTime? LastUpdate { get; set; }
        public long PositionId { get; set; }
        public bool Disabled { get; set; }
        public override string ToString()
        {
            return string.Format("{0},{1}", Id, Name);
        }

    }   
    
    
}

