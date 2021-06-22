using System;

namespace _10_Ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix1 = new int[2, 2] { { 3, 2 }, { 1, 4 } };
            int[,] matrix2 = new int[2, 2] { { 9, 2 }, { 1, 7 } };

            int a = matrix1[0, 0];
            int b = matrix1[0, 1];
            int c = matrix1[1, 0];
            int d = matrix1[1, 1];
            int e = matrix2[0, 0];
            int f = matrix2[0, 1];
            int g = matrix2[1, 0];
            int h = matrix2[1, 1];

            Console.WriteLine("{0} {1}\n{2} {3}", a*e+b*g, a*f+b*h, c*e+d*g, c*f+d*h);
        }
    }
}
