using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_UsingVar
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = 20;
            Console.WriteLine("Type: {0}, Value: {1}", a.GetType(), a);

            var b = 3.1414213;
            Console.WriteLine("Type: {0}, Value: {1}", b.GetType(), b);

            var c = "Hello, World!";
            Console.WriteLine("Type: {0}, Value: {1}", c.GetType(), c);

            var d = new int[] { 10, 20, 30 };
            Console.Write("Type: {0}, Value: ", d.GetType());
            foreach (var f in d)
                Console.Write("{0} ", f);
            Console.WriteLine();

            var e = 3.1414213f;
            Console.WriteLine("Type: {0}, Value: {1}", e.GetType(), e);

            //var f;      //컴파일 에러

            
        }
    }
}
