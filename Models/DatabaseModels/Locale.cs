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
        public Guid Id { get; set; }
        public virtual Cinema Cinema { get; set; }
        public string LocaleName { get; set; }
        public int TotalSeats { get; set; }
    }
}
