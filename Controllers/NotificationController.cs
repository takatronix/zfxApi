using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace zfxApi.Controllers
{
    public class ZfxNotification
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        // POST: api/Notification


        [HttpPost]
        public void Post([FromBody] ZfxNotification req)
        {
            Debug.WriteLine(req.Key);

            Debug.WriteLine(req.Value);
            // return Request.CreateResponse(HttpStatusCode.Created, "");

        }



    }
}
