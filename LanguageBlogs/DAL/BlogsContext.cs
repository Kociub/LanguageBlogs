using LanguageBlogs.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace LanguageBlogs.DAL
{
    public class BlogsContext : DbContext, IBlogsContext
    {
        public BlogsContext()
            : base("BlogsContext")
        {
        }
        
        public IDbSet<Blog> Blogs { get; set; }
        public IDbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}