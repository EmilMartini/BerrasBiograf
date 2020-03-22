 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BerrasBiograf
{
    public class Viewing
    {
        [Key]
        public int Id { get; set; }
        public int MovieToShowId { get; set; }
        public int LocaleToShowId { get; set; }
        public int AvailableSeats { get; set; }
        public DateTime TimeOfScreening { get; set; }
    }
}
