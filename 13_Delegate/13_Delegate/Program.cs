using System;

namespace _13_Delegate
{
    delegate int MyDelegate(int a, int b);
    class Calculator
    {
        //인스턴스 메소드
        public int Plus(int a, int b) { return a + b; }
        //스태틱 메소드
        public static int Minus(int a, int b) { return a - b; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Calculator Calc = new Calculator();
            MyDelegate Callback;

            Callback = new MyDelegate(Calc.Plus);
            Console.WriteLine(Callback(3, 4));

            Callback = new MyDelegate(Calculator.Minus);
            Console.WriteLine(Callback(5, 2));
        }
    }
}
