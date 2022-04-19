using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dummy.Service.Diabisa.Models
{
    public class ChartBloodGlucose
    {
        public int id { get; set; }
        public int patient_id { get; set; }
        public float value { get; set; }
        public float average { get; set; }
        public float min_value { get; set; }
        public float max_value { get; set; }
        public string measurement { get; set; }
        public DateTime created_date { get; set; }
    }
}
