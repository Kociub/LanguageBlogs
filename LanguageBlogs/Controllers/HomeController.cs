using LanguageBlogs.DAL;
using LanguageBlogs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LanguageBlogs.Controllers
{
    public class HomeController : Controller
    {
        private IBlogsContext db;

        public HomeController()
        {
            this.db = new BlogsContext();
        }

        public HomeController(IBlogsContext db)
        {
            this.db = db;
        }

        public ActionResult Index()
        {
            return View(db.Blogs.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}