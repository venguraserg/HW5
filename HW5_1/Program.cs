using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

            #region Сложение и вычитание матриц
            Console.Clear();
            Console.WriteLine("Сложение и вычитание матриц");
            Console.WriteLine("**********************************************");
            Console.WriteLine("Инициализация матрицы А, матрица В будет иметь такую же размерность");
            int[,] matrixA = InputMatrix(InputParameter("Введите количество строк матрицы: "), InputParameter("Введите количество стролбцов матрицы: "));
            PrintMatrix(matrixA, "Матрица А:");

            //Какойто бред конечно, но без задержки матрицы заполняются одинаково, не пойму почему,
            //видимо Random както с системным временем завязан 
            Thread.Sleep(10);

            int[,] matrixB = InputMatrix(matrixA.GetLength(0), matrixA.GetLength(1));
            PrintMatrix(matrixB, "Матрица В:");


            PrintMatrix(AddMatrix(matrixA, matrixB), "Матрица С=А+В:");

            PrintMatrix(SubMatrix(matrixA, matrixB), "Матрица С=А-В:");

            Console.WriteLine("Для продолжения нажмите любую клавишу . . . ");
            Console.ReadKey();
            #endregion

            #region Умножение матриц
            Console.Clear();
            Console.WriteLine("Умножение матриц");
            Console.WriteLine("**********************************************");
            Console.WriteLine("Инициализация матрицы А");
            int[,] matrix_A = InputMatrix(InputParameter("Введите количество строк матрицы: "), InputParameter("Введите количество стролбцов матрицы: "));
            PrintMatrix(matrix_A, "Матрица А:");

            Console.WriteLine("Обязательное условие при умножении матриц - число столбцов матрицы А равно количеству строк матрицы B\n");

            int[,] matrix_B = InputMatrix(matrix_A.GetLength(1), InputParameter("Введите количество стролбцов матрицы: "));
            PrintMatrix(matrix_B, "Матрица B:");

            PrintMatrix(MuxMatrix(matrix_A,matrix_B),"Произведение матриц А и В: ");

            Console.WriteLine("Для продолжения нажмите любую клавишу . . . ");
            Console.ReadKey();
            #endregion

            
        }
        /// <summary>
        /// Метод заполнения случайным образом
        /// </summary>
        /// <param name="row">количество строк</param>
        /// <param name="col">количество столбцлв</param>
        /// <returns>Возвращает двумерный массив заполненая случайным образом</returns>
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
        /// Метод ввода положительного числа
        /// </summary>
        /// <param name="text">Текст назначения возвращаемой переменной</param>
        /// <returns>значение типа int</returns>
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
        /// Метод вывода матрицы на консоль
        /// </summary>
        /// <param name="matrix">Параметр принимает двумерный массив</param>
        /// <param name="title">Параметр вывода описания массива</param>
        static void PrintMatrix(int[,] matrix, string title)
        {
            Console.WriteLine(title);
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j],7}");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Метод уможения матрицы на число
        /// </summary>
        /// <param name="matrix">Принимет исходную матрицу</param>
        /// <param name="number">принимает множитель</param>
        /// <returns>матрицу умноженную на множитель</returns>
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
        /// <summary>
        /// Метод сложения матриц
        /// </summary>
        /// <param name="matrixA">принимает матрицу А</param>
        /// <param name="matrixB">принимает матрицу В</param>
        /// <returns>Возращает матрицу равной сумме матриц А и В</returns>
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
        /// <summary>
        /// Метод вычитания матриц
        /// </summary>
        /// <param name="matrixA">принимает матрицу А</param>
        /// <param name="matrixB">принимает матрицу В</param>
        /// <returns>Возращает матрицу равной разности матриц А и В</returns>
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
        /// <summary>
        /// Метод умножения матриц
        /// </summary>
        /// <param name="matrixA">принимает матрицу А</param>
        /// <param name="matrixB">принимает матрицу В</param>
        /// <returns>Возращает матрицу равной произведению матриц А и В</returns>
        static int[,] MuxMatrix(int[,] matrixA, int[,] matrixB)
        {
            int[,] newMatrix = new int[matrixA.GetLength(0), matrixB.GetLength(1)];

            for (var i = 0; i < matrixA.GetLength(0); i++)
            {
                for (var j = 0; j < matrixB.GetLength(1); j++)
                {

                    for (var k = 0; k < matrixB.GetLength(1); k++)
                    {
                        int temp_1, temp_2;
                        if (k < matrixA.GetLength(1)) temp_1 = matrixA[i, k];
                        else temp_1 = 0;
                        if (k < matrixB.GetLength(0)) temp_2 = matrixB[k, j];
                        else temp_2 = 0;

                        newMatrix[i, j] += temp_1 * temp_2; ;
                        
                    }
                }
            }
            return newMatrix;
        }
    }
}
