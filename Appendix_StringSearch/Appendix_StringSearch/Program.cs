using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using System.Console;   //console은 네임스페이스가 아니라 형식이므로 이렇게 사용할 수 없다. 반드시 static 써야 함
using static System.Console;

namespace Appendix_StringSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            string greeting = "Good Morning";
            WriteLine(greeting);
            
            WriteLine("Index Of 'Good' : {0}", greeting.IndexOf("Good"));
            WriteLine("Index Of '0' : {0}", greeting.IndexOf('o'));

            WriteLine("LastIndexOf 'Good' : {0}", greeting.LastIndexOf("Good"));
            WriteLine("LastIndexOf 'o' : {0}", greeting.LastIndexOf('o'));

            //이 문자열의 인덱스가 아니라 시작하는지 아닌지 판별
            WriteLine("StartsWith 'Good' : {0}", greeting.StartsWith("Good"));
            WriteLine("StartsWith 'Morning' : {0}", greeting.StartsWith("Morning"));

            //이 문자열의 인덱스가 아니라 끝나는지 아닌지 판별
            WriteLine("EndsWith 'Good' : {0}", greeting.EndsWith("Good"));
            WriteLine("EndsWith 'Morning' : {0}", greeting.EndsWith("Morning"));

            WriteLine("Contains 'Evening' : {0}", greeting.Contains("Evening"));
            WriteLine("Contains 'Morning' : {0}", greeting.Contains("Morning"));

            WriteLine("Replaced 'Morning' with 'Evening' : {0}", greeting.Replace("Morning", "Evening"));
        }
    }
}
