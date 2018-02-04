using AttendanceGpi.Core;
using AttendanceGpi.Web._Infrastructure;
using AttendanceGpi.Web._Repository;
using AttendanceGpi.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AttendanceGpi.Web._Consolidator
{
    public class LogConsolidator : ILog
    {
        private DefaultDbContext _ctx = new DefaultDbContext();

        public LogViewModel LogInfo(int logId)
        {
            var logView = new LogViewModel();
            logView.TimeLabel = "TIME";
            logView.Picture = "user.png";
            logView.TimeTextStyle = string.Empty;

            if (logId != 1)
            {
                var log = (from lg in _ctx.Logs
                           join emp in _ctx.EmployeesInfo
                               on lg.UserId equals emp.UserId
                           join schd in _ctx.Schedules
                               on lg.SchedId equals schd.SchedId
                           where lg.LogId == logId
                           select lg).FirstOrDefault();

                logView.LogId = log.LogId;
                logView.Picture = log.EmployeesInfo.Picture;
                logView.Name = log.EmployeesInfo.Name;
                logView.Position = log.EmployeesInfo.Position;
                logView.Shift = log.Schedules.SchedStart + " - " + log.Schedules.SchedEnd;
                logView.Time = (log.TimeOut == null)
                                ? log.TimeIn.ToString()
                                : log.TimeOut.ToString();
                logView.TimeLabel = (log.TimeOut == null)
                                     ? "TIME IN"
                                     : "TIME OUT";
                logView.TimeTextStyle = (log.TimeOut == null)
                                        ? CheckTimeDifference(log.TimeIn, log.Schedules.SchedStart, true)
                                        : CheckTimeDifference(log.TimeOut, log.Schedules.SchedEnd, false);
            }

            return logView;
        }

        public int LogTimeIn(string id)
        {
            var log = new Log();
            var employee = (from emp in _ctx.Employees
                            join info in _ctx.EmployeesInfo
                                on emp.Id equals info.UserId
                            where emp.Id == id
                            select emp).Single();

            log.SchedId = employee.SchedId;
            log.TimeIn = DateTime.Now;
            log.UserId = employee.Id;

            _ctx.Logs.Add(log);
            _ctx.SaveChanges();

            return log.LogId;
        }

        public int LogTimeOut(int id)
        {
            var log = _ctx.Logs.Find(id);
            log.TimeOut = DateTime.Now;
            _ctx.Entry(log).State = EntityState.Modified;
            _ctx.SaveChanges();

            return log.LogId;
        }


        public int? IsUserLogged(string id)
        {
            try
            {
                var user = (from log in _ctx.Logs
                            where log.UserId == id
                            && log.TimeOut == null
                            select log).Single();
                return user.LogId;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string GetUserName(string cardNo)
        {
            try
            {
                var username = (from emp in _ctx.Employees
                                join info in _ctx.EmployeesInfo
                                    on emp.Id equals info.UserId
                                where info.CardNo == cardNo && info.IsResigned == 0
                                select emp).First().UserName;
                return username;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public bool IsLocked(string userId)
        {
            try
            {
                var result = _ctx.EmployeesInfo
                .Where(c => c.UserId == userId && c.IsResigned == 1)
                .FirstOrDefault();
                return (result != null) ? true : false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #region Helpers
        private string CheckTimeDifference(DateTime? currentTime, string schedTime, bool isTimeIn)
        {
            var currentDateTime = Convert.ToDateTime(currentTime).TimeOfDay;
            var currentSchedTime = (isTimeIn)
                                   ? Convert.ToDateTime(schedTime).AddMinutes(15).TimeOfDay
                                   : Convert.ToDateTime(schedTime).TimeOfDay;


            // result = 1 if current DateTime is longer than currentSchedTime.
            // result = -1 if currentDatetime is shorter than currentSchedTime.
            var result = TimeSpan.Compare(currentDateTime, currentSchedTime);
            return (isTimeIn)
                ? (result == 1) ? "text-danger" : string.Empty
                : (result == -1) ? "text-primary" : string.Empty;
        }  
        #endregion

    }
}