using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BerrasBiograf
{
    public class HomepageModel
    {
        public IEnumerable<Viewing> Viewings { get; set; }
        public string DayInWeek { get; set; }
    }
}
