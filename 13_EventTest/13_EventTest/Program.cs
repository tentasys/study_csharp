using System;

namespace _13_EventTest
{
    delegate void EventHandler(string message);
    class MyNotifier
    {
        public event EventHandler SomethingHappend;

        public void DoSomething(int number)
        {
            int temp = number % 10;
            if(temp != 0 && temp % 3 == 0)
            {
                SomethingHappend(String.Format("{0} : 짝", number));
            }
        }
    }
    class Program
    {
        static public void MyHandler(string message)
        {
            Console.WriteLine(message);
        }
        static void Main(string[] args)
        {
            MyNotifier notifier = new MyNotifier();
            notifier.SomethingHappend += new EventHandler(MyHandler);
            //notifier.SomethingHappend("테스트"); //이벤트는 객체 외부에서 직접 호출할 수 없다

            for(int i=1; i<30; i++)
            {
                notifier.DoSomething(i);
            }
        }
    }
}
