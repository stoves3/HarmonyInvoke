using HarmonyInvokeInfrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HarmonyInvoke.Controllers
{
    [ApiController]
    [Route("")]
    public class HarmonyInvokeController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public HarmonyInvokeController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok();
        }

        [HttpGet]
        [Route("load")]
        public ActionResult GameLoad(string romName, string bankSwitchingCode)
        {
            var result = "Result:";
            try
            {
                if (string.IsNullOrWhiteSpace(romName) || string.IsNullOrWhiteSpace(bankSwitchingCode))
                {
                    throw new Exception("Rom Name or Bankswitching Code missing");
                }

                result = $"{result} {Invoker.Load(romName, bankSwitchingCode)}";
            }
            catch (Exception ex)
            {
                result = $"ERROR: {ex.Message}";
            }

            return Ok(result);
        }
    }
}
