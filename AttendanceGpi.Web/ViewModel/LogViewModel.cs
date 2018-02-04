using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceGpi.Web.ViewModel
{
    public class LogViewModel
    {
        public int? LogId { get; set; }
        public string Picture { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Shift { get; set; }
        public string Time { get; set; }
        public string TimeLabel { get; set; }
        public string TimeTextStyle { get; set; }

    }
}