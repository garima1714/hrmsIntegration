using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Custom_Models
{
    public class AddTimeSheet
    {
        public string Empid { get; set; }
        public string Empname { get; set; }
        public DateTime To { get; set; }
        public DateTime From { get; set; }

        public ICollection<TimeSheetData> data { get; set; }
        
    }

    public partial class TimeSheetData
    {
        public string Customer { get; set; }
        public string Task { get; set; }
        public string Project { get; set; }
        public string Company { get; set; }
        public DateTime Date { get; set; }
        public string Submittedto { get; set; }
        public int Hours { get; set; }
        public string Status { get; set; }
    }
}
