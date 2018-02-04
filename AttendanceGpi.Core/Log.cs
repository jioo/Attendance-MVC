using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceGpi.Core
{
    [Table("Logs")]
    public class Log
    {
        [Key]
        public int LogId { get; set; }
        public string UserId { get; set; }
        public int SchedId { get; set; }

        public DateTime? TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }

        public virtual EmployeeInfo EmployeesInfo { get; set; }
        public virtual Schedule Schedules { get; set; }

    }
}
