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

            int[,] matrix = InputMatrix(InputParameter("Введите количество строк матрицы: "), InputParameter("Введите количество стобцов матрицы: "));
            PrintMatrix(matrix, "\nРандомная матрица\n");
            int number = InputParameter("Введите число, на которое нужно умножить матрицу: ");
            int[,] newMatrix = MuxMatrixNumb(matrix, number);
            PrintMatrix(newMatrix, $"\nМатрица умноженная на число {number}");

            // Ниже вариант решения в одну строку, но он не выводит исходную матрицу(
            //PrintMatrix(MuxMatrixNumb(InputMatrix(InputParameter("Введите количество строк матрицы: "), InputParameter("Введите количество стобцов матрицы: ")), InputParameter("Введите число, на которое нужно умножить матрицу: ")), $"\nМатрица умноженная на число");

            Console.WriteLine("Для продолжения нажмите любую клавишу . . . ");
            Console.ReadKey();
            #endregion

            #region Сложение матриц
            Console.Clear();
            Console.WriteLine("Сложение матриц");
            Console.WriteLine("**********************************************");
            Console.WriteLine("Инициализация матрицы А, матрица В будет иметь такую же размерность");
            int[,] matrixA = InputMatrix(InputParameter("Введите количество строк матрицы: "), InputParameter("Введите количество стролбцов матрицы: "));
            int[,] matrixB = InputMatrix(matrixA.GetLength(0), matrixA.GetLength(1));
            
            PrintMatrix(matrixA, "Матрица А:");
            PrintMatrix(matrixB, "Матрица В:");

            
            PrintMatrix(AddMatrix(matrixA, matrixB), "Матрица С=А+В:");
                        
            PrintMatrix(SubMatrix(matrixA, matrixB), "Матрица С=А-В:");

            Console.WriteLine("Для продолжения нажмите любую клавишу . . . ");
            Console.ReadKey();
            #endregion

            #region Вычетание матриц

            Console.WriteLine("Для продолжения нажмите любую клавишу . . . ");
            Console.ReadKey();
            #endregion


            Console.WriteLine("Для продолжения нажмите любую клавишу . . . ");
            Console.ReadKey();
            
        }
        /// <summary>
        /// Метод рандомного заполнения матрицы
        /// </summary>
        /// <returns>Новая рандомная матрица</returns>
        static int[,] InputMatrix(int row, int col)
        {            
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
        static int InputParameter(string text)
        {
            Console.Write(text);
                       
            bool correctParse;
            int number;
            do
            {
                correctParse = int.TryParse(Console.ReadLine(), out number); // ввод количества строк
                if (number <= 0) Console.WriteLine("Не коррекные данные, повторите ввод");
            }
            while (!correctParse || number <= 0);
            Console.WriteLine("");
            return number;
        }
        /// <summary>
        /// Выводит на экран двумерную матрицу
        /// </summary>
        /// <param name="matrix">принимает в качестве аргумента матрицу</param>
        static void PrintMatrix(int[,] matrix, string title)
        {
            Console.WriteLine(title);
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

        static int[,] AddMatrix(int[,] matrixA, int[,] matrixB)
        {
            int[,] newMatrix = new int[matrixA.GetLength(0), matrixA.GetLength(1)];
            for (var i = 0; i < matrixA.GetLength(0); i++)
            {
                for (var j = 0; j < matrixA.GetLength(1); j++)
                {
                    newMatrix[i, j] = matrixA[i, j] + matrixB[i, j];
                }                
            }
            return newMatrix;
        }
        static int[,] SubMatrix(int[,] matrixA, int[,] matrixB)
        {
            int[,] newMatrix = new int[matrixA.GetLength(0), matrixA.GetLength(1)];
            for (var i = 0; i < matrixA.GetLength(0); i++)
            {
                for (var j = 0; j < matrixA.GetLength(1); j++)
                {
                    newMatrix[i, j] = matrixA[i, j] - matrixB[i, j];
                }
            }
            return newMatrix;
        }
    }
}
