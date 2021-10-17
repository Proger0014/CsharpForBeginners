using System;

namespace ConsoleApp
{
    // Сделать телефонную книгу, где есть поля name, number и age, также и заполнение сделать
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Сколько у вас будет людей: ");
            int count = int.Parse(Console.ReadLine());

            Console.WriteLine();

            string[] names = new string[count];
            byte[] ages = new byte[count];
            string[] numbers = new string[count];

            string input = string.Empty;
            int i = 0;
            // input data
            while (i < count)
            {
                Console.Write("Введи имя: ");
                input = Console.ReadLine();

                if (input == "-")
                {
                    break;
                }

                names[i] = input;

                Console.Write("Введи возраст: ");
                input = Console.ReadLine();

                if (input == "-")
                {
                    break;
                }

                ages[i] = byte.Parse(input);

                Console.Write("Введи номер: ");
                input = Console.ReadLine();

                if (input == "-")
                {
                    break;
                }

                numbers[i] = input;

                i++;

                Console.WriteLine();
            }

            // Write data
            for (int j = 0; j < count; j++)
            {
                Console.Write("Имя: ");
                Console.ForegroundColor = ConsoleColor.Green;

                if (numbers[j] != String.Empty)
                {
                    Console.Write($"{names[j]} ");
                }

                Console.ResetColor();
                Console.Write("\t|\t");

                Console.Write("Возраст: ");
                Console.ForegroundColor = ConsoleColor.Yellow;

                if (ages[j] != 0)
                { 
                    Console.Write($"{ages[j]} ");
                }
                
                Console.ResetColor();
                Console.Write("\t|\t");

                Console.Write("номер: ");
                Console.ForegroundColor = ConsoleColor.Red;

                if (numbers[j] != String.Empty)
                { 
                    Console.Write($"{numbers[j]}\n");
                }

                Console.ResetColor();
            }
        }
    }
}
