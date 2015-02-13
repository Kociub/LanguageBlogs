using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LanguageBlogs.Models
{
    public class Blog
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public virtual ICollection<string> Languages { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}