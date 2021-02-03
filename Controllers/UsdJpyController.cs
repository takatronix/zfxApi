using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zfxApi.Controllers
{
    [Route("api/price/[controller]")]
    [ApiController]
    public class UsdJpyController : ControllerBase
    {
        [HttpGet]
        public Price Get([FromQuery(Name = "time")] DateTime time)
        {
            var remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress;
            Console.WriteLine($"GET USDJPY from {remoteIpAddress}");

            if (time == DateTime.MinValue)
                return TradeEngine.Instance.OandaPrice[TradeEngine.USDJPY];

            return TradeEngine.Instance.FindPrice(TradeEngine.USDJPY, time);
        }



    }
}
