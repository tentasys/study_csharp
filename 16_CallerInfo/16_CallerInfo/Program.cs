using System;
using System.Runtime.CompilerServices;

namespace _16_CallerInfo
{
    public static class Trace
    {
        public static void WriteLine(string message, [CallerFilePath] string file = "", [CallerLineNumber] int line = 0, [CallerMemberName] string member = "")
        {
            Console.WriteLine($"{file}(line:{line}) {member}: {message}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Trace.WriteLine("즐거운 프로그래밍!");
        }
    }
}
