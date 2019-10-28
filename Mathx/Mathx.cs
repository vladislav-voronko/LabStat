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
        public static int otherResult = 7;

        public static int[,] TableR = new int[heightArray, widthArray]
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
            int height = heightArray;
            return height;
        }
        public static int[] ChooseVar(int[,] Table, int col)
        {
            int[] chooseArr = new int[heightArray];
            for (int i = 0; i < heightArray; i++)
            {
                chooseArr[i] = Table[i, col];
            }
            return chooseArr;
        }

        public static double Average(int[] Table)
        {
            int SumAverage = 0;
            for (var i = 0; i < heightArray; i++)
            {
                SumAverage += Table[i];
            }
            double average = (double)SumAverage / heightArray;

            return average;
        }

        public static int GetModa(int[] Table)
        {
            int[] ModaTable = new int[heightArray];

            for (var i = 0; i < heightArray; i++)
                ModaTable[i] = Table[i];
            int counter;
            int currentNumber;
            List<ModaResult> Objects = new List<ModaResult>();
            Objects.Add(new ModaResult());

            for (var i = 0; i < heightArray; i++)
            {
                counter = 1;
                currentNumber = ModaTable[i];
                ModaTable[i] = 0;
                if (currentNumber != 0)
                {
                    for (var j = i + 1; j < heightArray; j++)
                    {
                        if (currentNumber == ModaTable[j])
                        {
                            counter++;
                            ModaTable[j] = 0;
                        }
                    }
                    for (var t = 0; t < Objects.Count; t++)
                    {
                        if (Objects[t].frequency == 0 || Objects[t].frequency < counter)
                        {
                            Objects[t].value = currentNumber;
                            Objects[t].frequency = counter;
                            break;
                        }

                        if (Objects[t].frequency == counter)
                        {
                            Objects.Add(new ModaResult() { value = currentNumber, frequency = counter });
                            break;
                        }
                    }
                }
            }
            for (var i = 0; i < Objects.Count; i++)
            {
                if (Objects[0].frequency != Objects[i].frequency)
                    Objects.RemoveAt(i);
            }
            return Objects.Count;
        }

        public static double[] GetVariation(int[] Table, double average)
        {
            int temp;
            double dispersion = 0;
            double standartDeviation = 0;
            double averageLinearDeviation = 0;
            double coefficientOscillation = 0;
            double coefficientVariation = 0;
            double[] results = new double[7];
            int[] VariationTable = new int[heightArray];

            for (var i = 0; i < heightArray; i++)       
                VariationTable[i] = Table[i];
                
            for (var i = 0; i < heightArray - 1; i++)
                for (var j = i + 1; j < heightArray; j++)
                {
                    if (VariationTable[i] > VariationTable[j])
                    {
                        temp = VariationTable[j];
                        VariationTable[j] = VariationTable[i];
                        VariationTable[i] = temp;
                    }
                }
            int median = (VariationTable[heightArray/2 - 1] + VariationTable[heightArray/2]) / 2;
            int rangeVariation = VariationTable[heightArray-1] - VariationTable[0];
            for (var i = 0; i < heightArray; i++)
            {
                dispersion += Math.Pow((VariationTable[i] - average), 2);
            }
            dispersion = dispersion / heightArray - 1;
            standartDeviation = Math.Sqrt(dispersion);
            for (var i = 0; i < heightArray; i++)
            {
                averageLinearDeviation += (VariationTable[i] - average);
            }
            averageLinearDeviation = averageLinearDeviation / heightArray;
            coefficientOscillation = rangeVariation / average;
            coefficientVariation = standartDeviation / average;

            results[0] = median;
            results[1] = rangeVariation;
            results[2] = dispersion;
            results[3] = standartDeviation;
            results[4] = averageLinearDeviation;
            results[5] = coefficientOscillation;
            results[6] = coefficientVariation;
            return results;
        }
    }
}
