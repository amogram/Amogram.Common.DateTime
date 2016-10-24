using System;
using System.Collections.Generic;
using System.Linq;

namespace Amogram.Common.DateTime
{
    public static class DateTimeHelpers
    {
        /// <summary>
        /// Gets the date for the next day.  If it's today, return today.
        /// </summary>
        /// <param name="from">Today's date</param>
        /// <param name="dayOfWeek">Day of week</param>
        /// <returns>Date of next day</returns>
        public static System.DateTime GetNextOrToday(this System.DateTime from, DayOfWeek dayOfWeek)
        {
            if (from.DayOfWeek == dayOfWeek)
            {
                return from;
            }

            var start = (int)from.DayOfWeek;
            var target = (int)dayOfWeek;

            if (target <= start)
            {
                target += 7;
            }

            return from.AddDays(target - start);
        }

        /// <summary>
        /// Gets the date for the next day.  If today is the day, get the next date of the day.
        /// </summary>
        /// <param name="from">Today's date</param>
        /// <param name="dayOfWeek">Day of week</param>
        /// <returns>Date of next day</returns>
        public static System.DateTime GetNext(this System.DateTime from, DayOfWeek dayOfWeek)
        {
            var start = (int)from.DayOfWeek;
            var target = (int)dayOfWeek;

            if (target <= start)
            {
                target += 7;
            }

            return from.AddDays(target - start);
        }

        /// <summary>
        /// Gets the next upcoming date from a collection of dates.  
        /// If there are no dates in the list, or there are no 
        /// upcoming dates, return null.
        /// If the next upcoming date is today, return today.
        /// Note: Time is not considered
        /// </summary>
        /// <param name="dates">Collection of Dates</param>
        /// <param name="givenDate"></param>
        /// <returns></returns>
        public static System.DateTime? GetNextOrToday(this IEnumerable<System.DateTime> dates, System.DateTime givenDate)
        {
            var dateTimes = dates as System.DateTime[] ?? dates.ToArray();

            if (!dateTimes.Any())
            {
                return null;
            }

            var nextDates = dateTimes.Where(x => x.Date >= givenDate.Date).OrderBy(x => x.Date);

            if (nextDates.Any())
            {
                return nextDates.First();
            }

            return null;
        }
    }
}
