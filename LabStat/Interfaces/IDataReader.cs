using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabStat.Interfaces
{
    public interface IDataReader
    {
        int HeightArray { get; }

        int[,] GetArray(int n);
    }
}
