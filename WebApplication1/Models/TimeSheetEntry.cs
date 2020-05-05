using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class TimeSheetEntry
    {
        public string Empid { get; set; }
        public string Customer { get; set; }
        public string Task { get; set; }
        public string Company { get; set; }
        public int Timestampid { get; set; }
        public int Id { get; set; }
        public string Project { get; set; }

        public TimeSheetItem Timestamp { get; set; }
    }
}
