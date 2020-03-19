﻿ using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BerrasBiograf
{
    public class Viewing
    {
        [Key]
        public Guid Id { get; set; }
        public Movie MovieToShow { get; set; }
        public Locale LocaleToShow { get; set; }
        public int AvailableSeats { get; set; }
        public DateTime TimeOfScreening { get; set; }
    }
}
