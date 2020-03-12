using System;
using Microsoft.AspNetCore.Mvc;
using WebhooksWakeOnLanAPI.Data;
using WebhooksWakeOnLanAPI.Data.Services;

namespace WebhooksWakeOnLanAPI.Controllers
{
    [Route("api/[controller]")]

    public class WakeOnLanController : Controller
    {
        private readonly IWakeOnLanService _wakeOnLanService;

        public WakeOnLanController(IWakeOnLanService wakeOnLanService)
        {
            _wakeOnLanService = wakeOnLanService;
        }

        [HttpPost("[action]")]
        public IActionResult GenerateMagicPacket([FromBody]Device device)
        {
            if (device != null)
            {
                _wakeOnLanService.GenerateMagicPacket(device);
            }

            return Ok();
        }
    }
}

// {"MacAddress": "70-85-C2-72-C4-FA", "IpAddress": "192.168.1.17", "SubnetMask": "255.255.255.000", "Port": "4343"}
