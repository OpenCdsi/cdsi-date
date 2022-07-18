using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using OpenCdsi.Date;
using System;

namespace OpenCdsi.Date.Tests
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
        public void CanParseDuration()
        {
            var text = "6 years - 4 days";
            var duration = Duration.Parse(text);
            Assert.AreEqual(6, duration.Values[0].Value);
            Assert.AreEqual(IntervalUnit.Day, duration.Values[1].Unit);
        }

        [TestMethod]
        public void CanParseOutOfOrderDuration()
        {
            var text = "- 4 days + 6 years ";
            var duration = Duration.Parse(text);
            Assert.AreEqual(6, duration.Values[0].Value);
            Assert.AreEqual(IntervalUnit.Day, duration.Values[1].Unit);
        }

        [TestMethod]
        public void ParseIntervalNullStringIsEmpty()
        {
            var text = "";
            Interval.TryParse(text, out var obj);
            Assert.AreEqual(Interval.Empty, obj);
        }

        [TestMethod]
        public void ParseDurationNullStringIsEmpty()
        {
            var text = "";
            Duration.TryParse(text, out var obj);
            Assert.AreEqual(Duration.MinValue, obj);
        }

        [TestMethod]
        public void ParseManyNullStringIsEmpty()
        {
            var text = "";
            Assert.ThrowsException<ArgumentException>(() => Interval.Parse(text));
        }
    }
}

