using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdsi.Date
{
    public readonly partial struct Duration : IEqualityComparer<Duration>
    {
        private static readonly Duration _empty = new() { Values = new[] { new Interval { Value = 0, Unit = IntervalUnit.Day } } };
        public static Duration Empty => _empty;
        public readonly Interval[] Values { get; init; }

        public bool Equals(Duration x, Duration y)
        {
            var a = MaxDate.Value + x;
            var b = MaxDate.Value + y;
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
            var a = MaxDate.Value + x;
            var b = MaxDate.Value + y;
            return a.CompareTo(b);
        }
    }
}
