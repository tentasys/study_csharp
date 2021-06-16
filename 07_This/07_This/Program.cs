using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_This
{
    class Program
    {
        class Employee
        {
            private string Name;
            private string Position;

            public void SetName(string Name)
            {
                this.Name = Name;
            }
            public string GetName()
            {
                return Name;
            }
            public void SetPositon(string Position)
            {
                this.Position = Position;
            }
            public string GetPosition()
            {
                return this.Position;
            }
        }
        static void Main(string[] args)
        {
            Employee pooh = new Employee();
            pooh.SetName("Pooh");
            pooh.SetPositon("Waiter");
            Console.WriteLine($"{pooh.GetName()} {pooh.GetPosition()}");

            Employee tigger = new Employee();
            tigger.SetName("Tigger");
            tigger.SetPositon("Cleaner");
            Console.WriteLine($"{tigger.GetName()} {tigger.GetPosition()}");
        }
    }
}
