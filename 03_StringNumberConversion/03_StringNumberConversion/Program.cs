using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_StringNumberConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 123;
            string b = a.ToString();
            Console.WriteLine(b);

            float c = 3.14f;
            string d = c.ToString();
            Console.WriteLine(d);

            string e = "123456";
            int f = Convert.ToInt32(e);
            Console.WriteLine(f);

            string g = "1.2345";
            float h = float.Parse(g);
            Console.WriteLine(h);

            //Console.WriteLine(int.Parse("1.2345"));       //런타임 에러(format exception) 발생
        }
    }
}
