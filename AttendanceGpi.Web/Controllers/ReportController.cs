using AttendanceGpi.Web._Infrastructure;
using AttendanceGpi.Web._Repository;
using AttendanceGpi.Web.ViewModel;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AttendanceGpi.Web.Controllers
{
    [Authorize(Roles = "Admin, Employee")]
    public class ReportController : Controller
    {
        private IAdmin _repo;

        public ReportController(IAdmin repo)
        {
            _repo = repo;
        }

        //
        // GET: Report
        public ActionResult Index()
        {
            EmployeeSelectList();
            return View();
        }

        //
        // GET: Report/Index
        public ActionResult GenerateReport(ReportViewModel report)
        {
            return PartialView("ReportResult", _repo.GenerateReport(report));
        }

        [ActionName("Report")]
        public ActionResult GeneratePdf(ReportViewModel report)
        {
            return new RazorPDF.PdfActionResult("PdfResult", _repo.GenerateReport(report));
        }

        #region Helper
        private void EmployeeSelectList()
        {
            var _ctx = new DefaultDbContext();
            ViewBag.UserId = new SelectList(_ctx.EmployeesInfo, "UserId", "Name");
        }
        #endregion
    }
}