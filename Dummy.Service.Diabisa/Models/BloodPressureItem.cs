using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dummy.Service.Diabisa.Models
{
    public class BloodPressureItem
    {
        public int id { get; set; }
        public int patient_id { get; set; }
        public string method { get; set; }
        public string method_details { get; set; }
        public string type { get; set; }
        public float systole { get; set; }
        public float diastole { get; set; }
        public string status { get; set; }
        public string check_date { get; set; }
        public string check_time { get; set; }
        public DateTime created_date { get; set; }
    }
}
