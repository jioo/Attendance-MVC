using AttendanceGpi.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceGpi.Web._Repository
{
    public interface ILog
    {
        LogViewModel LogInfo(int LogId);

        int LogTimeIn(string id);

        int LogTimeOut(int id);

        int? IsUserLogged(string id);

        string GetUserName(string cardNo);

        bool IsLocked(string cardNo);
    }
}