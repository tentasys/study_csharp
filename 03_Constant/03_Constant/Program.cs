using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Constant
{
    class Program
    {
        static void Main(string[] args)
        {
            const int MAX_INT = 2147483647;
            const int MIN_INT = -2147483648;

            Console.WriteLine(MAX_INT);
            Console.WriteLine(MIN_INT);

            //MAX_INT = 3;      //컴파일 에러
        }
    }
}
