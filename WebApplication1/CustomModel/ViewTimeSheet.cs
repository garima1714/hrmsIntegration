using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.CustomModel
{
    public class ViewTimeSheet
    {
        public string Empid { get; set; }
        public string Empname { get; set; }
        public DateTime To { get; set; }
        public DateTime From { get; set; }
        public string Day { get; set; }
        public int? Hours { get; set; }
        public string Status { get; set; }
        public string Customer { get; set; }
        public string Task { get; set; }
        public string Company { get; set; }
        public string Project { get; set; }
    }
}
