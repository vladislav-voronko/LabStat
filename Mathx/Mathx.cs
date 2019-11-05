using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathx
{
    public static class Mathx
    {
        private static int n = 1;
        private const int widthArray = 5;
        private const int heightArray = 30;

        public static int[,] tableR = new int[heightArray, widthArray]
            {
                {1,12,-41,-26,55},
                {2,14,-37,14,54},
                {3,8,-10,11,51},
                {4,24,-72,-62,51},
                {5,3,-10,-20,47},
                {6,7,-19,-25,43},
                {7,8,-20,38,43},
                {8,19,-62,-51,42},
                {9,19,-64+n,10,50},
                {10,26,-78,-27,62},
                {11,22+n,-77,-16,73},
                {12,26,-83,-30,70},
                {13,14,-42,31+n,75},
                {14,26,-86+n,-90,70},
                {15,5+n,-14,-23,69},
                {16,13,-28,-46,61},
                {17,8,-36,-88,57},
                {18,27,-75,-86,55},
                {19,12,-36+n,-40,49},
                {20,12,-31,-64,63},
                {21,25,-76,-48,62},
                {22,17,-56,-10,73},
                {23,12+n,-40,25+n,76},
                {24,28,-78,-76,88},
                {25,7,-13,-14,88},
                {26,3,-14,-55,87},
                {27,5,-11,-14,82},
                {28,16,-56,-55+n,77},
                {29,23,-72,-34,75},
                {30,26,-82,-31,71}
            };

        public static int GetHeightArray()
        {
            return heightArray;
        }

        public static int[] GetColumn(int[,] table, int col)
        {
            int[] chooseArr = new int[heightArray];
            for (int i = 0; i < heightArray; i++)
                chooseArr[i] = table[i, col];
            return chooseArr;
        }

        public static double GetAverage(int[] table)
        {
            int sumAverage = 0;
            for (var i = 0; i < heightArray; i++)
                sumAverage += table[i];
            double average = (double)sumAverage / heightArray;
            return average;
        }

        public static int GetModa(int[] Table)
        {
            int[] modaTable = new int[heightArray];

            for (var i = 0; i < heightArray; i++)
                modaTable[i] = Table[i];
            int currentNumber;
            List<ModaResult> modaResultList = new List<ModaResult>
            {
                new ModaResult()
            };

            for (var i = 0; i < heightArray; i++)
            {
                int counter = 1;
                currentNumber = modaTable[i];
                modaTable[i] = 0;
                if (currentNumber != 0)
                {
                    for (var j = i + 1; j < heightArray; j++)
                        if (currentNumber == modaTable[j])
                        {
                            counter++;
                            modaTable[j] = 0;
                        }
                    for (var t = 0; t < modaResultList.Count; t++)
                    {
                        if (modaResultList[t].Frequency == 0 || modaResultList[t].Frequency < counter)
                        {
                            modaResultList[t].Value = currentNumber;
                            modaResultList[t].Frequency = counter;
                            break;
                        }

                        if (modaResultList[t].Frequency == counter)
                        {
                            modaResultList.Add(new ModaResult() { Value = currentNumber, Frequency = counter });
                            break;
                        }
                    }
                }
            }
            for (var i = 0; i < modaResultList.Count; i++)
                if (modaResultList[0].Frequency != modaResultList[i].Frequency)
                    modaResultList.RemoveAt(i);
            return modaResultList.Count;
        }

        public static MathResults GetVariation(int[] table, double average)
        {
            double dispersion = 0;
            double standartDeviation = 0;
            double averageLinearDeviation = 0;
            double coefficientOscillation = 0;
            double coefficientVariation = 0;
            int[] variationTable = new int[heightArray];

            for (var i = 0; i < heightArray; i++)
                variationTable[i] = table[i];

            for (var i = 0; i < heightArray - 1; i++)
                for (var j = i + 1; j < heightArray; j++)
                {
                    if (variationTable[i] > variationTable[j])
                    {
                        int temp = variationTable[j];
                        variationTable[j] = variationTable[i];
                        variationTable[i] = temp;
                    }
                }
            int median = (variationTable[heightArray / 2 - 1] + variationTable[heightArray / 2]) / 2;
            int rangeVariation = variationTable[heightArray - 1] - variationTable[0];
            for (var i = 0; i < heightArray; i++)
            {
                dispersion += Math.Pow((variationTable[i] - average), 2);
            }
            dispersion = dispersion / heightArray - 1;
            standartDeviation = Math.Sqrt(dispersion);
            for (var i = 0; i < heightArray; i++)
                averageLinearDeviation += (variationTable[i] - average);
            averageLinearDeviation = averageLinearDeviation / heightArray;
            coefficientOscillation = rangeVariation / average;
            coefficientVariation = standartDeviation / average;

            MathResults mathResults = new MathResults
            {
                Median = median,
                RangeVariation = rangeVariation,
                Dispersion = dispersion,
                StandartDeviation = standartDeviation,
                AverageLinearDeviation = averageLinearDeviation,
                CoefficientOscillation = coefficientOscillation,
                CoefficientVariation = coefficientVariation
            };
            return mathResults;
        }
    }
}
