using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdsi.Date
{
    public readonly partial struct Duration
    {
        public readonly Interval[] Values { get; init; }

        public static Duration Min => new() { Values = new[] { Defaults.MinInterval } };
        public static Duration Max => new() { Values = new[] { Defaults.MaxInterval } };
        public static Duration Day => new() { Values = new[] { Interval.Day } };
        public static Duration Week => new() { Values = new[] { Interval.Week } };
        public static Duration Month => new() { Values = new[] { Interval.Month } };
        public static Duration Year => new() { Values = new[] { Interval.Year } };
    }
}
