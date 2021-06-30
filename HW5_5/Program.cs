using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5_5
{
    class Program
    {

        //Содрал на просторах интернета, слепил из нескольких вариантов, но от переполнения стека не ушел((
        public static int Depth = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Функция Аккермана = " + Ackermann(InputNumber(true, "m"), InputNumber(true, "n")));
            Console.WriteLine("Глубина рекурсии: "+Depth);
            Console.WriteLine("Для продолжения нажмите любую клавишу . . . ");
            Console.ReadKey();

        }
        
        public static UInt64 Ackermann(UInt64 m, UInt64 n)
        {
            Depth++;
            if (m == 0)
                return n + 1;
            if (n == 0)
                return Ackermann(m - 1, 1);
            return Ackermann(m - 1, Ackermann(m, n - 1));
        }
        /// <summary>
        /// Метод ввода чисел
        /// </summary>
        /// <param name="parametr">true - Только положительное число</param>
        /// <param name="minValue">минимально допустимое число</param>
        /// <returns></returns>
        static UInt64 InputNumber(bool parametr, string text)
        {
            bool correctParse, exitCondition;
            UInt64 number;
            Console.WriteLine($"Введите {text}:");
            do
            {
                correctParse = UInt64.TryParse(Console.ReadLine(), out number); // ввод числа
                exitCondition = parametr ? (!correctParse || number < 0) : (!correctParse);
                if (exitCondition) Console.WriteLine("Не коррекные данные, повторите ввод");
            }
            while (exitCondition);
            return number;
        }
    }
}
