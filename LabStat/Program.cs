﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mathx.Mathx;

namespace LabStat
{
    static class Program
    {
        private static int n = 1;
        private const int widthArray = 5;
        private const int heightArray = 30;

        static void Main(string[] args)
        {
            int[,] Table = new int[heightArray, widthArray]
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
            int[] tableCount = ChooseVar(Table, n);
            double average = Average(tableCount);
            int moda = GetModa(tableCount);
            double[] otherResults = GetVariation(tableCount, average);
            Console.WriteLine($"{tableCount[heightArray - 1]} + {average} + {moda}");
            Console.ReadKey();
        }
    }
}
