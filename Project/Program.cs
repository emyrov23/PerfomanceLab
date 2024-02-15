using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project
{
    internal class Program
    {
        public static Task1 task1 = new Task1();
        public static Task2 task2 = new Task2();
        public static Task3 task3 = new Task3();
        public static Task4 task4 = new Task4();

        static void Main(string[] args)
        {
         while(true)
            {
                Work();
            }
        }

        public static void Work()
        {
            Console.WriteLine("Выберите задачи:");
            Console.WriteLine("1: task1 - круговой массив");
            Console.WriteLine("2: task2 - окружность");
            Console.WriteLine("3: task3 - Json");
            Console.WriteLine("4: task4 - массив чисел");
            Console.WriteLine();

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    {
                        Console.WriteLine();
                        task1.Work();
                        break;
                    }
                case ConsoleKey.D2:
                    {
                        Console.WriteLine();
                        task2.Work();
                        break;
                    }
                case ConsoleKey.D3:
                    {
                        Console.WriteLine();
                        task3.Work();
                        break;
                    }
                case ConsoleKey.D4:
                    {
                        Console.WriteLine();
                        task4.Work();
                        break;
                    }
            }
        }
    }
}
