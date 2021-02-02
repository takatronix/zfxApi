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
    public class EurJpyController : ControllerBase
    {
        [HttpGet]
        public Price Get([FromQuery(Name = "time")] DateTime time)
        {
            if (time == DateTime.MinValue)
                return TradeEngine.Instance.OandaPrice[TradeEngine.EURJPY];

            return TradeEngine.Instance.FindPrice(TradeEngine.EURJPY, time);
        }
    }
}
