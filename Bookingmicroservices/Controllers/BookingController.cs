using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookingmicroservices.Controllers
{
    [Route("api/1.0/flight/booking")]
    [ApiController]
    public class BookingController : ControllerBase

    {
        [HttpPost]
        public IActionResult postData(string flightId)
        {
            return Ok();
        }
        [HttpGet]
        public IActionResult history(string emailId)
        {
            return Ok();
        }
        [HttpDelete]
        public IActionResult cancel(int pnr)
        {
            return Ok();
        }


    }
}

