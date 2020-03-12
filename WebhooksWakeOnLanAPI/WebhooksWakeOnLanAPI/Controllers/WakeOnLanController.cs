using System;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using WebhooksWakeOnLanAPI.Data;
using WebhooksWakeOnLanAPI.Data.Services;

namespace WebhooksWakeOnLanAPI.Controllers
{
    [Route("[controller]")]

    public class WakeOnLanController : Controller
    {
        private readonly IWakeOnLanService _wakeOnLanService;

        public WakeOnLanController(IWakeOnLanService wakeOnLanService)
        {
            _wakeOnLanService = wakeOnLanService;
        }

        [HttpPost("[action]")]
        public IActionResult Wake([FromBody]Device device)
        {
            if (device != null)
            {
                _wakeOnLanService.GenerateMagicPacket(device);
            }

            return Ok();
        }
    }
}
