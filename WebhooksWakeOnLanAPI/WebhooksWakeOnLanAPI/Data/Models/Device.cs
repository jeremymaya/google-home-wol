using System;
namespace WebhooksWakeOnLanAPI.Data
{
    public class Device
    {
        public string MacAddress { get; set; }

        public string IpAddress { get; set; }

        public string SubnetMask { get; set; }

        public string Port { get; set; }
    }
}
