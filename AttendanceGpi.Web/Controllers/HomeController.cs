using AttendanceGpi.Web._Repository;
using AttendanceGpi.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AttendanceGpi.Web.Controllers
{
    public class HomeController : Controller
    {
        private ILog _repo;

        public HomeController(ILog repo)
        {
            _repo = repo;
        }
        public ActionResult Index()
        {
            return View();
        }

        //
        // POST: /Home/Index
        [HttpPost]
        public JsonResult Index(string cardNo, string password)
        {
            var username = _repo.GetUserName(cardNo);
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);
            var validCredentials = userManager.Find(username, password);
            var currentUser = userManager.FindByName(username);

            var jsonResponse = "Error";
            var logIdResponse = 0;
            int? isUserLogged = null;

            if (validCredentials != null)
            {
                //Check if user is locked
                if (_repo.IsLocked(currentUser.Id))
                {
                    return Json(new { response = "Locked", logId = logIdResponse }, JsonRequestBehavior.AllowGet);
                }

                //If user already logged in, logout the user. vice versa.
                isUserLogged = _repo.IsUserLogged(currentUser.Id);
                logIdResponse = (isUserLogged != null)
                                ? _repo.LogTimeOut((int)isUserLogged)
                                : _repo.LogTimeIn(currentUser.Id);
                jsonResponse = "Success";
            }  

            return Json(new { response = jsonResponse, logId = logIdResponse, isUserLogged = isUserLogged }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LogInfo(int logId)
        {
            return PartialView("LogInfo", _repo.LogInfo(logId));
        }
    }
}