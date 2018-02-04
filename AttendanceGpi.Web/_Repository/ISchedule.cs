using AttendanceGpi.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceGpi.Web._Repository
{
    public interface ISchedule
    {
        List<Schedule> Show();

        Schedule Find(int id);

        void Create(Schedule schedule);

        void Edit(Schedule schedule);
    }


}