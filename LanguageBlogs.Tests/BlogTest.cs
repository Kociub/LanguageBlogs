using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LanguageBlogs.Jobs;
using Moq;
using LanguageBlogs.DAL;
using System.Data.Entity;
using LanguageBlogs.Models;
using System.Collections.Generic;
using Moq.Linq;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Collections;
using System.Globalization;


namespace LangBlogs.Tests
{
    [TestClass]
    public class BlogTest
    {
        Blog testBlog;

        SyndicationFeed feed;

        [TestInitialize]
        public void TestInit()
        {
            testBlog = new Blog()
            {
                Title = "Test Blog",
                Description = "Test Blog Entry",
                Link = @"http://news.google.com/?output=rss",
                RssLink = @"http://news.google.com/?output=rss",
                Languages = new List<string>() { "pl-PL", "en-US" }
            };

            feed = new SyndicationFeed();

            var feeds = new List<SyndicationItem>();

            var syndicationItem = new SyndicationItem("Test Feed Title", "Test Feed Description", new Uri(@"http://google.com/"));

            syndicationItem.Summary = new TextSyndicationContent("Test Feed Summary");

            feeds.Add(syndicationItem);

            feed.Items = feeds as IEnumerable<SyndicationItem>;
        }

        [TestMethod]
        public void UpdateBlogTest() 
        {
            testBlog.UpdatePosts(feed, 3);

            Assert.AreEqual("Test Feed Summary", testBlog.Posts.First().Preview);

            Assert.AreEqual("Test Feed Title", testBlog.Posts.First().Title);

            Assert.AreEqual(@"http://google.com/", testBlog.Posts.First().Link);
        }

        [TestMethod]
        public void UpdateBlogMaxPostTest()
        {
            testBlog.UpdatePosts(feed, -1);

            Assert.AreEqual(0,testBlog.Posts.Count());

            testBlog.UpdatePosts(feed, 0);

            Assert.AreEqual(0, testBlog.Posts.Count());
        }

        [TestMethod]
        public void UpdateBlogFeedNullTest()
        {
            testBlog.UpdatePosts(null, 3);

            Assert.AreEqual(0, testBlog.Posts.Count());
        }


    }
}
