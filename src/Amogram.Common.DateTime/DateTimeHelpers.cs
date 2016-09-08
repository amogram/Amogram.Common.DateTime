using System;

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
    }
}
