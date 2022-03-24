using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dummy.Service.Diabisa.Models.ViewModels
{
    public class ParamCreateDiabisa
    {
        public string method { get; set; }
        public string method_details { get; set; }
        public string period { get; set; }
        public int value { get; set; }
        public string status { get; set; }
        public string target { get; set; }
    }
}
