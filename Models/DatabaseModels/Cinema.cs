using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BerrasBiograf
{
    public class Cinema
    {
        [Key]
        public Guid Id { get; set; }
        public IList<Movie> Movies { get; set; }
        public IList<Locale> Locales { get; set; }
    }
}
