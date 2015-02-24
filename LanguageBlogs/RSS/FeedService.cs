using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;
using System.Xml;

namespace LanguageBlogs.RSS
{
    public class FeedService
    {
        public static SyndicationFeed GetFeed(string link)
        {
            SyndicationFeed feed = null;

            using (XmlReader reader = XmlReader.Create(link))
            {
                feed = SyndicationFeed.Load(reader);
            }

            return feed;
        }
    }
}