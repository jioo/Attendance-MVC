using AttendanceGpi.Core;
using AttendanceGpi.Web._Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AttendanceGpi.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ScheduleController : Controller
    {
        private ISchedule _repo;

        public ScheduleController(ISchedule repo)
        {
            _repo = repo;
        }

        //
        // GET: Schedule
        public ActionResult Index()
        {
            return View(_repo.Show());
        }

        //
        // GET: Schedule/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: Schedule/Create/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SchedName, SchedStart, SchedEnd")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                _repo.Create(schedule);
                TempData["Success"] = "You have successfully created " + schedule.SchedName;
                return RedirectToAction("Index");
            }

            return View(schedule);
        }

        //
        // GET: Schedule/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_repo.Find(id));
        }

        //
        // POST: Schedule/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "SchedId, SchedName, SchedStart, SchedEnd")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                _repo.Edit(schedule);
                TempData["Success"] = "You have successfullly updated " + schedule.SchedName;
                return RedirectToAction("Index");
            }
            return View();
        }



    }
}