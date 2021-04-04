using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_NamedParameter
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintProfile(name: "박찬호", phone: "010-123-1234");
            PrintProfile(phone: "010-1234-1234", name: "박지성");
            PrintProfile("박세리", "123-1234");
            PrintProfile("박주영", phone: "010-1111-1111");
            //PrintProfile(phone: "010-1111-1111", "박주영");  이렇게는 안된다 

        }

        static void PrintProfile(string name, string phone)
        {
            Console.WriteLine($"Name:{name}, Phone:{phone}");
        }
    }
}
