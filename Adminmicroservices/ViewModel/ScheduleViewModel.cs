﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adminmicroservices.ViewModel
{
    public class ScheduleViewModel
    {
        public int FlightIdnum { get; set; }
        public int? AirlineId { get; set; }
        public string Airlinename { get; set; }
        public string Fromplace { get; set; }
        public string Toplace { get; set; }
        public DateTime? Startdatetime { get; set; }
        public DateTime? Enddatetime { get; set; }
        public string Scheduleddays { get; set; }
        public int? Businessclsseats { get; set; }
        public int? Nonbusinessclsseats { get; set; }
        public string Ticketprice { get; set; }
        public string Noofrows { get; set; }
        public string Meal { get; set; }

    }
}
