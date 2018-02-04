using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AttendanceGpi.Web.ViewModel
{
    public class ReportViewModel
    {
        [Required]
        [Display(Name = "Employee")]
        public string UserId { get; set; }
        [Required]
        [Display(Name = "Date From")]
        public DateTime DateFrom { get; set; }
        [Required]
        [Display(Name = "Date To")]
        public DateTime DateTo { get; set; }
    }
}