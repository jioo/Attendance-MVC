using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceGpi.Core
{
    [Table("Schedules")]
    public class Schedule
    {
        [Key]
        public int SchedId { get; set; }

        [Required]
        [Display(Name = "Schedule Name")]
        public string SchedName { get; set; }

        [Required]
        [Display(Name = "Start Time")]
        public string SchedStart { get; set; }

        [Required]
        [Display(Name = "End Time")]
        public string SchedEnd { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Log> Logs { get; set; }

    }
}
