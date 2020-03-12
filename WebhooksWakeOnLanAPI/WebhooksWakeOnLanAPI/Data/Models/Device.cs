using System;
namespace WebhooksWakeOnLanAPI.Data
{
    public class Device
    {
        public string MacAdress { get; set; }

        public string IpAddress { get; set; }

        public string SubnetMask { get; set; }

        public string Port { get; set; }
    }
}
