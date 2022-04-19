using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dummy.Service.Diabisa.Models
{
    public class ChartCoordinateBloodPressure
    {
        public string chart_type { get; set; }
        public string method { get; set; }
        public float y { get; set; }
        public string x { get; set; }
    }
}
