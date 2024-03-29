﻿using System;

namespace _13_AnonymousMethod
{
    delegate int Compare(int a, int b);
    class Program
    {
        static void BubbleSort(int[] DataSet, Compare Comparer)
        {
            int i = 0;
            int j = 0;
            int temp = 0;
            for(i=0; i<DataSet.Length-1; i++)
            {
                for(j=0; j<DataSet.Length-(i+1); j++)
                {
                    if(Comparer(DataSet[j], DataSet[j+1]) > 0)
                    {
                        temp = DataSet[j];
                        DataSet[j] = DataSet[j + 1];
                        DataSet[j + 1] = temp;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            int[] array = { 3, 7, 4, 2, 10 };

            Console.WriteLine("Sorting Ascending...");
            BubbleSort(array, delegate (int a, int b)
            {
                if (a > b) return 1;
                else if (a == b) return 0;
                else return -1;
            });

            foreach (int a in array)
                Console.Write($"{a} ");

            int[] array2 = { 7, 2, 8, 10, 11 };
            Console.WriteLine("\nSorting Descending...");

            BubbleSort(array2, delegate (int a, int b)
            {
                if (a < b) return 1;
                else if (a == b) return 0;
                else return -1;
            });

            foreach (int a in array2)
                Console.Write($"{a} ");
        }
    }
}
