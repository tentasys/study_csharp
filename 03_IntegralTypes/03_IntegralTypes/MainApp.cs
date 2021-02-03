using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_IntegralTypes
{
    class MainApp
    {
        static void Main(string[] args)
        {
            sbyte a = -10;      //부호 없는 1바이트 정수
            byte b = 40;        //부호 있는 1바이트 정수

            Console.WriteLine($"a={a}, b={b}");

            short c = -30000;   //부호 있는 2바이트 정수
            ushort d = 60000;   //부호 없는 2바이트 정수

            Console.WriteLine($"c={c}, d={d}");

            int e = -1000_0000;     //부호 있는 4바이트 정수
            uint f = 3_0000_0000;   //부호 없는 4바이트 정수

            Console.WriteLine($"e={e}, f={f}");

            long g = -5000_0000_0000;           //부호 있는 8바이트 정수
            ulong h = 200_0000_0000_0000_0000;  //부호 없는 8바이트 정수

            Console.WriteLine($"g={g}, h={h}");
        }
    }
}
