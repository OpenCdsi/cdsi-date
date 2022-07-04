using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Cdsi;

namespace Cdsi.CalcDt.Tests
{
    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        public void CanParseAnInterval()
        {
            var text = "6 years";
            var interval = Interval.Parse(text);
            Assert.AreEqual(6, interval.Value);
            Assert.AreEqual(IntervalUnit.Year, interval.Unit);
        }
        [TestMethod]
        public void CanParseAnIntervalWithJunkText()
        {
            var text = "6 years plus some junk text";
            var interval = Interval.Parse(text);
            Assert.AreEqual(6, interval.Value);
            Assert.AreEqual(IntervalUnit.Year, interval.Unit);
        }

        [TestMethod]
        public void CanParseMultipleIntervals()
        {
            var text = "6 years - 4 days";
            var intervals = Interval.ParseMany(text);
            Assert.AreEqual(6, intervals.First().Value);
            Assert.AreEqual(IntervalUnit.Day, intervals.ElementAt(1).Unit);
        }
    }
}

