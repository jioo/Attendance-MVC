using AttendanceGpi.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AttendanceGpi.Web.ViewModel
{
    public class AdminLogViewModel
    {
        public int LogId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        [Display(Name = "Shift")]
        public string SchedName { get; set; }
        public string SchedStart { get; set; }
        public string SchedEnd { get; set; }
        [Required]
        [Display(Name = "Time In")]
        public string TimeIn { get; set; }
        [Required]
        [Display(Name = "Time Out")]
        public string TimeOut { get; set; }

        public string TimeInStyle { get; set; }
        public string TimeOutStyle { get; set; }

        public string TimeInDiff { get; set; }
        public string TimeOutDiff { get; set; }

        public string ReportDate { get; set; }

        public string DateFrom { get; set; }
        public string DateTo { get; set; }
    }
}