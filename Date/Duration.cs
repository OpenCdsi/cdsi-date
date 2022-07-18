using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCdsi.Date
{
    public readonly partial struct Duration : IEqualityComparer<Duration>
    {
        private static readonly Duration _max = new() { Values = new[] { new Interval { Value = 2999, Unit = IntervalUnit.Year } } };

        private static readonly Duration _empty = new() { Values = new[] { new Interval { Value = 0, Unit = IntervalUnit.Day } } };
        public static Duration MinValue => _empty;
        public static Duration MaxValue => _max;
        public readonly Interval[] Values { get; init; }

        public bool Equals(Duration x, Duration y)
        {
            var a = MaxCdsiDate.Value + x;
            var b = MaxCdsiDate.Value + y;
            return a.Equals(b);
        }

        public int GetHashCode([DisallowNull] Duration obj)
        {
            return obj.GetHashCode();
        }
    }

    public class DurationComparer : IComparer<Duration>
    {
        public int Compare(Duration x, Duration y)
        {
            var a = MaxCdsiDate.Value + x;
            var b = MaxCdsiDate.Value + y;
            return a.CompareTo(b);
        }
    }
}
