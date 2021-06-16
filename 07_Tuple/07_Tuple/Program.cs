using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            //unnamed tuple
            var a = ("슈퍼맨", 9999);
            Console.WriteLine($"{a.Item1}, {a.Item2}");

            //named tuple
            var b = (Name: "강희정", Age: 27);
            Console.WriteLine($"{b.Name}, {b.Age}");

            //분해
            var (name, age) = b; //(var name, var age) = b;
            Console.WriteLine($"{name}, {age}");

            //unnamed tuple = named tuple
            b = a;
            Console.WriteLine($"{b.Name}, {b.Age}");
        }
    }
}
