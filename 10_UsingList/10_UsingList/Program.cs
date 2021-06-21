using System;
using System.Collections;

namespace _10_UsingList
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList();
            for (int i = 0; i < 5; i++)
                list.Add(i);

            foreach (object obj in list)
                Console.Write($"{obj} ");
            Console.WriteLine();

            list.RemoveAt(2);

            foreach (object obj in list)
                Console.Write($"{obj} ");
            Console.WriteLine();

            list.Insert(2, 2);

            foreach (object obj in list)
                Console.Write($"{obj} ");
            Console.WriteLine();

            //list는 object형을 받으므로 다양한 형식의 객체를 담을 수 있다
            list.Add("abc");
            list.Add("def");

            for (int i = 0; i < list.Count; i++)
                Console.Write($"{list[i]} ");
            Console.WriteLine();
        }
    }
}
