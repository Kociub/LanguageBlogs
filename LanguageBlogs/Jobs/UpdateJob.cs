using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using LanguageBlogs.DAL;
using LanguageBlogs.Models;

namespace LanguageBlogs.Jobs
{
    public class UpdateJob : IJob
    {
        private IBlogsContext blogsContext = new BlogsContext();

        public void Execute(IJobExecutionContext context)
        {

        }
    }
}