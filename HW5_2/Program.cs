using System;


namespace HW5_2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Введите произвольную строку, разделитель пробел");
            var text = Console.ReadLine();
            Console.WriteLine($"Результат выполнения метода который возвращает строку, содержащую слово с минимальной длиной - {MinWord(text)}");
            
            Console.WriteLine($"Результат выполнения метода который возвращает одно или несколько слов с максимальной длиной - {MaxWord(text)}");
            
            Console.WriteLine("Для продолжения нажмите любую клавишу . . . ");
            Console.ReadKey();
        }
        /// <summary>
        /// Метод определения минимального слова
        /// </summary>
        /// <param name="text"> строка для обработки</param>
        /// <returns>минимальное слово</returns>
        static string MinWord(string text)
        {
            char[] charSeparators = new char[] { ' ' };
            var stringMassive = text.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
            
            string minWord = stringMassive[0];

            for(var i=1;i< stringMassive.Length; i++)
            {
                if (stringMassive[i].Length < minWord.Length) minWord = stringMassive[i];                
            }
            return minWord;
        }
        /// <summary>
        /// Метод определения самых больших слов
        /// </summary>
        /// <param name="text">строка для обработки</param>
        /// <returns>строка с одним или несколькими словами</returns>
        static string MaxWord(string text)
        {
            char[] charSeparators = new char[] { ' ' };
            var stringMassive = text.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
            
            SortMassiveUp(stringMassive);
            
            string[] newMassive = new string[stringMassive.Length];

            for (int i = 0, count = 0; i < stringMassive.Length; i++)
            {
                if (stringMassive[stringMassive.Length - 1].Length == stringMassive[i].Length)
                {
                    newMassive[count] = stringMassive[i];
                    count++;
                }
            }
            //Формирование новой строки для возврата
            //Конечно можно и массив строк вернуть, но в задании про массив ни слова, поэтому возвращаем слова в строке
            string newText=null;
            for(var i=0; i < stringMassive.Length; i++) 
            {
                if (newMassive[i] != null) newText = newText  + newMassive[i] + " ";
            }
            return newText;
        }
        /// <summary>
        /// Метод сортировки массива
        /// </summary>
        /// <param name="stringMassive">исходный массив</param>
        private static void SortMassiveUp(string[] stringMassive)
        {
            string temp;
            for (int i = 0; i < stringMassive.Length - 1; i++)
            {
                for (int j = i + 1; j < stringMassive.Length; j++)
                {
                    if (stringMassive[i].Length > stringMassive[j].Length)
                    {
                        temp = stringMassive[i];
                        stringMassive[i] = stringMassive[j];
                        stringMassive[j] = temp;
                    }
                }
            }
        }
    }
}
//Сначала в цикле мы вводим все числа для массива. Так как метод  возвращает вводимую строку, а нам нужны числа, поэтому мы эту строку переводим в число с помощью метода