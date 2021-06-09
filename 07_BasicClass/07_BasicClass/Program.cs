using System;

namespace _07_BasicClass
{
    class Cat
    {
        public string Name;
        public string color;

        public void Meow()
        {
            Console.WriteLine($"{Name} : 야옹");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Cat kitty = new Cat()
            {
                color = "하얀색",
                Name = "키티"
            };
        
            
            kitty.Meow();
            Console.WriteLine($"{kitty.Name} : {kitty.color}");

            Cat nero = new Cat();
            nero.color = "검은색";
            nero.Name = "네로";
            nero.Meow();
            Console.WriteLine($"{nero.Name} : {nero.color}");
        }
    }
}
