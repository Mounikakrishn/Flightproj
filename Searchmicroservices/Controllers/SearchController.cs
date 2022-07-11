//using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Searchmicroservices.Controllers
{
    [Route("api/1.0/flight/search")]
    [ApiController]
    public class SearchController : ControllerBase

    {
        [HttpPost]
        public IActionResult SearchFlight()
        {
            return Ok();
        }
    }
}
