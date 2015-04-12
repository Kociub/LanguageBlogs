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
        private BlogsContext db;

        public HomeController()
        {
            this.db = new BlogsContext();
        }

        //Cache the output for 12 hours
        [OutputCache(Duration = 43200, VaryByParam = "none")]
        public ActionResult Index()
        {
            try
            {
                return View(db.Blogs.ToList());
            }
            catch (Exception e)
            {
                Logging.Log.Error(e.Message);
                throw;
            }
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