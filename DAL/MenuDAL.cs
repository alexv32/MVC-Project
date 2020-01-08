using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Project.Models;
namespace Project.DAL
{
    public class MenuDAL:DbContext
    {

        //data access layer for the menu database
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Menu>().ToTable("Menu");
        }
        public DbSet<Menu> Dishes { get; set; }
    }
}
