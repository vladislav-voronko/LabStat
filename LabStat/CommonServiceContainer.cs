using LabStat.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabStat
{
    public static class CommonServiceContainer
    {
        private static StaticReader staticReader;
        private static FileReader fileReader;

        static CommonServiceContainer()
        {
            staticReader = new StaticReader();
            fileReader = new FileReader();
        }

        public static IDataReader GetReader(int option)
        {
            if (option == 0) return staticReader;
            if (option == 1) return fileReader;
            return null;
        }
    }
}
