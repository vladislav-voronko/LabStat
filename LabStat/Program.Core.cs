using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LabStat.Interfaces;
using System.Threading.Tasks;

namespace LabStat
{
    public partial class Program
    {
        private static int n = 1;
       
        static void Main(string[] args)
        {
            Console.WriteLine("Ennter 0 to read static data, enter 1 to read data from file.");
            int option = Convert.ToInt32(Console.ReadLine());

            IDataReader dataReader = CommonServiceContainer.GetReader(option);
            if (dataReader == null)
            {
                Console.WriteLine("Wrond option format.");
                Console.ReadKey();
            }

            var heightArray = dataReader.HeightArray;

            int[,] Table = dataReader.GetArray(n);
            int SumAverage = 0;
            for (var i = 0; i < heightArray; i++)
            {
                SumAverage += Table[i, 1];
            }
            double average = SumAverage / heightArray;
            Console.WriteLine($"Average value = {average}");
            Console.ReadKey();
            DefineModa(Table);
            DefineVariation(Table, average);
        }
    }
}
