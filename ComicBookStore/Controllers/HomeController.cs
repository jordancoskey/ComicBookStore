using ComicBookStore.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace ComicBookStore.Controllers
{
    public class HomeController : Controller
    {
        private DataBaseContext db = new DataBaseContext();
        private UserContext dc = new UserContext();
        [Authorize]
        public ActionResult Index()
        {
            
            return View();
        }
        [Authorize]
        public ActionResult ViewComics()
        {
            return View(db.Comics.ToList());
        }
        [Authorize]
        public ActionResult addCartTotal(int? price)
        {
           
                int total = Convert.ToInt32(Session["cartTotal"]);
            total += (int)price;
            Session["cartTotal"] = total;

            return RedirectToAction("ViewComics", "Home");

        }
        [Authorize]
        public ActionResult AddComics()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddComics(Comic model, HttpPostedFileBase image)
        {
            if (image != null)
            {
                model.Cover = new byte[image.ContentLength];
                image.InputStream.Read(model.Cover, 0, image.ContentLength);
             }
           
            db.Comics.Add(model);
            db.SaveChanges();
            return RedirectToAction("ViewComics");

            

        }
        [Authorize]
        public ActionResult EditComics(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            Comic comic = db.Comics.Find(id);
            if (comic==null)
            {
                return HttpNotFound(); 
            }
            return View(comic);
        }
        [HttpPost]
        public ActionResult EditComics(Comic model)
        {
            
            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ViewComics");



        }
        [AllowAnonymous]
        public ActionResult AddUser()
        {

            return View();



        }
        [HttpPost]
        public ActionResult AddUser(User user)
        {
            if (ModelState.IsValid)
            {
                using (UserContext dc = new UserContext())
                {

                    dc.Users.Add(user);
                    dc.SaveChanges();
                }
                ModelState.Clear();
                return RedirectToAction("Index", "Home");
            }
            return View();



        }

        [Authorize]
        public ActionResult EditUser(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }

            User user = dc.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);



        }
        [HttpPost]
        public ActionResult EditUser(User model)
        {

            dc.Entry(model).State = EntityState.Modified;
            dc.SaveChanges();
            return RedirectToAction("ViewUser");



        }






        [Authorize]
        public ActionResult ViewUser()
        {

            return View(dc.Users.ToList());



        }
        
    }
}