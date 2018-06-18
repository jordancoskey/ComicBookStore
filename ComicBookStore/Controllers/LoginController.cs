using ComicBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace ComicBookStore.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Login(User user, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {

                if (user.IsUserExist(user.Username,/*Crypto.HashPassword(user.Password)*/user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.Username, true);
                    Session["curUser"] = user;
                    if (user.IsAdmin(user.Username,/*Crypto.HashPassword(user.Password)*/user.Password))
                    {
                        user.Admin = true;
                        Session["curUser"] = user;
                    }
                    return Redirect(ReturnUrl);
                }
                else
                {
                    return View(user);
                }
            }
            return View();
        }
        [Authorize]
        public ActionResult Logout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Home");
           
        }

       

    }
} 