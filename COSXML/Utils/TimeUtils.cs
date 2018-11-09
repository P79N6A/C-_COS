using System;
using System.Collections.Generic;

using System.Text;
/**
* Copyright (c) 2018 Tencent Cloud. All rights reserved.
* 11/6/2018 10:03:00 AM
* bradyxiao
*/
namespace COSXML.Utils
{
    public sealed class TimeUtils
    {

        public static long GetCurrentTime(TimeUnit timeUnit)
        {
            TimeSpan timeSpan = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            long result = -1L;
            switch (timeUnit)
            {
                case TimeUnit.DAYS:
                    result = (long)timeSpan.TotalDays;
                    break;
                case TimeUnit.HOURS:
                    result = (long)timeSpan.TotalHours;
                    break;
                case TimeUnit.MINUTES:
                    result = (long)timeSpan.TotalMinutes;
                    break;
                case TimeUnit.SECONDS:
                    result = (long)timeSpan.Seconds;
                    break;
                case TimeUnit.MILLISECONDS:
                    result = (long)timeSpan.Milliseconds;
                    break;
                default:
                    break;
            }
            return result;
        }  
    }

    public enum TimeUnit
    {
        MILLISECONDS = 0,
        SECONDS,
        MINUTES,
        HOURS,
        DAYS,
    }
}
