using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("수를 입력하세요 : ");
            string input = Console.ReadLine();
            double arg = Convert.ToDouble(input);

            Console.WriteLine("결과 : {0}", Square(arg));
        }

        static double Square(double arg)
        {
            return arg * arg;
        }
    }
}
