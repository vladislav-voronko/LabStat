using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabStat
{
    public class ModaResult
    {
        public int value { get; set; }
        public int frequency { get; set; }

        public ModaResult() { }

        public ModaResult(int Value, int Frequency)
        {
            Value = value;
            Frequency = frequency;
        }

    }
}
