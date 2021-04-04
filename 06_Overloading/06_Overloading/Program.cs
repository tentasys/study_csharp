using System;

namespace _06_Overloading
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Plus(1, 2));
            Console.WriteLine(Plus(1, 2, 3));
            Console.WriteLine(Plus(1.0, 2.4));
            Console.WriteLine(Plus(1, 2.4));
        }

        static int Plus(int a, int b)
        {
            Console.WriteLine("Calling int Plus(int, int)...");
            return a + b;
        }
        static int Plus(int a, int b, int c)
        {
            Console.WriteLine("Calling int Plus(int, int, int)...");
            return a + b + c;
        }
        static double Plus(double a, double b)
        {
            Console.WriteLine("Calling double Plus(double, double)...");
            return a + b;
        }

        //오버로딩 : input parameter가 달라야 한다. output의 형식이 다르면 취급 안해줌 
        static double Plus(int a, double b)
        {
            Console.WriteLine("Calling double Plus(int, double)...");
            return a + b;
        }
    }
}
