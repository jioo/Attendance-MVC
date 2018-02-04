using AttendanceGpi.Web._Infrastructure;
using AttendanceGpi.Web._Repository;
using System.Linq;
using AttendanceGpi.Web.ViewModel;
using System.Collections.Generic;
using AttendanceGpi.Core;
using System;
using System.Data.Entity;

namespace AttendanceGpi.Web._Consolidator
{
    public class AdminConsolidator : IAdmin
    {
        private DefaultDbContext _ctx = new DefaultDbContext();

        public List<AdminLogViewModel> Show()
        {
            var logs = _ctx.Logs.Where(s => s.LogId != 1).ToList().OrderByDescending(o => o.TimeIn);
            var logView = new List<AdminLogViewModel>();

            foreach (var item in logs)
            {
                logView.Add(new AdminLogViewModel()
                {
                    LogId = item.LogId,
                    UserId = item.UserId,
                    Name = item.EmployeesInfo.Name,
                    SchedName = item.Schedules.SchedName,
                    SchedStart = item.Schedules.SchedStart,
                    SchedEnd = item.Schedules.SchedEnd,
                    TimeIn = item.TimeIn.ToString(),
                    TimeOut = item.TimeOut.ToString()
                });
            }

            return logView;
        }

        public List<AdminLogViewModel> GenerateReport(ReportViewModel report)
        {
            var dateTo = report.DateTo;
            report.DateTo = dateTo.AddHours(23).AddMinutes(59).AddSeconds(59);
            var result = _ctx.Logs
                .Where(x => x.UserId == report.UserId)
                .Where(d => d.TimeIn >= report.DateFrom && d.TimeIn <= report.DateTo).ToList();
            
            var logView = new List<AdminLogViewModel>();
            if(result.Any())
            {
                foreach (var item in result)
                {
                    logView.Add(new AdminLogViewModel()
                    {
                        Name = item.EmployeesInfo.Name,
                        SchedName = item.Schedules.SchedName,
                        TimeIn = item.TimeIn.ToString(),
                        TimeOut = item.TimeOut.ToString(),
                        TimeInStyle = CheckTimeStyleDifference(item.TimeIn, item.Schedules.SchedStart, true),
                        TimeOutStyle = CheckTimeStyleDifference(item.TimeOut, item.Schedules.SchedEnd, false),
                        DateFrom = report.DateFrom.ToString(),
                        DateTo = report.DateTo.ToString()
                    });
                }
            }
            else
            {
                //Return empty list
                logView.Add(new AdminLogViewModel()
                {
                    Name = string.Empty
                });
            }
            return logView;
        }

        public Log Find(int logId)
        {
            return _ctx.Logs.Find(logId);
        }

        public void Update(Log newLog)
        {
            try
            {
                var log = _ctx.Logs.Find(newLog.LogId);
                log.TimeIn = newLog.TimeIn;
                log.TimeOut = newLog.TimeOut;

                _ctx.Entry(log).State = EntityState.Modified;
                _ctx.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<string[]> ShowAjaxLogs()
        {
            var logs = _ctx.Logs.Where(s => s.LogId != 1).ToList().OrderByDescending(o => o.TimeIn);
            var logsList = new List<string[]>();

            foreach (var item in logs)
            {
                logsList.Add(new string[] {
                    item.EmployeesInfo.Name,
                    item.Schedules.SchedName,
                    CheckTimeDifference(item.TimeIn, item.Schedules.SchedStart, true),
                    CheckTimeDifference(item.TimeOut, item.Schedules.SchedEnd, false),
                    "<button class=\"btn btn-primary\" onclick=\"Edit("+ item.LogId + ")\">Edit</button>"
                });
            }

            return logsList;
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
            var style = (isTimeIn)
                ? (result == 1) ? "text-danger" : string.Empty
                : (result == -1) ? "text-primary" : string.Empty;

            return "<p class=\""+ style+ "\">" + currentTime + "</p>";
        }

        private string CheckTimeStyleDifference(DateTime? currentTime, string schedTime, bool isTimeIn)
        {
            var currentDateTime = Convert.ToDateTime(currentTime).TimeOfDay;
            var currentSchedTime = (isTimeIn)
                                   ? Convert.ToDateTime(schedTime).AddMinutes(15).TimeOfDay
                                   : Convert.ToDateTime(schedTime).TimeOfDay;

            // result = 1 if current DateTime is longer than currentSchedTime.
            // result = -1 if currentDatetime is shorter than currentSchedTime.
            var result = TimeSpan.Compare(currentDateTime, currentSchedTime);
            var style = (isTimeIn)
                ? (result == 1) ? "text-danger" : string.Empty
                : (result == -1) ? "text-primary" : string.Empty;

            return style;
        } 
        #endregion
    }
}