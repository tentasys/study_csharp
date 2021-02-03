using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            uint a = uint.MaxValue; //4294967295
            Console.WriteLine(a);
            a = a + 1;
            Console.WriteLine(a);   //overflow

            int b = int.MaxValue;
            Console.WriteLine(b);
            b = b + 1;
            Console.WriteLine(b);
        }
    }
}
