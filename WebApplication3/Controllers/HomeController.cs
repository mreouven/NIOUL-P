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
            return View();
        }


        public ActionResult CheckLogin(Users obj)
        {
            UsersDal udal = new UsersDal();
            List<Users> dbuser = (from x in udal.User where x.Email.Equals(obj.Email) select x).ToList();

            if (dbuser.Count == 0)
            {
                ViewBag.Error = "You arent registered, Register you before!";
                return View("Register");
            }
            else
            {
                if (!Hashing.ValidatePassword(obj.Password, dbuser[0].Password))
                {
                    ViewBag.Error = "password Wrong";
                    return View("Login", obj);
                }

                Session["idlog"] = dbuser[0].Email;
                Session["Log"] = dbuser[0].type;
                if (dbuser[0].type == "0")
                {
                    return RedirectToAction("Choice", "Customer");

                }
                if (dbuser[0].type == "1")
                {
                    return RedirectToAction("ChoiceFood", "Admin");
                }
                if (dbuser[0].type == "2")
                {
                    return RedirectToAction("ChoiceServices", "Admin");
                }
                if (dbuser[0].type == "3")
                {
                    return RedirectToAction("ChoiceResponsable", "Admin");

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