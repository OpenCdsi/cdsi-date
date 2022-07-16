using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Cdsi.Date;

namespace Cdsi.Date
{
    public readonly partial struct Interval : IEqualityComparer<Interval>
    {
        public int Value { get; init; }
        public IntervalUnit Unit { get; init; }

        public static  Interval Min => Defaults.MinInterval;
        public static  Interval Max => Defaults.MaxInterval;

        public static Interval Day => new() { Unit = IntervalUnit.Day, Value = 1 };
        public static Interval Week => new() { Unit = IntervalUnit.Week, Value = 1 };
        public static Interval Month => new() { Unit = IntervalUnit.Month, Value = 1 };
        public static Interval Year => new() { Unit = IntervalUnit.Year, Value = 1 };

        public bool Equals(Interval x, Interval y)
        {
            return x.Value.Equals(y.Value) && x.Unit == y.Unit;
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
            if (x.Unit == y.Unit)
            {
                return x.Value.CompareTo(y.Value);
            }
            else
            {
                return x.Unit.CompareTo(y.Unit);
            }
        }
    }
}
