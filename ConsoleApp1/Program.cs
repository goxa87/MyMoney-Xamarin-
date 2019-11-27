using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyModelLibrary;

namespace ConsoleApp1
{
    class Program
    {
        public static void ExMethod(string s, int i)
        {
            Console.WriteLine($"Ошибка #{i}: {s}.");
        }

        public static void Vivod(RecordType RT)
        {
            for (int i = 0; i < RT.GetLenth(); i++)
            {
                Console.WriteLine(RT[i]);
            }
        }

        static void Main(string[] args)
        {

            MoneyBook moneyBook = new MoneyBook("Гоша");

            Console.WriteLine($"{ moneyBook.Name}");

            foreach (var e in moneyBook.Book)
                Console.WriteLine(e.ToString());

            Console.ReadKey();
        }
    }
}
