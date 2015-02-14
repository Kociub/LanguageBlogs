using LanguageBlogs.Models;
using System;
using System.Data.Entity;
namespace LanguageBlogs.DAL
{
    public interface IBlogsContext
    {
        DbSet<Blog> Blogs { get; set; }
        DbSet<Post> Posts { get; set; }
    }
}
