using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OpenCdsi.Date
{
    public readonly partial struct Interval : IEqualityComparer<Interval>
    {
        private static readonly Interval _empty = new() { Value = 0, Unit = IntervalUnit.Day };
        public static Interval Empty => _empty;

        public int Value { get; init; }
        public IntervalUnit Unit { get; init; }

        public bool Equals(Interval x, Interval y)
        {
            var a = MaxCdsiDate.Value + x;
            var b = MaxCdsiDate.Value + y;
            return a.Equals(b);
        }

        public int GetHashCode([DisallowNull] Interval obj)
        {
            return obj.GetHashCode();
        }
    }

    public class IntervalComparer : IComparer<Interval>
    {
        public int Compare(Interval x, Interval y)
        {
            var a = MaxCdsiDate.Value + x;
            var b = MaxCdsiDate.Value + y;
            return a.CompareTo(b);
        }
    }

    public class IntervalUnitComparer : IComparer<Interval>
    {
        public int Compare(Interval x, Interval y)
        {
           return x.Unit.CompareTo(y.Unit);
        }
    }
}
