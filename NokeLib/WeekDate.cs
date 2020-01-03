using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace NokeLib
{
    // ISO-8601, Monday is the first day of week
    public class WeekDate
    {
        CultureInfo culture = new CultureInfo("en-US");
        private readonly int year;
        private readonly int week;
        private int weeksOfYear;
        public DateTime FirstDay { get; set; }
        public DateTime LastDay { get; set; }

        private WeekDate() { }
        public WeekDate(int year, int week)
        {
            this.year = year;
            this.week = week;
            GetWeekFirstLastDay();
        }
        private void GetWeekFirstLastDay()
        {

            var firstOfThisYear = new DateTime(year, 1, 1);
            var dayOfWeekOfThisYear = culture.Calendar.GetDayOfWeek(firstOfThisYear);
            var isThur = dayOfWeekOfThisYear == DayOfWeek.Thursday;
            var isLeapAndWed = DateTime.DaysInMonth(year, 2) == 29 && dayOfWeekOfThisYear == DayOfWeek.Wednesday;
            if (isThur || isLeapAndWed)
            {
                weeksOfYear = 53;
            }
            else
            {
                weeksOfYear = 52;
            }

            if (isLastYearLeapAndWed())
            {
                FirstDay = firstOfThisYear.AddDays(week * 7 - (int)dayOfWeekOfThisYear + 1);
            }
            else
            {
                FirstDay = firstOfThisYear.AddDays((week - 1) * 7 - (int)dayOfWeekOfThisYear + 1);
            }

            CheckWeekOutRange();
            LastDay = FirstDay.AddDays(7);
        }
        private void CheckWeekOutRange()
        {
            if (week < 1 || week > weeksOfYear)
            {
                throw new ArgumentOutOfRangeException("超出該年的周數");
            }
        }

        private bool isLastYearLeapAndWed()
        {
            var firstOfLastYear = new DateTime(year - 1, 1, 1);
            var isLeap = DateTime.DaysInMonth(year - 1, 2) == 29;
            var isFirstOnWed = culture.Calendar.GetDayOfWeek(firstOfLastYear) == DayOfWeek.Wednesday;
            return isLeap && isFirstOnWed;
        }

        public static WeekDate GetRangeDate(int yearStart, int weekStart, int yearEnd, int weekEnd)
        {
            var week1 = new WeekDate(yearStart, weekStart);
            var week2 = new WeekDate(yearEnd, weekEnd);
            var weekRange = new WeekDate();
            weekRange.FirstDay = week1.FirstDay;
            weekRange.LastDay = week2.LastDay;
            return weekRange;
        }
    }
}
