using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayTwoSides
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayTwoSides<int> tablica = new ArrayTwoSides<int>(10, -5);
            for(int i = tablica.indexBegin; i <= tablica.indexEnd; i++)
            {
                tablica.Set(i, i + 100);
            }

            for(int i = tablica.indexBegin; i <= tablica.indexEnd; i++)
            {
                Console.WriteLine("index {0}: wartość: {1}", i, tablica.Get(i));
            }
            Console.ReadKey();
        }
    }
}
