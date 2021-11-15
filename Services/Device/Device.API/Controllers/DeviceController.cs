using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Device.API.Controllers
{
    public class DeviceController : BaseController
    {
        public DeviceController()
        {
        }

        [HttpGet("all")]
        public ActionResult<string> GetAllDevices()
        {
            return "Successs!!!!";
        }
    }
}