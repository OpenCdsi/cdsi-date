using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCdsi.Date
{
    public readonly partial struct Duration
    {
        private static Duration CreateFromIntervals(List<Interval> values)
        {
            values.Sort(new IntervalComparer());
            return new Duration { Values = values.ToArray() };
        }

        // Duration:Duration
        public static Duration operator +(Duration a, Duration b)
        {
            var values = a.Values.ToList();
            values.AddRange(b.Values);

            return CreateFromIntervals(values);
        }
        public static Duration operator -(Duration a, Duration b)
        {
            return a + (-b);
        }
        public static Duration operator -(Duration a)
        {
            return a * -1;
        }
        public static Duration operator *(Duration a, int b)
        {
            var values = a.Values.Select(x => b * x).ToList();

            return CreateFromIntervals(values);
        }
        public static Duration operator *(int b, Duration a)
        {
            return a * b;
        }
        public static Duration operator /(Duration a, int b)
        {
            var values = a.Values.Select(x => x / b).ToList();

            return CreateFromIntervals(values);
        }


        // DateTime:Duration
        public static DateTime operator +(DateTime a, Duration b)
        {
            return a.Add(b.Values);
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
