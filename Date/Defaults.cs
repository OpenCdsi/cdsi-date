namespace OpenCdsi.Date
{
    public static class Defaults
    {
        private static readonly DateTime _minValue = new(1900, 1, 1);
        private static readonly DateTime _maxValue = new(2999, 12, 31);
        public static DateTime MinValue => _minValue;
        public static DateTime MaxValue => _maxValue;
    }
}
