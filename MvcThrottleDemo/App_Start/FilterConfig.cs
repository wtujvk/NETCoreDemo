using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcThrottle;
using MvcThrottleDemo.Codes;

namespace MvcThrottleDemo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            var throttleFilter = new ThrottlingFilter
            {
                Policy = new ThrottlePolicy(perSecond: AppDataInit.PerSecond, perMinute: AppDataInit.PerMinute, perHour: AppDataInit.PerHour, perDay: AppDataInit.PerDay)
                {
                    IpThrottling = true
                },
                Repository = new CacheRepository()
            };

            filters.Add(throttleFilter);
        }
    }
}