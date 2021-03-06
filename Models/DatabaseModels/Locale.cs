﻿using System;
using System.ComponentModel.DataAnnotations;

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
