using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dummy.Service.Diabisa.Models
{
    public class ChartBloodPressure
    {
        public int id { get; set; }
        public string chart_type { get; set; }
        public string method { get; set; }
        public float value { get; set; }
        public string measurement { get; set; }
        public string check_date { get; set; }
    }
}
