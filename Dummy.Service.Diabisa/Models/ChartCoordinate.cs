using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dummy.Service.Diabisa.Models
{
    public class ChartCoordinate
    {
        public string chart_type { get; set; }
        public float y { get; set; }
        public float x { get; set; }
        public DateTime created_date { get; set; }
    }
}
