using Cdsi.Date;
namespace Cdsi
{
    public readonly partial struct Interval
    {

        // Interval:Interval
        public static Interval operator +(Interval a, Interval b)
        {
            if (a.Unit != b.Unit) throw new ArgumentException("Both intervals must have the same Unit.");

            return new Interval { Value = a.Value + b.Value, Unit = a.Unit };
        }

        public static Interval operator -(Interval a, Interval b)
        {
            return a + (-1 * b);
        }

        // DateTime:Interval
        public static DateTime operator +(DateTime a, Interval b)
        {
            var result = a.Add(b);
            if (result < Defaults.MinDate) { result = Defaults.MinDate; }
            else if (result > Defaults.MaxDate) { result = Defaults.MaxDate; }
            return result;
        }
        public static DateTime operator -(DateTime a, Interval b)
        {
            return a.Add(-1 * b);
        }

        // Interval:Integer
        public static Interval operator +(Interval a, int b)
        {
            return new Interval { Value = a.Value + b, Unit = a.Unit };
        }
        public static Interval operator -(Interval a, int b)
        {
            return new Interval { Value = a.Value - b, Unit = a.Unit };
        }
        public static Interval operator *(Interval a, int b)
        {
            return new Interval { Value = a.Value * b, Unit = a.Unit };
        }
        public static Interval operator /(Interval a, int b)
        {
            return new Interval { Value = a.Value / b, Unit = a.Unit };
        }

        // Interval:Integer (associative operations)
        public static Interval operator +(int b, Interval a)
        {
            return a + b;
        }
        public static Interval operator *(int b, Interval a)
        {
            return a * b;
        }
    }
}
