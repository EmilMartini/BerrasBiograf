﻿using System.Collections.Generic;

namespace BerrasBiograf
{
    public class HomepageModel
    {
        public IEnumerable<Viewing> Viewings { get; set; }
        public string DayInWeek { get; set; }
    }
}
