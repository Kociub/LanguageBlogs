using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;
using System.Xml;

namespace LanguageBlogs.Models
{
    public class Blog
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string RssLink { get; set; }
        public virtual ICollection<string> Languages { get; set; }
        public virtual ICollection<Post> Posts { get; set; }

        public Blog()
        {
            Posts = new List<Post>();
            Languages = new List<string>();
        }

        public void UpdatePosts(SyndicationFeed feed, int maxPostsNumber)
        {
            if (feed != null && feed.Items != null && Posts != null)
            {
                foreach (SyndicationItem item in feed.Items.Take(maxPostsNumber))
                {
                    Posts.Add(new Post
                    {
                        Title = item.Title.Text,
                        Preview = item.Summary.Text,
                        Link = item.Links.First().Uri.ToString()
                    });
                }
            }
        }

        internal void ClearPosts()
        {
            Posts.Clear();
        }
    }
}