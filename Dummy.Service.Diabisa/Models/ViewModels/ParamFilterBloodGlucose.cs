using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dummy.Service.Diabisa.Models.ViewModels
{
    public class ParamFilterBloodGlucose
    {
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }

        public string type_1 { get; set; }
        public string type_2 { get; set; } 

        public string method_1 { get; set; } 
        public string method_2 { get; set; } 
        public string method_3 { get; set; } 
        public string method_4 { get; set; } 
        public string method_5 { get; set; } 
        public string method_6 { get; set; } 
        public string method_7 { get; set; } 

        public string status_1 { get; set; } 
        public string status_2 { get; set; } 
        public string status_3 { get; set; } 
        public string status_4 { get; set; } 
        public string status_5 { get; set; }

        public ParamFilterBloodGlucose()
        {
            type_1 = string.Empty;
            type_2 = string.Empty;

            method_1 = string.Empty;
            method_2 = string.Empty;
            method_3 = string.Empty;
            method_4 = string.Empty;
            method_5 = string.Empty;
            method_6 = string.Empty;
            method_7 = string.Empty;

            status_1 = string.Empty;
            status_2 = string.Empty;
            status_3 = string.Empty;
            status_4 = string.Empty;
            status_5 = string.Empty;

        }

    }
}
