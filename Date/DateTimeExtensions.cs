﻿namespace OpenCdsi.Date
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Clamp a DateTime between CDSi MinDate (1/1/1900) and CDSi MaxDate (12/31/2999)
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime Clamp(this DateTime date)
        {
            return date <= Defaults.MinValue
                ? Defaults.MinValue
                : date >= Defaults.MaxValue
                ? Defaults.MaxValue
                : date;
        }
        public static DateTime Add(this DateTime date, CalendarUnit interval)
        {
            return interval.Name switch
            {
                UnitName.Day => date.AddDays(interval.Value),
                UnitName.Week => date.AddDays(interval.Value * 7),
                UnitName.Month => date.CALCDT_5(interval.Value),
                UnitName.Year => date.CALCDT_5(interval.Value * 12),
                _ => throw new ArgumentException()
            };
        }

        internal static DateTime CALCDT_5(this DateTime date, int value)
        {
            try
            {
                var m = date.Month + value;
                var y = date.Year;
                if (m > 12)
                {
                    y += Math.DivRem(m, 12, out m);
                }
                return new DateTime(y, m, date.Day);
            }
            catch (ArgumentOutOfRangeException)
            {
                return date.AddMonths(value).AddDays(1); // Move to the start of the next month upon invalid date. Table 3-6
            }
        }

        /// <summary>
        /// Add a list of calender units to a DateTime.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="components">An enumerable of CalendarUnits sorted by year -> month -> day</param>
        /// <returns></returns>
        public static DateTime Add(this DateTime date, IEnumerable<CalendarUnit> components)
        {
            foreach (var component in components)
            {
                date += component;
            }
            return date;
        }
    }
}
