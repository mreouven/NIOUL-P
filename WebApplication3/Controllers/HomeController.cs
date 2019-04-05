using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.DAL;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register(Users users) {
            
            Object a = Request.Form;
            return View();
        }
        public ActionResult checkfbapi()
        {
            
            if (Request.Form["email"] != null)
            {
                string email = Request.Form["email"];
                UsersDal udal = new UsersDal();
                List<Users> dbuser = (from x in udal.User where x.Email.Equals(email) select x).ToList();
                if (dbuser.Count > 0)
                {
                    var ok = new {success = "true", email =  Request.Form["email"],password=dbuser[0].Password};
                    
                    return Json(ok, JsonRequestBehavior.AllowGet);
                }
                var uk = new { success = "false", message = "not user found" };
                return Json(uk, JsonRequestBehavior.AllowGet);
            }
            var res = new { success = "false", message = "API KEY INVALIDE" };
            return Json(res, JsonRequestBehavior.AllowGet);

        }

        public ActionResult ValidateRegister(Users users)
        {
            if (ModelState.IsValid)
            {
                
                ViewBag.Error = ""  ;
                users.type = "0";
                UsersDal udal = new UsersDal();
                List<Users> dbuser = (from x in udal.User where x.Email.Equals(users.Email) select x).ToList();
                if (dbuser.Count > 0)
                {
                    ViewBag.Error = "Email early Register";
                    return View("Register",users);
                }
                udal.User.Add(users);
                udal.SaveChanges();
                return View("Index");
            }
            else
                return View("Register",users);


        }
        public ActionResult Login(Users obj)
        {
            if (Session["Log"] != null)
            {
                string a = Session["Log"].ToString();
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session["Log"] = null;
            return RedirectToAction("Index", new Users());
        }

        public ActionResult CheckLogin(Users obj)
        {
            string email = Request.Form["email"];
            UsersDal udal = new UsersDal();
            List<Users> dbuser = (from x in udal.User where x.Email.Equals(obj.Email) select x).ToList();

            if (dbuser.Count == 0)
            {
                ViewBag.Error = "You arent registered, Register you before!";
                return View("Register");
            }
            else
            {
                if (obj.Password!= dbuser[0].Password)
                {
                    ViewBag.Error = "password Wrong";
                    return View("Login", obj);
                }

                Session["Log"] = dbuser[0].Email;
                if (dbuser[0].type == "0")
                {
                    return RedirectToAction("Index", "Home");

                }
              
                return View("Login", obj);

            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}