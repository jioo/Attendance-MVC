using AttendanceGpi.Web._Consolidator;
using AttendanceGpi.Web._Repository;
using StructureMap;
namespace AttendanceGpi.Web {
    public static class IoC {
        public static IContainer Initialize() {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>
                                    {
                                        scan.TheCallingAssembly();
                                        scan.WithDefaultConventions();
                                    });
                            x.For<IAdmin>().Use<AdminConsolidator>();
                            x.For<IEmployee>().Use<EmployeeConsolidator>();
                            x.For<ISchedule>().Use<ScheduleConsolidator>();
                            x.For<ILog>().Use<LogConsolidator>();
                        });
            return ObjectFactory.Container;
        }
    }
}