using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_Ex1
{
    class NameCard
    {
        public int Age { get; set; }
        public String Name { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            NameCard MyCard = new NameCard()
            { Age = 27, Name = "희정" };

            Console.WriteLine("나이 : {0}", MyCard.Age);
            Console.WriteLine("이름 : {0}", MyCard.Name);
        }
    }
}
