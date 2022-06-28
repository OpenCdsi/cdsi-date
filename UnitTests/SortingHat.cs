using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Cdsi;
using System.Collections.Generic;


namespace Cdsi.CalcDt.Tests
{
    [TestClass]
    public class SortingTests
    {
        internal List<IDuration> SameUnitList()
        {
            return new List<IDuration> { Duration.Create(12, Interval.Year), Duration.Create(1, Interval.Year) };
        }
        internal List<IDuration> DifferentUnitList()
        {
            return new List<IDuration> { Duration.Create(12, Interval.Year), Duration.Create(1, Interval.Week) };
        }

        [TestMethod]
        public void SortYears()
        {
            var durations = SameUnitList();
            var smallest = durations.Last();
            durations.Sort(new DurationComparer());
            Assert.AreEqual(smallest, durations.First());
        }

        [TestMethod]
        public void SortDurations()
        {
            var durations = DifferentUnitList();
            var smallest = durations.Last();
            durations.Sort(new DurationComparer());
            Assert.AreEqual(smallest, durations.First());
        }
    }
}
