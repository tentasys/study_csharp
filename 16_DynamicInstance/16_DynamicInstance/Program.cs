using System;
using System.Reflection;

namespace _16_DynamicInstance
{
    class Profile
    {
        private string name;
        private string phone;
        public Profile()
        {
            name = ""; phone = "";
        }
        public Profile(string name, string phone)
        {
            this.name = name;
            this.phone = phone;
        }
        public void Print()
        {
            Console.WriteLine($"{name}, {phone}");
        }
        public void Print2(string msg)
        {
            Console.WriteLine($"{name}'s msg : {msg}");
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Phone
        {
            get { return name; }
            set { phone = value; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Type type = Type.GetType("_16_DynamicInstance.Profile");
            MethodInfo methodInfo = type.GetMethod("Print");
            PropertyInfo nameProperty = type.GetProperty("Name");
            PropertyInfo phoneProperty = type.GetProperty("Phone");

            object profile = Activator.CreateInstance(type, "강희정", "123-4567");
            methodInfo.Invoke(profile, null);

            profile = Activator.CreateInstance(type);
            nameProperty.SetValue(profile, "테르", null);
            phoneProperty.SetValue(profile, "1111", null);

            Console.WriteLine("{0}, {1}", nameProperty.GetValue(profile, null), phoneProperty.GetValue(profile, null));

            methodInfo = type.GetMethod("Print2");
            string[] param = { "test"};
            methodInfo.Invoke(profile, param);
        }
    }
}
