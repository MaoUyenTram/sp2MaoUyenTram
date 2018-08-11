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
            // src = https://stackoverflow.com/questions/51802370/the-navigation-property-uid-is-not-a-declared-property-on-type-users
            modelBuilder.Entity<Answers>().HasRequired(a => a.Questions).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<QAnswers>().HasRequired(a => a.Questions).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<QAnswers>().HasRequired(a => a.Answers).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<QAnswers>().HasRequired(a => a.Users).WithMany().WillCascadeOnDelete(false);
        }
    }
}