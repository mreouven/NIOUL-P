using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication3.Models;

namespace WebApplication3.DAL
{
    public class RecipesDal:DbContext
    {
        public DbSet<Recipes> Recipes { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Recipes>().ToTable("tblReceip");
        }

        public System.Data.Entity.DbSet<WebApplication3.Models.Users> Users { get; set; }
    }
}