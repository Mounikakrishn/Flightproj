using System;
using System.Collections.Generic;

#nullable disable

namespace Adminmicroservices.Models
{
    public partial class TbUser
    {
        public int UserId { get; set; }
        public string AirlineName { get; set; }
        public int? FlightId { get; set; }
        public string UserName { get; set; }
        public string Gender { get; set; }
        public int? Age { get; set; }
        public string Emailid { get; set; }
        public int? Noofseates { get; set; }
        public string Seatnum { get; set; }
        public string Meal { get; set; }
        public string Pnr { get; set; }
        public string Cancelled { get; set; }
    }
}
