using LanguageBlogs.Models;
using System;
using System.Data.Entity;
namespace LanguageBlogs.DAL
{
    public interface IBlogsContext
    {
        IDbSet<Blog> Blogs { get; set; }
        IDbSet<Post> Posts { get; set; }
    }
}
