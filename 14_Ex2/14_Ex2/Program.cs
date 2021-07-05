using System;

namespace _14_Ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 11, 22, 33, 44, 55 };

            foreach(int a in array)
            {
                Action action = () => Console.WriteLine(a * a);
                action.Invoke();
            }
        }
    }
}
