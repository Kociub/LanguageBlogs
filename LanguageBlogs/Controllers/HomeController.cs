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
        public ActionResult Index()
        {
            var blog = new Blog()
            {
                Title = "Jakub Kociubinski",
                Description = "Test Blog Entry",
                Link = @"http://blog.kociub.com",
                Languages = new List<string>() { "pl", "en" },
                Posts = new List<Post>
                {
                    new Post()
                    {
                        Title = "Test Post 1",
                        Preview = "This is a test post preview" 
                    },
                    new Post()
                    {
                        Title = "Test Post 2",
                        Preview = "This is a second test post preview"
                    },
                    new Post()
                    {
                        Title = "Test Post 3",
                        Preview = "This is a third test post preview"
                    }
                }
            };

            List<Blog> blogs = new List<Blog>();
            blogs.Add(blog);

            return View(blogs);
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