﻿using System;
using System.Collections.Generic;

namespace _14_ExpressionBodiedMember
{
    class FreindList
    {
        private List<string> list = new List<string>();

        public void Add(string name) => list.Add(name);
        public void Remove(string name) => list.Remove(name);
        public void PrintAll()
        {
            foreach (var s in list) Console.WriteLine(s);
        }
        public FreindList() => Console.WriteLine("FriendList()");
        ~FreindList() => Console.WriteLine("~FriendList()");

        //public int Capacity => list.Capacity(); //읽기 전용
        public int Capacity //속성
        {
            get => list.Capacity;
            set => list.Capacity = value;
        }
        //public string this[int index] => list[index] //읽기 전용
        public string this[int index]
        {
            get => list[index];
            set => list[index] = value;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            FreindList obj = new FreindList();
            obj.Add("Eeny");
            obj.Add("Meeny");
            obj.Add("Miny");
            obj.Remove("Eeny");
            obj.PrintAll();

            Console.WriteLine($"{obj.Capacity}");
            obj.Capacity = 10;
            Console.WriteLine($"{obj.Capacity}");

            Console.WriteLine($"{obj[0]}");
            obj[0] = "Moe";
            obj.PrintAll();
        }
    }
}
