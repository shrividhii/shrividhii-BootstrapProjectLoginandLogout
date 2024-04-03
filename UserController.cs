using project_vidhi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project_vidhi.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Submit(LoginAuthentication model)
        {
            LoginAuthentication la = new LoginAuthentication();
            la.Username = model.Username;
            la.Password = model.Password;

            if(la.Username=="vidhi" && la.Password=="vidhi1234")
                return RedirectToAction("UserProfile","UserController");
            else if(la.Username=="admin" &&  la.Password=="admin")
                return RedirectToAction("AdminProfile","UserController");
            return RedirectToAction("Index","UserController");     
        }
        public ActionResult UserProfile()
        {
            
            return View();
        }

        public ActionResult AdminProfile()
        {
            return View();
        }

        public ActionResult Logout()
        {
            return View();
        }
    }
}