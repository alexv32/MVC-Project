using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Project.Models;

namespace Project.DAL
{
    
    public class AdminDAL :DbContext
    {
        //data access layer for the admin database
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Manager>().ToTable("Admins");
        }
        public DbSet<Manager> Admins { get; set; }
    }
}