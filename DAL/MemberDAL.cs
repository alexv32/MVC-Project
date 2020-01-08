using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Models;
using System.Data.Entity;

namespace Project.DAL
{
    public class MemberDAL :DbContext
    {
        //data access layer for the member database
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Member>().ToTable("Members");
        }
        public DbSet<Member> Members { get; set; }
    }
}