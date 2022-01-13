using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        public void CanParseAnInterval()
        {
            var text = "6 years";
            var interval = Interval.Parse(text);
            Assert.AreEqual(6, interval.Duration);
            Assert.AreEqual(IntervalUnit.Year, interval.Unit);
        }
        [TestMethod]
        public void CanParsetheFirstInterval()
        {
            var text = "6 years plus some bogus data";
            var interval = Interval.Parse(text);
            Assert.AreEqual(6, interval.Duration);
            Assert.AreEqual(IntervalUnit.Year, interval.Unit);
        }

        [TestMethod]
        public void CanParseMultipleIntervals()
        {
            var text = "6 years - 4 days";
            var intervals = Interval.ParseAll(text);
            Assert.AreEqual(6, intervals.First().Duration);
            Assert.AreEqual(IntervalUnit.Day, intervals.Second().Unit);
        }
    }
}

