using System;
using System.Threading;

namespace _19_WaitPulse
{
    class Counter
    {
        const int LOOP_COUNT = 1000;

        readonly object thisLock;
        bool lockedCount = false;       //스레드가 블록된 조건을 검사하기 위해 사용 - count변수를 다른 스레드가 사용하고 있는지 판별
        private int count;              //각 스레드가 너무 오랫동안 count변수를 혼자 사용하는것을 막기 위해 사용
        public int Count
        {
            get { return count; }
        }
        public Counter()
        {
            thisLock = new object();
            count = 0;
        }

        public void Increase()
        {
            int loopCount = LOOP_COUNT;
            
            while(loopCount-- > 0)
            {
                lock(thisLock)
                {
                    while (count > 0 || lockedCount == true) //조건이 만족하는동안 스레드가 블록되며 Pulse 호출 전까지 WaitSleepJoin상태로 남는다.
                        Monitor.Wait(thisLock);

                    lockedCount = true;
                    count++;
                    Console.WriteLine($"Increase : {count}");
                    lockedCount = false;    //false로 만든 후에 다른 스레드를 깨움

                    Monitor.Pulse(thisLock);
                }
            }
        }
        public void Decrease()
        {
            int loopCount = LOOP_COUNT;

            while (loopCount-- > 0)
            {
                lock (thisLock)
                {
                    while (count < 0 || lockedCount == true) //조건이 만족하는동안 스레드가 블록되며 Pulse 호출 전까지 WaitSleepJoin상태로 남는다.
                        Monitor.Wait(thisLock);

                    lockedCount = true;
                    count--;
                    Console.WriteLine($"Decrease : {count}");
                    lockedCount = false;    //false로 만든 후에 다른 스레드를 깨움

                    Monitor.Pulse(thisLock);
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Counter counter = new Counter();

            Thread incThread = new Thread(new ThreadStart(counter.Increase));
            Thread decThread = new Thread(new ThreadStart(counter.Decrease));

            incThread.Start();
            decThread.Start();

            incThread.Join();
            decThread.Join();

            Console.WriteLine(counter.Count);
        }
    }
}
