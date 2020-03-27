using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
