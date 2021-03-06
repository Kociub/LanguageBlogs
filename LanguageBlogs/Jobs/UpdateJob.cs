﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using LanguageBlogs.DAL;
using LanguageBlogs.Models;
using LanguageBlogs.RSS;
using System.ServiceModel.Syndication;
using System.Data.Entity;

namespace LanguageBlogs.Jobs
{
    public class UpdateJob : IJob
    {
        private BlogsContext blogsContext = new BlogsContext();

        public void Execute(IJobExecutionContext context)
        {
            UpdateDatabase(blogsContext);
        }

        public void UpdateDatabase(BlogsContext db)
        {
            var blogs = db.Blogs.Include(x => x.Posts);

            Logging.Log.Info("Starting update job");

            if (blogs != null)
            {
                foreach (Blog blog in blogs)
                {
                    SyndicationFeed feed = FeedService.GetFeed(blog.RssLink);

                    Logging.Log.Info(String.Format("Updating blog {0}",blog.Title));

                    blog.ClearPosts();

                    blog.UpdatePosts(feed, 3);
                }

                db.SaveChanges();
            }

            Logging.Log.Info("Finished update job");
        }
    }
}