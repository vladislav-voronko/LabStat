using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabStat
{
    public partial class Program
    {
        private const int widthArray = 5;
        private const int heightArray = 30;

        public static void DefineModa(int[,] Table)
        {
            int[,] ModaTable = new int[heightArray, widthArray];

            for (var i = 0; i < heightArray; i++)
                for (var j = 0; j < 5; j++)
                {
                    ModaTable[i, j] = Table[i, j];
                }
            int counter;
            int currentNumber;
            int Moda;
            List<ModaResult> T = new List<ModaResult>();
            T.Add(new ModaResult());

            for (var i = 0; i < heightArray; i++)
            {
                counter = 1;
                currentNumber = ModaTable[i, 1];
                ModaTable[i, 1] = 0;
                if (currentNumber != 0)
                {
                    for (var j = i + 1; j < heightArray; j++)
                    {
                        if (currentNumber == ModaTable[j, 1])
                        {
                            counter++;
                            ModaTable[j, 1] = 0;
                        }
                    }
                    for (var t = 0; t < T.Count; t++)
                    {
                        if (T[t].frequency == 0 || T[t].frequency < counter)
                        {
                            T[t].value = currentNumber;
                            T[t].frequency = counter;
                            break;
                        }

                        if (T[t].frequency == counter)
                        {
                            T.Add(new ModaResult() { value = currentNumber, frequency = counter });
                            break;
                        }
                    }
                }
            }
            for (var i = 0; i < T.Count; i++)
            {
                if (T[0].frequency != T[i].frequency)
                    T.RemoveAt(i);
            }
            Moda = T.Count;
            Console.WriteLine($"Moda = {Moda}");
            foreach (ModaResult item in T)
                Console.WriteLine($"Value = {item.value} Frequency = {item.frequency}");
            Console.ReadKey();
        }

        public static void DefineVariation(int[,] Table, double average)
        {
            int temp;
            double dispersion = 0;
            double standartDeviation = 0;
            double averageLinearDeviation = 0;
            double coefficientOscillation = 0;
            double coefficientVariation = 0;
            int[,] VariationTable = new int[heightArray, 5];

            for (var i = 0; i < heightArray; i++)
                for (var j = 0; j < widthArray; j++)
                {
                    VariationTable[i, j] = Table[i, j];
                }
            for (var i = 0; i < heightArray - 1; i++)
                for (var j = i + 1; j < heightArray; j++)
                {
                    if (VariationTable[i, 1] > VariationTable[j, 1])
                    {
                        temp = VariationTable[j, 1];
                        VariationTable[j, 1] = VariationTable[i, 1];
                        VariationTable[i, 1] = temp;
                    }
                }
            int median = (VariationTable[14, 1] + VariationTable[15, 1]) / 2;
            int rangeVariation = VariationTable[29, 1] - VariationTable[0, 1]; //Сделатьотдельный метод
            for (var i = 0; i < heightArray; i++)
            {
                dispersion += Math.Pow((VariationTable[i, 1] - average), 2);
            }
            dispersion = dispersion / heightArray - 1;
            standartDeviation = Math.Sqrt(dispersion);
            for (var i = 0; i < heightArray; i++)
            {
                averageLinearDeviation += (VariationTable[i, 1] - average);
            }
            averageLinearDeviation = averageLinearDeviation / heightArray;
            coefficientOscillation = rangeVariation / average;
            coefficientVariation = standartDeviation / average;
            Console.WriteLine($"Median = {median}\nRange of variation = {rangeVariation}\nDispertion = {dispersion}\nStandart deviation = {standartDeviation}\nAverage linear deviation = {averageLinearDeviation}\nOscillation coefficient = {coefficientOscillation}\nVariation coefficient = {coefficientVariation}");
            Console.ReadKey();
        }
    }
}
