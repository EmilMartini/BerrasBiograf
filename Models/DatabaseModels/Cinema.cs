using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BerrasBiograf
{
    public class Cinema
    {
        [Key]
        public Guid Id { get; set; }
        public virtual List<Locale> Locales { get; set; }
    }
}
