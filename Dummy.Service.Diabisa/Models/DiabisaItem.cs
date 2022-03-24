﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dummy.Service.Diabisa.Models
{
    public class DiabisaItem
    {
        public int id { get; set; }
        public string method { get; set; }
        public string method_details { get; set; }
        public string period { get; set; }
        public int value { get; set; }
        public string target { get; set; }
        public string check_date { get; set; }
        public string check_time { get; set; }
        public DateTime created_date { get; set; }
    }
}
