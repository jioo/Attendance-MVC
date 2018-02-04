using AttendanceGpi.Core;
using AttendanceGpi.Web._Infrastructure;
using AttendanceGpi.Web._Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AttendanceGpi.Web._Consolidator
{
    public class ScheduleConsolidator : ISchedule
    {
        private DefaultDbContext _ctx = new DefaultDbContext();

        public List<Schedule> Show()
        {
            return _ctx.Schedules.ToList();
        }

        public Schedule Find(int id)
        {
            return _ctx.Schedules.Find(id);
        }  

        public void Create(Schedule schedule)
        {
            try
            {
                _ctx.Schedules.Add(schedule);
                _ctx.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Edit(Schedule schedule)
        {
            try
            {
                _ctx.Entry(schedule).State = EntityState.Modified;
                _ctx.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}