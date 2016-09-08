using System;
using NUnit.Framework;

namespace Amogram.Common.DateTime.Tests
{
    [TestFixture]
    public class DateTimeHelperTests
    {
        [Test]
        public void GetsCorrectSunday()
        {
            var dateTotest = new System.DateTime(2016, 09, 15);

            var expectedNextSunday = new System.DateTime(2016, 09, 18);
            var nextDate = dateTotest.GetNextOrToday(DayOfWeek.Sunday);

            Assert.AreEqual(expectedNextSunday.Date, nextDate.Date);
        }

        [Test]
        public void GetsSameDay()
        {
            var dateTotest = new System.DateTime(2016, 09, 18);

            var expectedNextSunday = new System.DateTime(2016, 09, 18);
            var nextDate = dateTotest.GetNextOrToday(DayOfWeek.Sunday);

            Assert.AreEqual(expectedNextSunday.Date, nextDate.Date);
        }
    }
}
