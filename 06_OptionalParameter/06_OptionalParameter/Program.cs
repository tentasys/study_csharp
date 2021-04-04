using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_OptionalParameter
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintProfile("지효");
            PrintProfile("사나", "1234-5678");
            PrintProfile(name: "미나");
            PrintProfile(name: "쯔위", phone: "010-1111-1111");
        }

        static void PrintProfile(string name, string phone = "")
        {
            Console.WriteLine($"Name:{name}, Phone:{phone}");
        }
    }
}
