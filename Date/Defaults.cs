using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdsi.Date
{
    public static class MinDate
    {
        private static readonly DateTime _value = new DateTime(1900, 1, 1);
        public static DateTime Value =>_value;
    }
    public static class MaxDate
    {
        private static readonly DateTime _value = new DateTime(2999, 12, 31);
        public static DateTime Value => _value;
    }
}
