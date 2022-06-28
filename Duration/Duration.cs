namespace Cdsi
{

    public partial class Duration : IDuration
    {
        public int Value { get; internal set; }
        public Interval Unit { get; internal set; }

        public static IDuration Create(int value, Interval unit)
        {
            return new Duration { Value = value, Unit = unit };
        }
    }

    public class DurationComparer : IComparer<IDuration>
    {
        public int Compare(IDuration? x, IDuration? y)
        {
            if (x.Unit == y.Unit)
            {
                return x.Value.CompareTo(y.Value);
            }else
            {
                return x.Unit.CompareTo(y.Unit);
            }
        }
    }
}
