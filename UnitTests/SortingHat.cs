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
            return new List<Interval> { Defaults.Year * 12, Defaults.Year };
        }
        internal List<Interval> DifferentUnitList()
        {
            return new List<Interval> { Defaults.Year, Defaults.Week };
        }

        [TestMethod]
        public void SortYears()
        {
            var intervals = SameUnitList();
            intervals.Sort(new IntervalComparer());
            Assert.AreEqual(Defaults.Year, intervals.First());
        }

        [TestMethod]
        public void SortIntervals()
        {
            var intervals = DifferentUnitList();
            intervals.Sort(new IntervalComparer());
            Assert.AreEqual(Defaults.Week, intervals.First());
        }
    }
}
