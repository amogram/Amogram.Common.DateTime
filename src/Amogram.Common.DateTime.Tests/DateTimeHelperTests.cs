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
        public void GetsNextSundayIfTodayIsSunday()
        {
            var dateTotest = new System.DateTime(2016, 10, 23);

            var expectedNextSunday = new System.DateTime(2016, 10, 30);
            var nextDate = dateTotest.GetNext(DayOfWeek.Sunday);

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

        [Test]
        public void GetNextOrToday_GetsNextDateFromCollection()
        {
            var dates = new[]
            {
                new System.DateTime(2011, 1, 5),
                new System.DateTime(2010, 2, 3),
                new System.DateTime(2018, 12, 12),
                new System.DateTime(2016, 10, 20)
            };

            var givenDate = new System.DateTime(2016, 10, 18);

            var nextDate = dates.GetNextOrToday(givenDate);

            Assert.IsNotNull(nextDate);
            Assert.AreEqual(nextDate.Value.Date, new System.DateTime(2016, 10, 20));
        }

        [Test]
        public void GetNextOrToday_GetsNoDateFromCollection()
        {
            var dates = new[]
            {
                new System.DateTime(2011, 1, 5),
                new System.DateTime(2010, 2, 3),
                new System.DateTime(2012, 12, 12),
                new System.DateTime(2016, 10, 15)
            };

            var givenDate = new System.DateTime(2016, 10, 18);

            var nextDate = dates.GetNextOrToday(givenDate);

            Assert.IsNull(nextDate);
        }

        [Test]
        public void GetNextOrToday_GetsSameDateFromCollection()
        {
            var dates = new[]
            {
                new System.DateTime(2001, 1, 4),
                new System.DateTime(2023, 4, 3),
                new System.DateTime(2018, 12, 18),
                new System.DateTime(2016, 10, 18),
                new System.DateTime(2014, 7, 30)
            };

            var givenDate = new System.DateTime(2016, 10, 18);

            var nextDate = dates.GetNextOrToday(givenDate);

            Assert.IsNotNull(nextDate);
            Assert.AreEqual(nextDate.Value.Date, givenDate.Date);
        }

        [Test]
        public void GetNextOrToday_ReturnsNullIfEmpty()
        {
            System.DateTime[] dates = {};

            var givenDate = new System.DateTime(2016, 10, 18);

            var nextDate = dates.GetNextOrToday(givenDate);

            Assert.IsNull(nextDate);
        }
    }
}
