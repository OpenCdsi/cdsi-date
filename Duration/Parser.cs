using System.Text.RegularExpressions;

namespace Cdsi
{
    public partial class Duration
    {
        private static Regex re = new Regex("^([\\+-]?\\d+)(\\w+)");

        internal static Interval ParseUnit(string text)
        {
            text = text.ToLower();
            return (text.First()) switch
            {
                'y' => Interval.Year,
                'm' => Interval.Month,
                'w' => Interval.Week,
                'd' => Interval.Day,
                _ => throw new ArgumentException(text),
            };
        }

        internal static Duration ParseOne(string text)
        {
            text = text.Replace(" ", "");
            var match = re.Match(text);
            if (match.Success)
            {
                return new Duration()
                {
                    Value = int.Parse(match.Groups[1].Value),
                    Unit = ParseUnit(match.Groups[2].Value)
                };
            }
            else
            {
                throw new ArgumentException(text);
            }
        }

        public static IEnumerable<Duration> Parse(string text)
        {
            var durations = new List<Duration>();
            text = text.Replace(" ", "");
            while (!string.IsNullOrEmpty(text))
            {
                durations.Add(ParseOne(text));
                text = re.Replace(text, "");
            }
            return durations;
        }
    }

}
