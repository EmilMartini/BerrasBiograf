using System;
using System.ComponentModel.DataAnnotations;

namespace BerrasBiograf
{
    public class AddBookingModel
    {
        [Required]
        public int NumberOfBookedSeats { get; set; }
        public virtual User User { get; set; }
        public virtual Viewing Viewing { get; set; }
    }
}