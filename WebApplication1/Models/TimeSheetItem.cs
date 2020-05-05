using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class TimeSheetItem
    {
        public TimeSheetItem()
        {
            TimeSheetEntry = new HashSet<TimeSheetEntry>();
        }

        public string Empid { get; set; }
        public int Timestampid { get; set; }
        public string Submittedto { get; set; }
        public DateTime? Date { get; set; }
        public string Day { get; set; }
        public int? Hours { get; set; }
        public DateTime To { get; set; }
        public DateTime From { get; set; }
        public string Status { get; set; }

        public TimeSheet Emp { get; set; }
        public ICollection<TimeSheetEntry> TimeSheetEntry { get; set; }
    }
}
