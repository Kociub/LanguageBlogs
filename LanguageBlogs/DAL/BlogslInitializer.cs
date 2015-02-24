using LanguageBlogs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LanguageBlogs.DAL
{
    public class BlogsInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<BlogsContext>
    {
        protected override void Seed(BlogsContext context)
        {
            List<Blog> blogs = new List<Blog>
            {
                new Blog()
                {
                    Title = "Test Blog",
                    Description = "Test Blog Entry",
                    Link = @"http://blog.kociub.com",
                    RssLink = @"http://blog.kociub.com/feed/",
                    Languages = new List<string>() { "pl", "en" },
                    Posts = new List<Post>
                    {
                        new Post()
                        {
                            Title = "Test Post 1",
                            Preview = "This is a test post preview",
                            Link = @"http://blog.kociub.com/float-double-and-decimal-in-c/"
                        },
                        new Post()
                        {
                            Title = "Test Post 2",
                            Preview = "This is a second test post preview",
                            Link = @"http://blog.kociub.com/float-double-and-decimal-in-c/"
                        },
                        new Post()
                        {
                            Title = "Test Post 3",
                            Preview = "This is a third test post preview",
                            Link = @"http://blog.kociub.com/float-double-and-decimal-in-c/"
                        }
                    }
                },

                new Blog()
                {
                    Title = "Test Blog 2",
                    Description = "Test Blog Entry 2",
                    Link = @"http://blog.kociub.com",
                    RssLink = @"http://blog.kociub.com/feed/",
                    Languages = new List<string>() { "pl", "en" },
                    Posts = new List<Post>
                    {
                        new Post()
                        {
                            Title = "Test Post 1",
                            Preview = "This is a test post preview" ,
                            Link = @"http://blog.kociub.com/float-double-and-decimal-in-c/"
                        },
                        new Post()
                        {
                            Title = "Test Post 2",
                            Preview = "This is a second test post preview",
                            Link = @"http://blog.kociub.com/float-double-and-decimal-in-c/"
                        },
                        new Post()
                        {
                            Title = "Test Post 3",
                            Preview = "This is a third test post preview",
                            Link = @"http://blog.kociub.com/float-double-and-decimal-in-c/"
                        }
                    }
                }
            };

            blogs.ForEach(s => context.Blogs.Add(s));
            context.SaveChanges();
        }
    }
}