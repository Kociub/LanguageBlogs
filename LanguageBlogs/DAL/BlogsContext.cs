﻿using LanguageBlogs.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace LanguageBlogs.DAL
{
    public class BlogsContext : DbContext
    {
        public BlogsContext()
            : base("BlogsContext")
        {
        }
        
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
    }
}