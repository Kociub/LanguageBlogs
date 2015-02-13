using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LanguageBlogs.Models
{
    public class Post
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Preview { get; set; }
    }
}