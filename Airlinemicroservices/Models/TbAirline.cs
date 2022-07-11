using System;
using System.Collections.Generic;

#nullable disable

namespace Airlinemicroservices.Models
{
    public partial class TbAirline
    {
        public TbAirline()
        {
            TbSchedules = new HashSet<TbSchedule>();
        }

        public int AirlineId { get; set; }
        public string AirlineName { get; set; }
        public string AirlineLogo { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }

        public virtual ICollection<TbSchedule> TbSchedules { get; set; }
    }
}
