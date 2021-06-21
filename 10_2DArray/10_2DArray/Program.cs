using System;

namespace _10_2DArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };

            for(int i=0; i<arr.GetLength(0); i++)
            {
                for(int j=0; j<arr.GetLength(1); j++)
                {
                    Console.Write($"[{i}, {j}] : {arr[i, j]}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            int[,] arr2 = new int[,] { { 1, 2, 3}, { 4, 5, 6} };
            for (int i = 0; i < arr2.GetLength(0); i++)
            {
                for (int j = 0; j < arr2.GetLength(1); j++)
                {
                    Console.Write($"[{i}, {j}] : {arr2[i, j]}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            int[,] arr3 = { { 1, 2, 3 }, { 4, 5, 6 } };
            for (int i = 0; i < arr3.GetLength(0); i++)
            {
                for (int j = 0; j < arr3.GetLength(1); j++)
                {
                    Console.Write($"[{i}, {j}] : {arr3[i, j]}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            //2차원 배열을 foreach문에 넣으면 숫자가 차례로 나온다.
            foreach (int a in arr)
                Console.WriteLine(a);
        }
    }
}
