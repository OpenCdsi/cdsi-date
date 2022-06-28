using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Cdsi
{
    public static class DureationExt
    {
        /// <summary>
        /// Add a list of durations to a date. Order the intervals by Year, Month, Week, Day.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public static DateTime Add(this DateTime date, IEnumerable<IDuration> intervals)
        {
            var durationList = intervals.ToList();
            durationList.Sort(new DurationComparer());
            foreach (var duration in durationList)
            {
                date = Duration.Add(date, duration);
            }
            return date;
        }
    }
}
