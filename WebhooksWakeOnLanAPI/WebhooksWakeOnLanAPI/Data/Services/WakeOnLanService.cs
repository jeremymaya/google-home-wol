using System;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace WebhooksWakeOnLanAPI.Data.Services
{
    public class WakeOnLanService : IWakeOnLanService
    {
        // Source: https://www.fluxbytes.com/csharp/wake-lan-wol-c/
        public void GenerateMagicPacket(Device device)
        {
            // Device MAC address
            string macAddress = device.MacAddress;
            // Remove any semicolons or minus characters present in MAC address
            macAddress = Regex.Replace(macAddress, "[-|:]", "");

            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
            {
                EnableBroadcast = true
            };

            int payloadIndex = 0;

            /* The magic packet is a broadcast frame containing anywhere within its payload 6 bytes of all 255 (FF FF FF FF FF FF in hexadecimal), followed by sixteen repetitions of the target computer's 48-bit MAC address, for a total of 102 bytes. */
            // Packet that will be broadcasted
            byte[] payload = new byte[1024];

            // Add 6 bytes with value 255 (FF) in our payload
            for (int i = 0; i < 6; i++)
            {
                payload[payloadIndex] = 255;
                payloadIndex++;
            }

            // Repeat the device MAC address sixteen times
            for (int j = 0; j < 16; j++)
            {
                for (int k = 0; k < macAddress.Length; k += 2)
                {
                    string s = macAddress.Substring(k, 2);
                    payload[payloadIndex] = byte.Parse(s, NumberStyles.HexNumber);
                    payloadIndex++;
                }
            }

            // Broadcast the packet
            sock.SendTo(payload, new IPEndPoint(IPAddress.Parse(device.SubnetMask), Convert.ToInt32(device.Port)));
            sock.Close(10000);
        }
    }
}