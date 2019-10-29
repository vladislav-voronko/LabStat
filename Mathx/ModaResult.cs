using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathx
{
    public class ModaResult
    {
        //Todo: С большой буквы - Свойство класса
        public int value { get; set; }
        public int frequency { get; set; }

        public ModaResult() { }

        //Аргументы все с маленьй буквы - это локальные переменные -слишком часто эту ошибку делаешь Опишу чуть ниже как определять с маленькой буквы или большой
        /* Смотри, если к переменной НЕЛЬЗЯ получить доступ снаружи метода или класса -это локальная, она доступна тоьлко внутри метода или класса, как тут, аргументы доступны только внутри метода ModaResult.
         А вот свойства Value и Frequency должны быть с большой буквы - к ним есть доступ из других классов - они не локальные. Ты можешь узнать их значение из другого класса. 
         Методы и названия классов всегда С большой буквы.
         */
        public ModaResult(int Value, int Frequency)
        {
            Value = value;
            Frequency = frequency;
        }
    }
}
