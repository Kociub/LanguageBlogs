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
            ISchedulerFactory scheduleFactory = new StdSchedulerFactory();

            // Get a scheduler
            IScheduler sched = scheduleFactory.GetScheduler();
            sched.Start();

            // Define the job and tie it the UpdateJob class
            IJobDetail job = JobBuilder.Create<UpdateJob>()
                .WithIdentity("updateJob", "updateGroup")
                .Build();

            Action<SimpleScheduleBuilder> schedule = null;
            DateTimeOffset startAt = new DateTimeOffset();

            #if DEBUG
                schedule = x => x.WithIntervalInMinutes(1).WithRepeatCount(1);
                startAt = new DateTimeOffset(DateTime.Now.AddSeconds(10));
            #else
                schedule = x => x.WithIntervalInHours(12).RepeatForever();
                startAt = new DateTimeOffset(DateTime.Now.AddSeconds(60));
            #endif

            // Create a trigger
            ITrigger trigger = TriggerBuilder.Create()
              .WithIdentity("updateTrigger", "updateGroup")
              .StartAt(startAt)
              .WithSimpleSchedule(schedule)
              .Build();

            sched.ScheduleJob(job, trigger);
        }
    }
}
