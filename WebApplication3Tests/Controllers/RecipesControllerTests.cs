using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication3.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication3.Models;
using WebApplication3.DAL;
using WebApplication3.CVM;

namespace WebApplication3.Controllers.Tests
{
    [TestClass()]
    public class RecipesControllerTests
    {
       
        [TestMethod()]
        public void getCommentTest()
        {
            RecipesController recipes = new RecipesController();
            Comment comment = new Comment();
            
            comment.date = DateTime.Now;
     
            comment.id = Hashing.HashPassword(new Random().Next(12023, 132023).ToString());
            CommentDal commentDal = new CommentDal();
 
  
            Assert.IsNotNull(commentDal);
        }

        [TestMethod()]
        public void printRecipesTest()
        {
            RecipesDal recipeComCVM = new RecipesDal();
            Assert.IsNotNull(recipeComCVM);
        }
        [TestMethod()]
        public void e()
        {
            RecipesDal recipeComCVM = new RecipesDal();
            Assert.IsNotNull(recipeComCVM);
        }

    }
}