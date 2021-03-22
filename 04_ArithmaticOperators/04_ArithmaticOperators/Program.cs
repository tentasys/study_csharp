using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_ArithmaticOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 111 + 222;
            Console.WriteLine($"a : {a}");

            int b = a - 100;
            Console.WriteLine($"b : {b}");

            int c = b * 10;
            Console.WriteLine($"c : {c}");

            //피연사자 중 한쪽이 부동 소수형이면 부동 소수형 버전의 연산자가 사용되며, 나머지 피연산자도 부동소수형으로 형변환된다.
            double d = c / 6.3;
            Console.WriteLine($"d : {d}");

            Console.WriteLine($"22 / 7 = {22 / 7}({22 % 7})");
        }
    }
}
