using Airlinemicroservices.Models;
using Airlinemicroservices.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airlinemicroservices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirlineController : ControllerBase
    {
        AirlineDBContext dbAirline;

        public AirlineController(AirlineDBContext _dbAirline)
        {
            dbAirline = _dbAirline;
        }

        [HttpPost("Inventory/Add")]
        // [Authorize]
        public IActionResult AddInventory(Schedule schedule)
        {
            TbSchedule tbschedule = new TbSchedule();
            // tbschedule.AirlineId = schedule.AirlineId;

            tbschedule.Fromplace = schedule.Fromplace;
            tbschedule.Toplace = schedule.Toplace;
            tbschedule.Startdatetime = schedule.Startdatetime;
            tbschedule.Enddatetime = schedule.Enddatetime;
            tbschedule.Scheduleddays = schedule.Scheduleddays;
            tbschedule.Businessclsseats = schedule.Businessclsseats;
            tbschedule.Ticketprice = schedule.Ticketprice;


            dbAirline.TbSchedules.Add(tbschedule);
            dbAirline.SaveChanges();
            return Ok("Record Added Successfully");
        }


    }
}
