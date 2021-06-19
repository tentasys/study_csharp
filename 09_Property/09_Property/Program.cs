using System;

namespace _09_Property
{
    class BirtydayInfo
    {
        private string name;
        private DateTime birtyday;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public DateTime Birtyday
        {
            get { return birtyday; }
            set { birtyday = value; }
        }
        public int Age
        {
            get { return new DateTime(DateTime.Now.Subtract(birtyday).Ticks).Year; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BirtydayInfo birth = new BirtydayInfo();
            birth.Name = "서현";
            birth.Birtyday = new DateTime(1991, 6, 28);

            Console.WriteLine($"Name : {birth.Name}");
            Console.WriteLine($"Birthday : {birth.Birtyday.ToShortDateString()}");
            Console.WriteLine($"Age : {birth.Age}");
        }
    }
}
