using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BerrasBiograf
{
    public class Schedule
    {
        [Key]
        public Guid Id { get; set; }
        public List<Viewing> Viewings { get; set; }
    }
}
