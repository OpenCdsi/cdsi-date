using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace DateMath.UnitTests
{
    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        public void CanParseAnInterval()
        {
            var text = "6 years";
            var duration = Duration.Parse(text).First();
            Assert.AreEqual(6, duration.Value);
            Assert.AreEqual(Interval.Year, duration.Unit);
        }
        [TestMethod]
        public void CanParseAnIntervalWithJunkText()
        {
            var text = "6 years plus some  bogus data";
            var duration = Duration.Parse(text).First();
            Assert.AreEqual(6, duration.Value);
            Assert.AreEqual(Interval.Year, duration.Unit);
        }

        [TestMethod]
        public void CanParseMultipleIntervals()
        {
            var text = "6 years - 4 days";
            var intervals = Duration.Parse(text);
            Assert.AreEqual(6, intervals.First().Value);
            Assert.AreEqual(Interval.Day, intervals.ElementAt(1).Unit);
        }
    }
}

