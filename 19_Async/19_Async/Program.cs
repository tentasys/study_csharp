using System;
using System.Threading.Tasks;

namespace _19_Async
{
    class Program
    {
        async static private void MyMethodAsycn(int count)
        {
            Console.WriteLine("C");
            Console.WriteLine("D");

            await Task.Run(async () =>
            {
                for(int i=1; i<=count; i++)
                {
                    Console.WriteLine($"{i}/{count} ...");
                    await Task.Delay(100);
                }
            });

            Console.WriteLine("G");
            Console.WriteLine("H");
        }
        static void Caller()
        {
            Console.WriteLine("A");
            Console.WriteLine("B");

            MyMethodAsycn(3);

            Console.WriteLine("E");
            Console.WriteLine("F");
        }
        static void Main(string[] args)
        {
            Caller();
            Console.ReadLine(); //얘를 안써주면 메인메소드가 너무 빨리 끝나버림
        }
    }
}
