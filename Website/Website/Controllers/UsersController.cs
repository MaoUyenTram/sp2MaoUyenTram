using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Website.Models;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using System.Text;
using System.Security.Cryptography;
using static Website.Global;

namespace Website.Controllers
{
    public class UsersController : Controller
    {
        IAuthenticationManager Authentication
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }
        private WebsiteContext db = new WebsiteContext();


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        // GET: Login
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        // src = https://stackoverflow.com/questions/11367727/how-can-i-sha512-a-string-in-c
        public String GetHashCode(String text)
        {
            byte[] hash;
            var data = Encoding.UTF8.GetBytes(text);
            using (SHA512 shaM = new SHA512Managed())
            {
                hash = shaM.ComputeHash(data);
            }
            text = BitConverter.ToString(hash).Replace("-", "");
            
            return text.ToLower();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Users g, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                g.Psw = GetHashCode(g.Psw);
                if (db.Users.Where(m => m.UId.Equals(g.UId) && m.Psw.Equals(g.Psw) && true == m.Teacher).Count() > 0)
                {
                    //HttpContext.Session.Add("uid",g.UId);
                    var identity = new ClaimsIdentity(new[] {
                            new Claim(ClaimTypes.Name, g.UId),
                        },
                        DefaultAuthenticationTypes.ApplicationCookie,
                        ClaimTypes.Name, ClaimTypes.Role);

                    Authentication.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, identity);

                    return RedirectToAction("Index", "Questions");
                }
            }



            return View("Login");
        }

        public ActionResult Logout()
        {
            Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login");
        }

    }
}

