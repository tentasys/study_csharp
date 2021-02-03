using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_SignedUnsigned
{
    class Program
    {
        static void Main(string[] args)
        {
            byte a = 255;           //byte형식 255는 1111 1111
            sbyte b = (sbyte)a;     //(sbyte)는 변수를 sbyte 형식으로 변환하는 연산자

            Console.WriteLine(a);
            Console.WriteLine(b);   //오버플로우
        }
    }
}
