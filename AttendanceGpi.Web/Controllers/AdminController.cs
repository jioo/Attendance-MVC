using AttendanceGpi.Core;
using AttendanceGpi.Web._Repository;
using System;
using System.Web.Mvc;

namespace AttendanceGpi.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private IAdmin _repo;
        public AdminController(IAdmin repo)
        {
            _repo = repo;
        }

        //
        // GET: Admin
        public ActionResult Index()
        {
            return View(_repo.Show());
        }

        //
        // GET: Admin/AjaxLogs
        public ActionResult AjaxLogs()
        {
            return Json(new { aaData = _repo.ShowAjaxLogs() }, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: Admin/EditLog
        public JsonResult EditLog(int logId)
        {
            var log = _repo.Find(logId);
            return Json(new {
                name = log.EmployeesInfo.Name,
                timeIn = log.TimeIn.ToString(),
                timeOut = log.TimeOut.ToString()
            }, JsonRequestBehavior.AllowGet);
        }

        //
        // POST: Admin/EditLog
        [HttpPost]
        public JsonResult EditLog(int logId, string timeIn, string timeOut)
        {
            var newLog = new Log();
            newLog.LogId = logId;
            newLog.TimeIn = DateTime.Parse(timeIn);
            newLog.TimeOut = DateTime.Parse(timeOut);

            _repo.Update(newLog);
            return Json(string.Empty);
        }

    }
}