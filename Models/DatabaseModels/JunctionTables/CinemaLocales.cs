using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BerrasBiograf
{
    public class CinemaLocales
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Cinema")]
        public virtual int CinemaId { get; set; }

        [ForeignKey("Locale")]
        public virtual int LocaleId { get; set; }
    }
}
