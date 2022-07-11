using System;
using System.Collections.Generic;

#nullable disable

namespace Bookingmicroservices.Models
{
    public partial class TbAdmin
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
