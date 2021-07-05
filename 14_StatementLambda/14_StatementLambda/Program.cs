using System;

namespace _14_StatementLambda
{
    class Program
    {
        delegate string Concatenate(string[] args);
        static void Main(string[] args)
        {
            Concatenate concat = (arr) =>
            {
                string result = "";
                foreach (string s in arr)
                    result += s;
                return result;
            };
            Console.WriteLine(concat(args));
        }
    }
}
