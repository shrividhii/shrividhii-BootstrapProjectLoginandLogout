using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project_vidhi.Models;
using Newtonsoft.Json;
using System.Net;
using System.ComponentModel.DataAnnotations;

namespace project_vidhi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult Check()
        {
            Users users = new Users()
            {
                Username = "vidhi", Password = "vidhi1234"

            };

            var json = JsonConvert.SerializeObject(users);
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ValidateCredentials(string returnUrl)
        {
            
            var json = System.IO.File.ReadAllText("credentials.json");
        //    var credentials = JsonSerializer.Deserialize<Users>
        //(json);

        //    if (Username == "testuser" && Password == "testpassword")
        //    {
        //        return Redirect(returnUrl);
        //    }
        //    else
        //    {
        //        ViewBag.Error = "Invalid credentials";
                return View("Index");
        //    }
        }
        public class Users
        {
            [Required]
            public String Username { get; set; }

            [Required]
            public String Password { get; set; }
        }
    }
}