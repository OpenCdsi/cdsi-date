namespace DateMath
{

    public interface IDuration
    {
        int Value { get; }
        Interval Unit { get; }
    }
}
