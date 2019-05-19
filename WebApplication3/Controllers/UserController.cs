using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.DAL;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class UserController : Controller
    {
        public ActionResult getUsersByJson()
        {
            UsersDal ud = new UsersDal();
            return Json(ud.User.ToList<Users>(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteUsers()
        {
            if (Session["Log"] == null)
            {
                ViewBag.Error = "not logged";
                return View("~/Views/Home/NotLogged.cshtml");
            }
            if (Session["type"].ToString() == "0")
            {
                UsersDal ud = new UsersDal();
                Users test = new Users()
                {
                    Email = Request.Form["Email"].ToString()

                };
                var customer = ud.User.Single(o => o.Email == test.Email);

                ud.User.Remove(customer);
                ud.SaveChanges();
            }
            return null;
        }
        public ActionResult UserData()
        {
            //Session["Log"] = "3";
            if (Session["Log"] == null)
            {
                return RedirectToAction("Login", "Home");

            }

            return View();
        }
        // GET: User
        public ActionResult Gestion(Users req)
        {
            
            if (ModelState.IsValid)
            {
                UsersDal usersDal = new UsersDal();
                string email = Session["Log"].ToString();
                Users connected = usersDal.User.Where(d => d.Email == email).First();
                connected.Email = req.Email;
                connected.First_Name = req.First_Name;
                connected.Last_Name = req.Last_Name;
                connected.Password = req.Password;
                connected.Phone_Number = req.Phone_Number;
                
                //usersDal.User.Add(req);
                //usersDal.Entry(req).State = System.Data.Entity.EntityState.Modified;
                usersDal.SaveChanges();
                  
            }
            if (Session["Log"] == null)
            {
                return RedirectToAction("Login", "Home");

            }
            else
            {
                UsersDal usersDal = new UsersDal();
                string email = Session["Log"].ToString();
                Users connected = usersDal.User.Where(d => d.Email == email).First();

                List<Users> dbuser = (from x in usersDal.User where x.Email.Equals(email) select x).ToList();

                return View(dbuser[0]);
            }
        }
    }
}