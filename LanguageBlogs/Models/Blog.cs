using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LanguageBlogs.Models
{
    public class Blog
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public ICollection<string> Languages { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}