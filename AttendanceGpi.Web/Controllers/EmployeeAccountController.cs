using AttendanceGpi.Web._Repository;
using AttendanceGpi.Web.ViewModel;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AttendanceGpi.Web.Controllers
{
    [Authorize(Roles = "Employee")]
    public class EmployeeAccountController : Controller
    {
        private IEmployee _repo;

        public EmployeeAccountController(IEmployee repo)
        {
            _repo = repo;
        }

        //
        // GET: EmployeeAccount
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            return View();
        }

        //
        // GET: EmployeeAccount/Info
        public ActionResult Edit()
        {
            var userId = User.Identity.GetUserId();
            return View(_repo.Find(userId));
        }

        //
        // POST: EmployeeAccount/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id, UserName, Picture, Name, Position, SchedId")] EmployeeEditViewModel employee)
        {
            if (ModelState.IsValid)
            {
                var originalPicture = employee.Picture;
                HttpPostedFileBase file = Request.Files["Picture"];
                employee.Picture = (file.ContentLength > 0)
                    ? UploadPicture(file)
                    : originalPicture;

                _repo.Edit(employee);
                TempData["Success"] = "You have successfullly updated your information.";
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        #region Helper
        private string _myRandomNumber;
        private static readonly Random Random = new Random();
        private static readonly object SyncLock = new object();

        //Upload picture and send to Files folder.
        public string UploadPicture(HttpPostedFileBase pictureFile)
        {
            _myRandomNumber = RandomNumber(0, 10000000).ToString("D");
            int newPictureId = Int32.Parse(_myRandomNumber);
            string newPictureName = newPictureId + ".png";
            string baseDirectory = Server.MapPath("~/Images/");

            pictureFile.SaveAs((baseDirectory + (newPictureId + ".png")));
            return newPictureName;
        }

        private static int RandomNumber(int min, int max)
        {
            lock (SyncLock)
            {
                return Random.Next(min, max);
            }
        }
        #endregion
    }
}