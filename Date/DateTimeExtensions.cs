namespace Cdsi.Date
{
    public static class DateTimeExtensions
    {
        public static DateTime Add(this DateTime date, Interval interval)
        {
            return interval.Unit switch
            {
                IntervalUnit.Day => date.AddDays(interval.Value),
                IntervalUnit.Week => date.AddDays(interval.Value * 7),
                IntervalUnit.Month => date.CALCDT_5(interval.Value),
                IntervalUnit.Year => date.CALCDT_5(interval.Value * 12),
                _ => throw new ArgumentException()
            };
        }

        internal static DateTime CALCDT_5(this DateTime date, int Interval)
        {
            try
            {
                var m = date.Month + Interval;
                var y = date.Year;
                if (m > 12)
                {
                    y += Math.DivRem(m, 12, out m);
                }
                return new DateTime(y, m, date.Day);
            }
            catch (ArgumentOutOfRangeException)
            {
                return date.AddMonths(Interval).AddDays(1); // Move to the start of the next month upon invalid date. Table 3-6
            }
        }

        /// <summary>
        /// Add a list of durations to a date. Order the intervals by Year, Month, Week, Day.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public static DateTime Add(this DateTime date, IEnumerable<Interval> intervals)
        {
            var lst = intervals.ToList();
            lst.Sort(new IntervalComparer()); // add years first, then month, week, day.
            foreach (var interval in lst)
            {
                date += interval;
            }
            return date;
        }

        public static DateTime Clamp(this DateTime date)
        {
            if (date < MinDate.Value)
                return MinDate.Value;
            else if (date > MaxDate.Value)
                return MaxDate.Value;
            else
                return date;
        }
    }
}
