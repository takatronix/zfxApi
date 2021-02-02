using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace zfxApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Price> Get()
        {
            return TradeEngine.Instance.OandaPrice.Values.ToArray();
        }
    }
}
