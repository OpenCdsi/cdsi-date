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
            return x.Values.Length == y.Values.Length 
                && x.Values.Zip(y.Values).All(xy => xy.First.Equals(xy.Second));
        }

        public int GetHashCode([DisallowNull] Duration obj)
        {
            return obj.Values.GetHashCode();
        }
    }
}
