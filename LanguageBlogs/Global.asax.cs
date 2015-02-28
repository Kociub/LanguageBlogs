using LanguageBlogs.Jobs;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace LanguageBlogs
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            InitiateUpdateJob();
        }

        private void InitiateUpdateJob()
        {
            // Construct a scheduler factory
            ISchedulerFactory schedFact = new StdSchedulerFactory();

            // Get a scheduler
            IScheduler sched = schedFact.GetScheduler();
            sched.Start();

            // Define the job and tie it the UpdateJob class
            IJobDetail job = JobBuilder.Create<UpdateJob>()
                .WithIdentity("updateJob", "updateGroup")
                .Build();

            // Create a trigger
            ITrigger trigger = TriggerBuilder.Create()
              .WithIdentity("updateTrigger", "updateGroup")
              .StartAt(new DateTimeOffset(DateTime.Now.AddSeconds(15)))
              .WithSimpleSchedule(x => x
                  .WithIntervalInMinutes(1)
                  .WithRepeatCount(1))
              .Build();

            sched.ScheduleJob(job, trigger);
        }
    }
}
