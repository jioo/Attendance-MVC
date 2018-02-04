using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceGpi.Core
{
    [Table("EmployeesInfo")]
    public class EmployeeInfo
    {
        [Key, ForeignKey("Employee")]
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string Position { get; set; }
        [Display(Name = "Card #")]
        public string CardNo { get; set; }
        public byte IsResigned { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime? Deleted { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual ICollection<Log> Logs { get; set; }
    }
}
