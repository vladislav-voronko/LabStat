using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathx
{
    public class ModaResult
    {
        public int Value { get; set; }
        public int Frequency { get; set; }

        public ModaResult() { }

        public ModaResult(int value, int frequency)
        {
            value = Value;
            frequency = Frequency;
        }
    }
}
