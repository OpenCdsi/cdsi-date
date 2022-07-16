using System.Text.RegularExpressions;

namespace Cdsi.Date
{
    public readonly partial struct Interval
    {
        internal static readonly Regex re = new("^([\\+-]?\\d+)(\\w+)");

        public static Interval Parse(string text)
        {
            text = text.Replace(" ", "");
            var match = re.Match(text);
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
                throw new ArgumentException(text);
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

        public static bool TryParse(string text, out Interval result)
        {
            try
            {
                result = Parse(text);
                return true;
            }
            catch (ArgumentException)
            {
                result = Empty;
                return false;
            }
        }
    }
}
