using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibaryManagment.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index(int id)
        {
            using (Models.LibraryContext ctx = new Models.LibraryContext())
            {
                var error = ctx.Errors.Where(e => e.ID.Equals(id)).FirstOrDefault();
                if (error != null)
                    return View(error);
                else
                    return RedirectToAction("Index" , "Users");
            }
            
        }
    }
}