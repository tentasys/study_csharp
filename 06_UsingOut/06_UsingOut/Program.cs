﻿using System;

namespace _06_UsingOut
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 20;
            int b = 3;

            Divide(a, b, out int c, out int d);

            Console.WriteLine($"a:{a}, b:{b}, c:{c}, d:{d}");
        }

        static void Divide(int a, int b, out int quotient, out int remainder)
        {
            quotient = a / b;
            remainder = a % b;
        }
    }
}
