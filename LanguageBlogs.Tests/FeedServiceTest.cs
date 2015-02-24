using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LanguageBlogs.RSS;

namespace LangBlogs.Tests
{
    [TestClass]
    public class FeedServiceTest
    {
        private string googleNewsFeed = @"http://news.google.com/?output=rss";

        [TestMethod]
        public void GetSyndicationFeedTest()
        {
            var testFeed = FeedService.GetFeed(googleNewsFeed);

            Assert.IsNotNull(testFeed.Title);

            Assert.IsNotNull(testFeed.Description);

            Assert.AreNotEqual(0, testFeed.Links.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(System.IO.FileNotFoundException))]
        public void GetSyndicationFeedBrokenLinkTest()
        {
            FeedService.GetFeed("jdaijida");
        }

        [TestMethod]
        [ExpectedException(typeof(System.Xml.XmlException))]
        public void GetSyndicationFeedLinkNotFeedTest()
        {
            FeedService.GetFeed(@"http://google.com");
        }
    }
}
