using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5_1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            #region Умножение матрицы на число
            //Умножение матрицы на число
            Console.Clear();
            Console.WriteLine("Умножение матрицы на число");
            Console.WriteLine("**********************************************");

            //********************************************************************
            
            //По моему самое локоничное решение)
            //В методе InputParameter булевой аргумент лишь только для сокращения всего решения 

            //PrintMatrix(MuxMatrixNumb(InputMatrix(),InputParameter(true)));

            //второй вариант решения, пошагово... и с большим описанием
            int[,] matrix = InputMatrix();
            Console.WriteLine("\nРандомная матрица");
            PrintMatrix(matrix);
            int number = InputParameter(true);
            int[,] newMatrix = MuxMatrixNumb(matrix, number);

            Console.WriteLine($"\nМатрица умноженная на число {number}");
            PrintMatrix(newMatrix);






            Console.WriteLine("Для продолжения нажмите любую клавишу . . . ");
            Console.ReadKey();
            #endregion
        }
        /// <summary>
        /// Метод рандомного заполнения матрицы
        /// </summary>
        /// <returns>Новая рандомная матрица</returns>
        static int[,] InputMatrix()
        {
            Console.WriteLine("Введите размерность для матрицы");
            Console.WriteLine("Введите количество строк");
            int row= InputParameter(false);
            Console.WriteLine("Введите количество столбцов");
            int col= InputParameter(false);

            //Формируем и выводим на экран матрицу случайным образом
            
            Random randomNumber = new Random();
            int[,] matrix = new int[row, col];

            for (var i = 0; i < row; i++)
            {
                for (var j = 0; j < col; j++)
                {
                    matrix[i, j] = randomNumber.Next(100);
                }
            }
            return matrix;
        }
        /// <summary>
        /// Метод ввода любого положительного числа
        /// </summary>
        /// <param name="flag">Исключительно для вывода строки напоминания. true - выводим сообщение</param>
        /// <returns>Целое положительное число</returns>
        static int InputParameter(bool flag)
        {
            if(flag) Console.WriteLine("Введите число на которое нужно умножить матрицу");
            
            bool correctParse;
            int number;
            do
            {
                correctParse = int.TryParse(Console.ReadLine(), out number); // ввод количества строк
                if (number <= 0) Console.WriteLine("Не коррекные данные, повторите ввод");
            }
            while (!correctParse || number <= 0);

            return number;
        }
        /// <summary>
        /// Выводит на экран двумерную матрицу
        /// </summary>
        /// <param name="matrix">принимает в качестве аргумента матрицу</param>
        static void PrintMatrix(int[,] matrix)
        {
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j],5}");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Метод умножения матрицы на число
        /// </summary>
        /// <param name="matrix">принимает в качестве аргумента матрицу</param>
        /// <param name="number">принимает в качестве аргумента число для умножения</param>
        /// <returns>Новая матрица</returns>
        static int[,] MuxMatrixNumb(int[,] matrix, int number )
        {
            int[,] newMatrix = new int[matrix.GetLength(0), matrix.GetLength(1)];
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    newMatrix[i, j] = matrix[i, j] * number;
                }
            }
            return newMatrix;
        }


    }
}
