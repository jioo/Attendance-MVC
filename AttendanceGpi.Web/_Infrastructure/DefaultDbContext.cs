using AttendanceGpi.Core;
using System.Data.Entity;

namespace AttendanceGpi.Web._Infrastructure
{
    public class DefaultDbContext : DbContext
    {
        public DefaultDbContext() : base("name=DefaultConnection")
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeInfo> EmployeesInfo { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Log> Logs { get; set; } 

    }
}