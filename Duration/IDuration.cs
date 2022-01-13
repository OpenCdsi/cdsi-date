using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duration
{

    public interface IDuration
    {
        int Value { get; }
        Interval Unit { get; }
    }
}
