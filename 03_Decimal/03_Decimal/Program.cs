using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Decimal
{
    class Program
    {
        static void Main(string[] args)
        {
            float   a = 3.1415_9265_3589_7932_3846_2643_3832_79f;   //float 할당은 f 필요
            double  b = 3.1415_9265_3589_7932_3846_2643_3832_79;    //기본이 double형
            decimal c = 3.1415_9265_3589_7932_3846_2643_3832_79m;   //decimal 할당은 m 필요

            //각 형식별로 정밀도에 한계가 있기 때문에 출력되는 자릿수가 다르다 
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
        }
    }
}
