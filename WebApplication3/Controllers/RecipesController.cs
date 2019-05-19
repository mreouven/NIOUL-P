using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.DAL;
using WebApplication3.Models;
using WebApplication3.CVM;


namespace WebApplication3.Controllers
{
    public class RecipesController : Controller
    {

        // GET: Recipes
        public ActionResult Index()
        {
            string test = "reouven:34&demenagement:43&eazek:4";
            string[] split = test.Split('&');
            return View();
        }
        public ActionResult Receips()
        {
            return View();

        }
        public JsonResult sendReceipt()
        {
           
            return Json(new RecipesDal().Recipes.ToList<Recipes>(), JsonRequestBehavior.AllowGet);

        }
        public ActionResult CommentGestion()
        {
            
            return View();
        }
        public JsonResult getALLComment()
        {

            return Json(new CommentDal().Comments.ToList<Comment>(), JsonRequestBehavior.AllowGet);

        }
        public ActionResult DeleteComment()
        {
            if (Session["Log"] == null)
            {
                ViewBag.Error = "not logged";
                return View("~/Views/Home/NotLogged.cshtml");
            }
            
                CommentDal ud = new CommentDal();
                Comment test = new Comment()
                {
                    id = Request.Form["id"].ToString()

                };
                var customer = ud.Comments.Single(o => o.id == test.id);

                ud.Comments.Remove(customer);
                ud.SaveChanges();
            
            return null;
        }

        public ActionResult DeleteReceipt()
        {
            if (Session["Log"] == null)
            {
                ViewBag.Error = "not logged";
                return View("~/Views/Home/NotLogged.cshtml");
            }

            RecipesDal ud = new RecipesDal();
            Recipes test = new Recipes()
            {
                 Id= Request.Form["id"].ToString()

            };
            var customer = ud.Recipes.Single(o => o.Id == test.Id);

            ud.Recipes.Remove(customer);
            ud.SaveChanges();

            return null;
        }



        public ActionResult printRecipes(Recipes test)
        {
            string id = HttpContext.Request.Params.Get("id");
            if (id == null)
            {
                ViewBag.error = "id not Found";
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                RecipeComCVM recipeComCVM = new RecipeComCVM(id);

                if(recipeComCVM.recipes==null)
                    return View("~/Views/Shared/Error.cshtml");

                return View(recipeComCVM);
                 //return Json(dbuser, JsonRequestBehavior.AllowGet);

            }
            
        }
        public JsonResult getComment()
        {
            Comment comment=new Comment();
            comment.email = Request.Form["email"];
            comment.message= Request.Form["message"];
            comment.date = DateTime.Now;
            comment.idReceips= Request.Form["recipesId"];
            comment.id = Hashing.HashPassword(new Random().Next(12023, 132023).ToString());
            CommentDal commentDal = new CommentDal();
            commentDal.Comments.Add(comment);
            commentDal.SaveChanges();
            return Json(new { statut = true }, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult addRecipe(Recipes test)
        {
            if (Session["Log"] == null)
            {
                    return RedirectToAction("Login", "Home");
                
            }
            else
            {
                if (Request.Form["nameingredient[]"] != null)
                {
                    test.user = Session["Log"].ToString();
                    test.Id = Hashing.HashPassword(test.Name);
                    string ingredient = "";
                    string[] namei = Request.Form["nameingredient[]"].Split(',');
                    string[] quantite = Request.Form["quantiteingredient[]"].Split(',');
                    for (int i = 0; i < namei.Length; i++)
                    {
                        ingredient += namei[i] + ':' + quantite[i];
                        if ((i + 1) != namei.Length)
                            ingredient += '&';
                    }
                    test.ingredients = ingredient;
                    test.difficulty = Request.Form["rating"];
                    RecipesDal recipesDal = new RecipesDal();
                    recipesDal.Recipes.Add(test);
                    recipesDal.SaveChanges();
                }

                List<Object> listeDesRestos = new List<Object>
            {
                new { Id = "Cake", Nom = "Cake" },
                new { Id = "Entery", Nom = "Entery" },
                new { Id = "Repas", Nom = "Repas" },
                new { Id = "Dessert", Nom = "Dessert" },
            };

                ViewBag.Type = new SelectList(listeDesRestos, "Id", "Nom");

                var a = Request.Form["nameingredient[]"];
                return View(test);
            }
        }
    }
}