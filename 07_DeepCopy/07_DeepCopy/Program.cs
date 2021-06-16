using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_DeepCopy
{
    class MyClass
    {
        public int MyField1;
        public int MyField2;

        public MyClass DeepCopy()
        {
            MyClass newCopy = new MyClass();
            newCopy.MyField1 = this.MyField1;
            newCopy.MyField2 = this.MyField2;

            return newCopy;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Shallow Copy");
            {
                MyClass src = new MyClass();
                src.MyField1 = 10;
                src.MyField2 = 20;

                MyClass dest = src;
                dest.MyField2 = 30;

                Console.WriteLine($"{src.MyField1} {src.MyField2}");
                Console.WriteLine($"{dest.MyField1} {dest.MyField2}");
            }

            Console.WriteLine("Deep Copy");
            {
                MyClass src = new MyClass();
                src.MyField1 = 10;
                src.MyField2 = 20;

                MyClass dest = src.DeepCopy();
                dest.MyField2 = 30;

                Console.WriteLine($"{src.MyField1} {src.MyField2}");
                Console.WriteLine($"{dest.MyField1} {dest.MyField2}");
            }
        }
    }
}
