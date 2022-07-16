using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdsi.Date
{
    public readonly partial struct Duration
    {
        // Duration:Duration
        public static Duration operator +(Duration a, Duration b)
        {
            var values = new List<Interval>(a.Values);
            values.AddRange(b.Values);
            values.Sort(new IntervalComparer());

            return new Duration { Values = values.ToArray() };
        }
        public static Duration operator -(Duration a, Duration b)
        {
            return a + (-b);
        }
        public static Duration operator -(Duration a)
        {
            var values = new List<Interval>(a.Values.Select(x => -1 * x));
            values.Sort(new IntervalComparer());

            return new Duration { Values = values.ToArray() };
        }


        // DateTime:Duration
        public static DateTime operator +(DateTime a, Duration b)
        {
            return a.Add(b.Values).Clamp();
        }

        public static DateTime operator +(Duration b, DateTime a)
        {
            return a + b;
        }

        public static DateTime operator -(DateTime a, Duration b)
        {
            return a + (-b);
        }

        public static DateTime operator -(Duration b, DateTime a)
        {
            return a - b;
        }
    }
}
