using System;

namespace _12_Ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int[] arr = new int[10];

                for (int i = 0; i < 10; i++)
                    arr[i] = i;
                for (int i = 0; i < 11; i++)
                    Console.WriteLine(arr[i]);
            }
            catch(IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
