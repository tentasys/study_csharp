using System;

namespace _13_Ex2
{
    delegate void MyDelegate(int a);
    class Market
    {
        public event MyDelegate CustomerEvent;
        public void BuySomething(int CustomerNo)
        {
            if (CustomerNo == 30)
                CustomerEvent(CustomerNo);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Market market = new Market();
            
            market.CustomerEvent += new MyDelegate(delegate (int a)
            {
                Console.WriteLine("축하합니다! {0}번째 고객 이벤트에 당첨되셨습니다.", a);
            });
            /*
            이렇게 이벤트 처리기가 구현되지 않아도 일단 컴파일은 된다
            market.CustomerEvent += new MyDelegate(delegate (int a)
            {
                Console.WriteLine("축하합니다! {0}번째 고객 이벤트에 당첨되셨습니다.", a);
            });*/

            for (int i = 0; i < 100; i += 10)
                market.BuySomething(i);
        }
    }
}
