using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdsi.Date
{
    public class Defaults
    {
        public static readonly DateTime MinDate = new DateTime(1900, 1, 1);
        public static readonly DateTime MaxDate = new DateTime(2999, 12, 31);
        public static readonly Interval MinInterval = new() { Unit = IntervalUnit.Day, Value = 0 };
        public static readonly Interval MaxInterval = new() { Unit = IntervalUnit.Year, Value = 2999 };
    }
}
