﻿using OpenCdsi.Date;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCdsi.Date.Tests
{
    internal static class Defaults
    {
        public static CalendarUnit Day => new() { Name = UnitName.Day, Value = 1 };
        public static CalendarUnit Week => new() { Name = UnitName.Week, Value = 1 };
        public static CalendarUnit Month => new() { Name = UnitName.Month, Value = 1 };
        public static CalendarUnit Year => new() { Name = UnitName.Year, Value = 1 };
    }
}
