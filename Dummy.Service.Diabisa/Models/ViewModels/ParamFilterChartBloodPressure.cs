using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dummy.Service.Diabisa.Models.ViewModels
{
    public class ParamFilterChartBloodPressure
    {
        public int patient_id { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public string method { get; set; }

        public ParamFilterChartBloodPressure()
        {
            method = "";
        }
    }

   
}
