using OpenCdsi.Date;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCdsi.Date.Tests
{
    internal static class Defaults
    {
        public static Interval Day => new() { Unit = IntervalUnit.Day, Value = 1 };
        public static Interval Week => new() { Unit = IntervalUnit.Week, Value = 1 };
        public static Interval Month => new() { Unit = IntervalUnit.Month, Value = 1 };
        public static Interval Year => new() { Unit = IntervalUnit.Year, Value = 1 };
    }
}
