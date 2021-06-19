using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_Ex2
{
    class Program
    {
        static void Main(string[] args) { 
            var nameCard = new { Name = "강희정", Age = 27 };
            Console.WriteLine("이름:{0}, 나이:{1}", nameCard.Name, nameCard.Age);

            var complex = new { Real = 3, Imaginary = -12 };
            Console.WriteLine("Real:{0}, Imaginary:{1}", complex.Real, complex.Imaginary);
        }
    }
}
