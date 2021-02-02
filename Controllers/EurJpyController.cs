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
        public Price Get()
        {
            return TradeEngine.Instance.OandaPrice[TradeEngine.EURJPY];
        }
    }
}
