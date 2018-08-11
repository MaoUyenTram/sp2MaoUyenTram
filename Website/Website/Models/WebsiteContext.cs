using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class WebsiteContext : DbContext
    {
        public WebsiteContext() : base("Database1")
        {

        }

        public DbSet<Users> Users{ get; set;}
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Answers> Answers { get; set; }
        public DbSet<QAnswers> QAnswers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QAnswers>().HasKey(x => new { x.QId, x.AId, x.UId });
            //modelBuilder.Entity<Users>().HasKey(u => u.UId);
            //modelBuilder.Entity<Answers>().HasRequired(x => x.AId).WithMany().WillCascadeOnDelete(false);
            //modelBuilder.Entity<Questions>().HasRequired(x => x.QId).WithMany().WillCascadeOnDelete(false);
        }
    }
}