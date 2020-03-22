using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BerrasBiograf
{
    public class Locale
    {
        [Key]
        public int Id { get; set; }
        public string LocaleName { get; set; }
        public int TotalSeats { get; set; }
    }
}
