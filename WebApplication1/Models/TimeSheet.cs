using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class TimeSheet
    {
        public TimeSheet()
        {
            TimeSheetItem = new HashSet<TimeSheetItem>();
        }

        public int Id { get; set; }
        public string Empid { get; set; }
        public string Empname { get; set; }
        public string Day { get; set; }
        public DateTime? Date { get; set; }

        public ICollection<TimeSheetItem> TimeSheetItem { get; set; }
    }
}
