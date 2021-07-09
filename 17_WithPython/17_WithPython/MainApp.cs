using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;
using IronPython.Hosting;

namespace _17_WithPython
{
    class MainApp
    {
        static void Main(string[] args)
        {
            ScriptEngine engine = Python.CreateEngine();
            ScriptScope scope = engine.CreateScope();
            scope.SetVariable("n", "강희정");
            scope.SetVariable("p", "010-1234-1234");

            ScriptSource soucre = engine.CreateScriptSourceFromString(
                @"
class NameCard :
    name = ''
    phone = ''

    def __init__(self, name, phone) :
        self.name = name
        self.phone = phone

    def printNameCard(self) :
        print self.name +', '+self.phone

NameCard(n, p)
");
            dynamic result = soucre.Execute(scope); //34행의 NameCard 객체 번환
            result.printNameCard();
            Console.WriteLine("{0}, {1}", result.name, result.phone);
        }
    }
}
