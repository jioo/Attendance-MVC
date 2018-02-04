using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AttendanceGpi.Web.ViewModel
{
    public class EmployeeEditViewModel
    {
        public string Id { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Email")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Card #")]
        public string CardNo { get; set; }

        [Required]
        public string Name { get; set; }

        public string Picture { get; set; }
        public string Position { get; set; }

        public byte IsResigned { get; set; }

        public DateTime Created { get; set; }

        [Required]
        [Display(Name = "Schedule")]
        public int SchedId { get; set; }
    }
}