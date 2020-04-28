 using System;
using System.ComponentModel.DataAnnotations;

namespace BerrasBiograf
{
    public class Viewing
    {
        [Key]
        public Guid Id { get; set; }
        public virtual Movie MovieToShow { get; set; }
        public virtual Locale LocaleToShow { get; set; }
        public int AvailableSeats { get; set; }
        public DateTime TimeOfScreening { get; set; }
    }
}
