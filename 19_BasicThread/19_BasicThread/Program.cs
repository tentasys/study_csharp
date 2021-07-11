using System;
using System.Threading;

namespace _19_BasicThread
{
    class Program
    {
        static void DoSomething()
        {
            for(int i=0; i<5; i++)
            {
                Console.WriteLine($"Dosomething : {i}");
                Thread.Sleep(10); // sleep : 다른 스레드도 CPU를 사용할 수 있도록 CPU점유를 내려놓는 메소드. 매개변수는 밀리초 단위
            }
        }
        static void Main(string[] args)
        {
            Thread t1 = new Thread(new ThreadStart(DoSomething));

            Console.Write("Starting Thread...");
            t1.Start();

            //스레드의 메소드가 실행되는 동시에 메인 스레드의 반복문도 실행
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Main : {i}");
                Thread.Sleep(10);
            }

            Console.WriteLine("Waiting until thread stops...");
            t1.Join();

            Console.WriteLine("Finished");
        }
    }
}
