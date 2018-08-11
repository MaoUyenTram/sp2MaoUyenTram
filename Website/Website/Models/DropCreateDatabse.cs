using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class DropCreateDatabse:DropCreateDatabaseIfModelChanges<WebsiteContext>
    {
        protected override void Seed(WebsiteContext context)
        {
            base.Seed(context);
            //context.Users.Add(new Users{"10", "bla","bla", false });
            context.SaveChanges();
        }
    }
}