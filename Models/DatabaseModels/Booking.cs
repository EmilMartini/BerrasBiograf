using System;
using System.ComponentModel.DataAnnotations;

namespace BerrasBiograf
{
    public class Booking
    {
        [Key]
        public Guid Id { get; set; }
        public User User { get; set; }
        public Viewing BookedViewing { get; set; }
        public byte NumberOfBookedSeats { get; set; }
        public DateTime TimeOfBooking { get; set; }
        public bool Confirmed { get; set; }
    }
}
