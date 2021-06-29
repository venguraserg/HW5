using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5_3
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Введите строку для преобразования");
                Console.WriteLine("Строка после преобразования:\n" + OutString(Console.ReadLine()));
            }
            while (Quit());
              

        }
        /// <summary>
        /// Метод удаления одинаковых символов которые стоят рядом
        /// </summary>
        /// <param name="text">Входящий текст</param>
        /// <returns>преобразовнаную строку</returns>
        static string OutString(string text)
        {
           
            text = text.ToLower();
            var charArray = text.ToCharArray();
            char[] newCharArray = new char[charArray.Length];
            newCharArray[0] = charArray[0];
            for (int i = 1, count = 1; i < charArray.Length; i++)
            {
                if (charArray[i - 1] != charArray[i])
                {
                    newCharArray[count] = charArray[i];
                    count++;
                }
            }
            return new string(newCharArray);
        }
        /// <summary>
        /// Метод выхода из приложения
        /// </summary>
        /// <returns>true - выход, false - продолжаем</returns>
        static bool Quit()
        {          
            Console.WriteLine("ВЫЙТИ ИЗ ПРИЛОЖЕНИЯ  (y/n)?:");
            char yn;
            bool correctParse, quit = true;
            do
            {
                correctParse = char.TryParse(Console.ReadLine(), out yn);
                if (!(yn == 'n' || yn == 'N' || yn == 'y' || yn == 'Y'))
                {
                    Console.WriteLine("Не корректный ввод, попробуйте еще раз...");
                }
            } while (!(correctParse && (yn == 'n' || yn == 'N' || yn == 'y' || yn == 'Y')));

            if (yn == 'y' || yn == 'Y')
            {
                quit = false;
            }
            else if (yn == 'n' || yn == 'N')
            {
                Console.WriteLine("Продолжим, нажми любую клавишу...");
                Console.ReadKey();
                quit = true;
            }
            return quit;
        }
    }
}
