//using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ticketmicroservices.Controllers
{
    [Route("api/1.0/flight/ticket")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        [HttpGet]
        public IActionResult getData(int pnr)
        {
            return Ok();
        }
    }
}
