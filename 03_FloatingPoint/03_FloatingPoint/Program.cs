using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_FloatingPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            float a = 3.1415_9265_3589_7932_3846f;
            Console.WriteLine(a);       //결과 : 3.141593

            double b = 3.1415_9265_3589_7932_3846;  //float형식 변수에 값을 직접 할당하려면 숫자 뒤에 f을 붙여줘야 함
            Console.WriteLine(b);       //결과 : 3.14159265358979
        }
    }
}
