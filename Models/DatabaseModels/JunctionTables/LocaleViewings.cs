using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BerrasBiograf
{
    public class LocaleViewings
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Locale")]
        public virtual int LocaleId { get; set; }

        [ForeignKey("Viewing")]
        public virtual int ViewingId { get; set; }
    }
}
