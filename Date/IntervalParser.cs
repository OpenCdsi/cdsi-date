using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Cdsi.Date;

namespace Cdsi
{
    public readonly partial struct Interval
    {
        private static readonly Regex re = new("^([\\+-]?\\d+)(\\w+)");

        public static Interval Parse(string str)
        {
            str = str.Replace(" ", "");
            var match = re.Match(str);
            if (match.Success)
            {
                return new()
                {
                    Value = int.Parse(match.Groups[1].Value),
                    Unit = ParseUnit(match.Groups[2].Value)
                };
            }
            else
            {
                throw new ArgumentException(str);
            }
        }
        internal static IntervalUnit ParseUnit(string text)
        {
            text = text.ToLower();
            return (text.First()) switch
            {
                'y' => IntervalUnit.Year,
                'm' => IntervalUnit.Month,
                'w' => IntervalUnit.Week,
                'd' => IntervalUnit.Day,
                _ => throw new ArgumentException(text),
            };
        }
        public static IEnumerable<Interval> ParseMany(string str)
        {
            var intervals = new List<Interval>();

            if (string.IsNullOrWhiteSpace(str))
            {
                intervals.Add(Interval.Min);
                return intervals;
            }

            str = str.Replace(" ", "");
            while (!string.IsNullOrEmpty(str))
            {
                intervals.Add(Parse(str));
                str = re.Replace(str, "");
            }
            return intervals;
        }
        public static bool TryParse(string str, out Interval result)
        {
            try
            {
                result = Parse(str);
                return true;
            }
            catch (ArgumentException)
            {
                result = default;
                return false;
            }
        }
    }
}
