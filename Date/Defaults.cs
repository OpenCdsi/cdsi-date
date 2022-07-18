using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCdsi.Date
{
    public static class MinCdsiDate
    {
        private static readonly DateTime _value = new DateTime(1900, 1, 1);
        public static DateTime Value =>_value;
    }
    public static class MaxCdsiDate
    {
        private static readonly DateTime _value = new DateTime(2999, 12, 31);
        public static DateTime Value => _value;
    }
}
