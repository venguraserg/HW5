using System;


namespace HW5_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();                                                        //очистка экрана
            var sequence = SequenceInput();                                         //вызов метода ввода последовательности
            Console.WriteLine(CheckSequence(sequence));                             //проверка последовательности, вывод результата
            Console.WriteLine("Для продолжения нажмите любую клавишу . . . ");
            Console.ReadKey();
        }

        /// <summary>
        /// Метод проверки последовательности
        /// </summary>
        /// <param name="sequence">массив последовательност</param>
        /// <returns>строка текста с результатом</returns>
        static string CheckSequence(int[] sequence)
        {
            /* условие арифметической прогрессии
             *    
             * d = a[n+1] - a[n]
             * 
             * условие геометической прогрессии
             *      a[n+1]
             * q = -------
             *       a[n]
             */

            //инициализация коэфициентов
            int d = sequence[1] - sequence[0];
            int q = sequence[1] / sequence[0];
            string text=null;
            //проверка на арифметическую прогрессию
            for(int i = 2; i < sequence.Length; i++)
            {
                if (sequence[i] - sequence[i - 1] != d)
                {
                    text = "не является";
                    break;
                }
                text = "является АРИФМЕТИЧЕСКОЙ";
            }
            //проверка на геометрическую прогрессию
            for (int i = 2; i < sequence.Length; i++)
            {
                if (sequence[i] / sequence[i - 1] != q)
                {
                    text = "не является";
                    break;
                }
                text = "является ГЕОМЕТРИЧЕСКОЙ";
            }

            return $"Последовательность {text} прогрессией";
        }
        /// <summary>
        /// Метод ввода последовательности
        /// </summary>
        /// <returns>массив последовательности</returns>
        static int[] SequenceInput()
        {
            Console.WriteLine("Введите количество элементов последовательности (целое положительное число >=3)");
            var numbElement = InputNumber(true, 3); //параметр 2 минимальное количество элементов последовательности
            int[] sequence = new int[numbElement];
            for(int i = 0; i< numbElement; i++)
            {
                Console.WriteLine($"Введите {i+1}-й элемент последовательности:");
                sequence[i] = InputNumber(false, int.MinValue);
            }

            Console.WriteLine("Введенная последовательность:");
            for(int i = 0; i < numbElement; i++)
            {
                Console.Write(sequence[i] + ", ");
            }
            Console.WriteLine("");
            return sequence;
        }
        /// <summary>
        /// Метод ввода чисел
        /// </summary>
        /// <param name="parametr">true - Только положительное число</param>
        /// <param name="minValue">минимально допустимое число</param>
        /// <returns></returns>
        static int InputNumber(bool parametr, int minValue)
        {
            bool correctParse, exitCondition;
            int number;
            do
            {
                correctParse = int.TryParse(Console.ReadLine(), out number); // ввод числа
                exitCondition = parametr ? (!correctParse || number < minValue) : (!correctParse);                
                if (exitCondition) Console.WriteLine("Не коррекные данные, повторите ввод");
            }
            while (exitCondition);
            return number;
        }
    }

}
