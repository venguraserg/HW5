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
                string text = Console.ReadLine().ToLower();
                Console.WriteLine(text + "\n\n");
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

                string s = new string(newCharArray);


                Console.WriteLine(s);



                Console.WriteLine("Для продолжения нажмите любую клавишу . . . ");
                Console.ReadKey();

            }
            while (Quit());
              

        }





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
