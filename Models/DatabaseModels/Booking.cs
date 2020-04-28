using System;
using System.ComponentModel.DataAnnotations;

namespace BerrasBiograf
{
    public class Booking
    {
        [Key]
        public Guid Id { get; set; }
        public virtual User User { get; set; }
        public virtual Viewing Viewing {get;set;}
        public int NumberOfBookedSeats { get; set; }
        public DateTime TimeOfBooking { get; set; }
    }
}
