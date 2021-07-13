using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibaryManagment.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        [HttpGet]
        public ActionResult Index()
        {
            using(Models.LibraryContext ctx =  new Models.LibraryContext())
            {
                var users = ctx.Users.OrderBy(u => u.Surname).ToList();
                return View(users);
            }
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            var name = form["Name"];
            var surname = form["Surname"];
            var email = form["Email"];

            using (Models.LibraryContext ctx = new Models.LibraryContext())
            {
                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname) && !string.IsNullOrEmpty(email))
                {
                    bool active = false;
                    if (form["Active"].Contains("true"))
                        active = true;

                    Models.User user = new Models.User()
                    {
                        Name = form["Name"],
                        Surname = form["Surname"],
                        Email = form["Email"],
                        Active = active,

                    };
                    ctx.Users.Add(user);
                    ctx.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    Models.Error error = new Models.Error()
                    {
                        Timestamp = DateTime.Now,
                        Message = "Info Mancanti, Digitare correttamente"
                    };
                    ctx.Errors.Add(error);
                    ctx.SaveChanges();
                    return RedirectToAction("Index", "Error", new {id = error.ID});
                }
            }
        }

        

        public ActionResult Edit(int id) 
        {
            using (Models.LibraryContext ctx = new Models.LibraryContext())
            {
                var currentUser = ctx.Users.Where(u => u.ID.Equals(id)).FirstOrDefault();
                if (currentUser != null)
                    return View(currentUser);
            }

            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection form)
        {
            using (Models.LibraryContext ctx = new Models.LibraryContext())
            {
                var currentUser = ctx.Users.Where(u => u.ID.Equals(id)).FirstOrDefault();
                if (currentUser != null)
                {
                    currentUser.Name = form["Name"];
                    currentUser.Surname = form["Surname"];
                    currentUser.Email = form["Email"];

                }
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete (int id)
        {
            using (Models.LibraryContext ctx = new Models.LibraryContext())
            {
                var currentUser = ctx.Users.Where(u => u.ID.Equals(id)).FirstOrDefault();
                if (currentUser != null) 
                { 
                    ctx.Users.Remove(currentUser);
                }
                ctx.SaveChanges();
                
            }
            return RedirectToAction("Index");
        }
    }
}