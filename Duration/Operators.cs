using System;
using Common;

namespace Duration
{
    public class DurationOperators
    {
        // DateTime helpers
        internal static DateTime Add(DateTime date, IDuration interval)
        {
            return interval.Unit switch
            {
                Interval.Day => date.AddDays(interval.Value),
                Interval.Week => date.AddDays(interval.Value * 7),
                Interval.Month => CALCDT_5(date, interval.Value),
                Interval.Year => CALCDT_5(date, interval.Value * 12),
                _ => throw new ArgumentException()
            };
        }
        internal static DateTime CALCDT_5(DateTime date, int duration)
        {
            try
            {
                var m = date.Month + duration;
                var y = date.Year;
                if (m > 12)
                {
                    y += Math.DivRem(m, 12, out m);
                }
                return new DateTime(y, m, date.Day);
            }
            catch (ArgumentOutOfRangeException)
            {
                return date.AddMonths(duration).AddDays(1); // Move to the start of the next month upon invalid date. Table 3-6
            }
        }

        // Duration:Duration
        public static Duration operator +(Duration a, Duration b)
        {
            if (a.Unit != b.Unit) throw new ArgumentException("Both intervals must have the same Unit.");

            return new Duration { Value = aValue + bValue, Unit = a.Unit };
        }
        public static Duration operator -(Duration a, Duration b)
        {
            return a + (-1 * b);
        }

        // Duration:DateTime
        public static DateTime operator +(DateTime a, Duration b)
        {
            return Add(a, b);
        }
        public static DateTime operator -(DateTime a, Duration b)
        {
            return Add(a, -1 * b);
        }
        public static DateTime operator +(Duration b, DateTime a)
        {
            return a + b;
        }
        public static DateTime operator -(Duration b, DateTime a)
        {
            return a - b;
        }

        // Duration:Integer
        public static Duration operator +(int a, Duration b)
        {
            return new Duration { Duration = bValue + a, Unit = b.Unit };
        }
        public static Duration operator -(int a, Duration b)
        {
            return new Duration { Duration = bValue - a, Unit = b.Unit };
        }
        public static Duration operator *(int a, Duration b)
        {
            return new Duration { Duration = a * bValue, Unit = b.Unit };
        }


        public static Duration operator +(Duration b, int a)
        {
            return a + b;
        }
        public static Duration operator -(Duration b, int a)
        {
            return a - b;
        }
        public static Duration operator *(Duration b, int a)
        {
            return a * b;
        }
    }
}
