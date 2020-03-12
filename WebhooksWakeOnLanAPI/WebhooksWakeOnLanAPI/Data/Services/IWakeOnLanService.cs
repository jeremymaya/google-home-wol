using System;
namespace WebhooksWakeOnLanAPI.Data.Services
{
    public interface IWakeOnLanService
    {
        void GenerateMagicPacket(Device device);
    }
}
