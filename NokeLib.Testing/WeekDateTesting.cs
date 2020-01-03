using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NokeLib;

namespace NokeLib.Testing
{
    [TestClass]
    public class WeekDateTesting
    {
        [DataRow(2018, 52, "2018/12/24", "2018/12/31")]
        [DataRow(2019, 24, "2019/6/10", "2019/6/17")]
        [DataRow(2019, 25, "2019/6/17", "2019/6/24")]
        [DataRow(2019, 52, "2019/12/23", "2019/12/30")]
        [DataRow(2020, 1, "2019/12/30", "2020/1/6")]
        [DataRow(2020, 53, "2020/12/28", "2021/1/4")]
        [DataRow(2021, 1, "2021/1/4", "2021/1/11")]
        [DataTestMethod]
        public void FirstLastDay(int year, int week, string expectedFirstDay, string expectedLastDay)
        {
            var sut = new WeekDate(year, week);
            Assert.AreEqual(DateTime.Parse(expectedFirstDay), sut.FirstDay);
            Assert.AreEqual(DateTime.Parse(expectedLastDay), sut.LastDay);
        }

        [DataRow(2015, 54)]
        [DataRow(2016, 53)]
        [DataRow(2017, 53)]
        [DataRow(2018, 53)]
        [DataRow(2019, 53)]
        [DataRow(2020, 54)]
        [DataRow(2021, 53)]
        [DataRow(2022, 53)]
        [DataRow(2023, 53)]
        [DataTestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void OutRangeOfWeek(int year, int week)
        {
            var sut = new WeekDate(year, week);
        }

        [DataRow(2019, 1, 2020, 3, "2018/12/31", "2020/1/20")]
        [DataTestMethod]
        public void RangeFirstLastDay(int yearStart, int weekStart, int yearEnd, int weekEnd, string expectedFirstDay, string expectedLastDay)
        {
            var sut = WeekDate.GetRangeDate(yearStart, weekStart, yearEnd, weekEnd);
            Assert.AreEqual(DateTime.Parse(expectedFirstDay), sut.FirstDay);
            Assert.AreEqual(DateTime.Parse(expectedLastDay), sut.LastDay);
        }
    }
}
