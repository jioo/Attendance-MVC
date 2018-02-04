using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceGpi.Core
{
    [Table("AspNetUsers")]
    public class Employee
    {
        [Key]
        public string Id { get; set; }
        public int SchedId { get; set; }
        public string UserName { get; set; }

        public virtual EmployeeInfo EmployeeInfo { get; set; }
        public virtual Schedule Schedules { get; set; }
        

    }
}
