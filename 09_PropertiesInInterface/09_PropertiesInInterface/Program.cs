using System;

namespace _09_PropertiesInInterface
{
    interface INamedValue
    {
        //자동구현 프로퍼티처럼 구현이 없지만 C#컴파일러는 인터페이스의 프로퍼티에 대해서는 자동으로 구현해주지 않는다. -> 인터페이스는 어떤 구현도 가지지 않는다.
        String Name { get; set; }
        String Value { get; set; }
    }
    //INamedValue인터페이스를 상속하는 클래스는 반드시 name과 value를 구현해야 한다. 자동구현 프로퍼티를 사용해도 된다.
    class NamedValue : INamedValue
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            NamedValue name = new NamedValue()
            { Name = "이름", Value = "강희정" };

            NamedValue height = new NamedValue()
            { Name = "키", Value = "167cm" };

            NamedValue weight = new NamedValue()
            { Name = "몸무게", Value = "56kg" };

            Console.WriteLine($"{name.Name} : {name.Value}");
            Console.WriteLine($"{height.Name} : {height.Value}");
            Console.WriteLine($"{weight.Name} : {weight.Value}");
        }
    }
}
