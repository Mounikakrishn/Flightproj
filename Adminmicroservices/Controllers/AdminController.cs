using Adminmicroservices.Models;
using Adminmicroservices.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adminmicroservices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AdminController : ControllerBase
    {

        FlightDBContext dbAirline;

        public AdminController(FlightDBContext _dbAirline)
        {
            dbAirline = _dbAirline;
        }

        [HttpGet]
        [Route("Scheduleflight")]
        //[Authorize]
        public IEnumerable<TbSchedule> getData()
        {
            return dbAirline.TbSchedules.ToList();
        }
        [HttpPost("Register")]
        // [Authorize]
        public IActionResult Register(AirLineViewModel airlineViewModel)
        {
            TbAirline airline = new TbAirline();
            airline.AirlineName = airlineViewModel.AirlineName;

            airline.AirlineLogo = airlineViewModel.AirlineLogo;

            airline.ContactNumber = airlineViewModel.ContactNumber;
            airline.Address = airlineViewModel.Address;

            dbAirline.TbAirlines.Add(airline);
            dbAirline.SaveChanges();
            return Ok("Record Added Successfully");
        }
       
        [HttpPut]
        [Authorize]
        public IActionResult putData(AirLineViewModel airlineViewModel)
        {
            if (dbAirline.TbAirlines.Any(x => x.AirlineId == airlineViewModel.AirlineId))
            {
                var data = dbAirline.TbAirlines.Where(x => x.AirlineId == airlineViewModel.AirlineId).FirstOrDefault();
                data.AirlineName = airlineViewModel.AirlineName;
                data.ContactNumber = airlineViewModel.ContactNumber;
                data.Address = airlineViewModel.Address;
                data.AirlineLogo = airlineViewModel.AirlineLogo;
                dbAirline.TbAirlines.Update(data);
                dbAirline.SaveChanges();
                return Ok("Record have been successfully updated.");
            }

            return BadRequest("Record not found.");
        }

        [HttpDelete]
        [Authorize]
        public IActionResult deleteData(int Id)
        {
            if (dbAirline.TbAirlines.Any(x => x.AirlineId == Id))
            {
                var data = dbAirline.TbAirlines.Where(x => x.AirlineId == Id).FirstOrDefault();
                dbAirline.TbAirlines.Remove(data);
                dbAirline.SaveChanges();
                return Ok("Record have been successfully deleted.");
            }

            return BadRequest("Record not found.");
        }
    }
}





