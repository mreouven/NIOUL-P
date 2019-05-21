using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.DAL;
using WebApplication3.Models;

namespace WebApplication3.CVM
{
    public class RecipeComCVM
    {
       public Recipes recipes { get; set; }
        public List<Comment>comments { get; set; }


        public RecipeComCVM(string idRecipes)
        {
            RecipesDal recipesDal = new RecipesDal();
            CommentDal commentDal = new CommentDal();
            List<Recipes> food = (from x in recipesDal.Recipes where x.Id.Equals(idRecipes) select x).ToList();
            if (food.Count > 0)
                recipes = food[0];
            else recipes = null;
            comments = (from x in commentDal.Comments where x.idReceips.Equals(idRecipes) orderby x.date select x).ToList();


        }
        
    }
}