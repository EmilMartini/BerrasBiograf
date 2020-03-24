using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BerrasBiograf
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public virtual List<Booking> Bookings { get; set; }
    }
}
