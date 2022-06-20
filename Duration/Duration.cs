namespace Cdsi
{

    public partial class Duration : IDuration
    {
        public int Value { get; internal set; }
        public Interval Unit { get; internal set; }
    }
}
