using AttendanceGpi.Web._Infrastructure;
using AttendanceGpi.Web._Repository;
using AttendanceGpi.Web.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AttendanceGpi.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EmployeeController : Controller
    {
        private IEmployee _repo;

        public EmployeeController(IEmployee repo)
        {
            _repo = repo;
        }

        //
        // GET: Employee
        public ActionResult Index()
        {
            return View(_repo.Show());
        }

        //
        // POST: Employee/ChangePassword
        [HttpPost]
        public JsonResult ChangePassword(string UserId, string NewPassword)
        {
            var jsonResponse = (_repo.UpdatePassword(UserId, NewPassword))
                               ? "Success"
                               : "Error";
            return Json(new { response = jsonResponse }, JsonRequestBehavior.AllowGet);
        }

        //
        //POST: Employee/ChangeStatus
        [HttpPost]
        public ActionResult ChangeStatus(string id, string cardNo, byte status)
        {
            if (status == 1)
                status = 0;
            else if (status == 0)
                status = 1;

            var jsonResponse = (_repo.ChangeStatus(id, cardNo, status))
                               ? "Success"
                               : "Error";
            TempData["Success"] = (jsonResponse == "Success") ? "Status has been changed." : "";
            return Json(new { response = jsonResponse }, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: Employee/Create
        public ActionResult Create()
        {
            ScheduleSelectList();
            return View();
        }

        //
        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "UserName, CardNo, Picture, Password, Name, Position, SchedId")] EmployeeViewModel employee)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files["Picture"];
                employee.Picture = (file.ContentLength > 0)
                    ? UploadPicture(file)
                    : "user.png";

                //Create Identity account
                var userStore = new UserStore<IdentityUser>();
                var manager = new UserManager<IdentityUser>(userStore);
                var user = new IdentityUser() { UserName = employee.UserName };
                IdentityResult result = manager.Create(user, employee.Password);

                //Check if Email/UserName already exist.
                if (!result.Succeeded)
                {
                    ScheduleSelectList();            
                    TempData["Error"] = "Email already exist.";
                    return View(employee);
                }

                var currentUser = manager.FindByName(user.UserName);

                //Check if Card # already exist.
                if (_repo.ValidateCard(currentUser.Id, employee.CardNo))
                {
                    manager.Delete(user); //Roll back created user.
                    ScheduleSelectList();
                    TempData["Error"] = "Card # is already in use.";
                    return View(employee);
                }

                manager.AddToRole(currentUser.Id, "Employee");
                employee.Id = currentUser.Id;
                _repo.Create(employee);
                TempData["Success"] = "You have successfullly added " + employee.Name;
                return RedirectToAction("Index");
            }

            ScheduleSelectList();
            return View(employee);
        }

        //
        // GET: Employee/Edit/5
        public ActionResult Edit(string id)
        {
            ScheduleSelectList();
            return View(_repo.Find(id));
        }

        //
        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id, UserName, CardNo, Picture, Name, Position, SchedId, IsResigned, Created")] EmployeeEditViewModel employee)
        {
            if (ModelState.IsValid)
            {
                //Check if Card # already exist.
                if (_repo.ValidateCard(employee.Id, employee.CardNo))
                {
                    ScheduleSelectList();
                    TempData["Error"] = "Card # is already in use.";
                    return View(employee);
                }

                //Check if Email/UserName already exist.
                if (_repo.ValidateEmail(employee.Id, employee.UserName))
                {
                    ScheduleSelectList();
                    TempData["Error"] = "Email already exist.";
                    return View(employee);
                }

                var originalPicture = employee.Picture;
                HttpPostedFileBase file = Request.Files["Picture"];
                employee.Picture = (file.ContentLength > 0)
                    ? UploadPicture(file)
                    : originalPicture;
                
                _repo.Edit(employee);
                TempData["Success"] = "You have successfullly updated " + employee.Name;
                return RedirectToAction("Index");
            }

            ScheduleSelectList();
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

        //Display all dropdown list of schedules.
        private void ScheduleSelectList()
        {
            var _ctx = new DefaultDbContext();
            ViewBag.SchedId = new SelectList(_ctx.Schedules, "SchedId", "SchedName");
        }
        #endregion
    }
}