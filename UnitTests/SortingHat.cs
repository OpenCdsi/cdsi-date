using Cdsi.Date;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;


namespace Cdsi.CalcDt.Tests
{
    [TestClass]
    public class SortingTests
    {
        internal List<Interval> SameUnitList()
        {
            return new List<Interval> { Interval.Year * 12, Interval.Year };
        }
        internal List<Interval> DifferentUnitList()
        {
            return new List<Interval> { Interval.Year, Interval.Week };
        }

        [TestMethod]
        public void SortYears()
        {
            var Intervals = SameUnitList();
            Intervals.Sort(new IntervalComparer());
            Assert.AreEqual(1, Intervals.First().Value);
        }

        [TestMethod]
        public void SortIntervals()
        {
            var Intervals = DifferentUnitList();
            Intervals.Sort(new IntervalComparer());
            Assert.AreEqual(IntervalUnit.Year, Intervals.First().Unit);
        }
    }
}
