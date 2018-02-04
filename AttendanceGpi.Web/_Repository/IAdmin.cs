using AttendanceGpi.Core;
using AttendanceGpi.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceGpi.Web._Repository
{
    public interface IAdmin
    {
        List<AdminLogViewModel> Show();
        List<AdminLogViewModel> GenerateReport(ReportViewModel report);
        List<string[]> ShowAjaxLogs();
        Log Find(int logId);
        void Update(Log log);
    }
}