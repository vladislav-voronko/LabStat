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
            //todo" Бесполезная переменная height, тут можно сразу вернуть heightArray. Вернётся не ссылка, а копия инта, почитай про Значимые и Ссылочные типы, одна из самый сложных тем в c#, но самая важная.
            int height = heightArray;
            return height;
        }
        //todo: между методами должен быть 1 пробел
        //todo: непонятное название метода, должен назвыается что-то типа "SelectColumn" или "GetColumn", а то получается когда читаешь "ChoosVar - Выбрать переменную? что за?" 
        public static int[] ChooseVar(int[,] Table, int col)
        {
            int[] chooseArr = new int[heightArray];
            //todo: не нужны фигурные скобки, если 1 строчка в цикле.
            for (int i = 0; i < heightArray; i++)
            {
                chooseArr[i] = Table[i, col];
            }
            return chooseArr;
        }
        //todo: Называть так методы сильно не желательно, здесь должно быть что-то типа "GetAverage" - в таком названии понятно что ВОЗВРАЩАЕТ метод. Называть так методы можно, если они ничего не возвращают.
        public static double Average(int[] Table)
        {
            int SumAverage = 0;
            //todo: не нужны фигурные скобки, если 1 строчка в цикле.
            for (var i = 0; i < heightArray; i++)
            {
                SumAverage += Table[i];
            }
            double average = (double)SumAverage / heightArray;
            //Todo: (мелочь) На месте этого комментария была пустая строка, а сверху перед return не было пустой строки, можно писать и так и так, но везде одинаково, либо ты делаешь отступ перед return либо нет, везде. (p/s  я не делаю)
            return average;
        }

        public static int GetModa(int[] Table)
        {
            //Todo: С маленькой буквы, локальная переменная
            int[] ModaTable = new int[heightArray];

            //todo: Вот так надо было везде
            for (var i = 0; i < heightArray; i++)
                ModaTable[i] = Table[i];
            int counter;
            int currentNumber;
            //todo: Это локальная переменная, с маленькой буквы должна быть
            //todo: Название не очень, не информативное, хороший вариант: "ModaResultList" - сразу понятно, что это список;
            List<ModaResult> Objects = new List<ModaResult>();
            //Todo: Такую инициализацию можно сделать при создании. Пример:
            //List<ModaResult> Objects = new List<ModaResult>
            //{
            //    new ModaResult()
            //}; - Заменяет строчку выши и ниже, молее читаемо. Кстати, точно так же ты инициализируешь массив TableR
            //Почитай про инициализацию списков
            Objects.Add(new ModaResult());

            for (var i = 0; i < heightArray; i++)
            {
                //Todo: не понимаю почему переменная counter инициализирована выше. Она тебе нужна только внутри этих фигурных скобках(области видимости), поэтому можно объявить её тут: int counter = 1;
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
            //todo: не нужны фигурные скобки, если 1 строчка в цикле (1 команда).
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
                        //Todo: не понимаю почему переменная temp инициализирована выше. Она тебе нужна только внутри этих фигурных скобках(области видимости), поэтому можно объявить её тут: int temp =  VariationTable[j];
                        //Эту ошибку больше указывать не буду, сам поищи гед ты неправильно указал, может и нигде больше, просто сам попытайся найти, мне влом
                        temp = VariationTable[j];
                        VariationTable[j] = VariationTable[i];
                        VariationTable[i] = temp;
                    }
                }
            int median = (VariationTable[heightArray / 2 - 1] + VariationTable[heightArray / 2]) / 2;
            int rangeVariation = VariationTable[heightArray - 1] - VariationTable[0];
            for (var i = 0; i < heightArray; i++)
            {
                dispersion += Math.Pow((VariationTable[i] - average), 2);
            }
            dispersion = dispersion / heightArray - 1;
            standartDeviation = Math.Sqrt(dispersion);
            //Todo:
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
            /*Нельзя такую херню возвращать. Я как пользователь твоего метода не вижу его реализацию. Я не знаю что такое result[4] - это нигде не описано. Я допустим использую твой метод, и получаю на выходе только
             массив. Как мне узнать какой номер является каким? А если ты захочешь поменять порядок, получается, что у меня надо код переписывать? Более того я даже не знаю массив какого размера ты мне возвращаешь.
             Если я обращусь по адресу result[100], то я получу ошибку. Ты скажешь нельзя обращаться по этому адресу, а я такой, а почему, где это написано?
             
             Вывод: я должен уметь пользоваться твоим методом и не спрашивать все вышеперечисленные вопросы у тебя, мало ли ты будешь в отпуске или тебя уволят. Как мне понять тогда что где означает?
             
             Есть 2 способа решения: 1) написать документацию к методу и ограничить его, вернув массив из 7-ми значений, а не безразмерный массив. Почитай про XML-документацию в C#/
             2) Самый нормальный и правильны способ: 

                Создать класс с названием например: class CalculationResult{}
                И у него содать поля/свойства Median, RangeVariation и так далее.

            И вернуть объект этого класса, с заполненными полями.
            Тогда я буду знать, что поле Median Это медиана и так далее, и не надо переделывать мне свой код, если ты захочешь что-то добавить.
            Кстати, это прямой пример нарушения 2-ого правила SOLID. Тоже можешь почитать.
             */
            return results;
        }
    }
}
