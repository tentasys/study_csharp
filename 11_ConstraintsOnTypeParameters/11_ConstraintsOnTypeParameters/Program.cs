using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_ConstraintsOnTypeParameters
{
    class StructArray<T> where T : struct
    {
        public T[] Array { get; set; }
        public StructArray(int size)
        {
            Array = new T[size];
        }
        public int Length
        {
            get { return Array.Length; }
        }
    }
    class RefArray<T> where T : class
    {
        public T[] Array { get; set; }
        public RefArray(int size)
        {
            Array = new T[size];
        }
    }
    class Base { 
        public Base()
        {
            Console.WriteLine("Base Created");
        }
    }
    class Derived : Base { 
        public Derived()
        {
            Console.WriteLine("Derived Created");
        }
    }
    class BaseArray<U> where U : Base
    {
        public U[] Array { get; set; }
        public BaseArray(int size)
        {
            Array = new U[size];
        }
        public void CopyArray<T> (T[] source) where T : U
        {
            source.CopyTo(Array, 0);
            Console.WriteLine("Copied");
        }
    }

    interface ITest
    {
        void Write();
    }
    class TestClass : ITest
    {
        public void Write()
        {
            Console.WriteLine("TestClass");
        }
    }

    class Program
    {
        public static T CreateInstance<T>() where T : new()
        {
            return new T();
        }

        public static void ShowMe<T>(T obj) where T : ITest
        {
            obj.Write();
        }

        static void Main(string[] args)
        {
            StructArray<int> a = new StructArray<int>(3);
            a.Array[0] = 0;
            a.Array[1] = 1;
            a.Array[2] = 2;
            for (int i = 0; i < 3; i++)
                Console.Write($"{a.Array[i]} ");
            Console.WriteLine();

            RefArray<StructArray<double>> b = new RefArray<StructArray<double>>(3);
            b.Array[0] = new StructArray<double>(5);
            b.Array[1] = new StructArray<double>(10);
            b.Array[2] = new StructArray<double>(1005);
            for (int i = 0; i < 3; i++)
                Console.Write($"{b.Array[i].Length} ");
            Console.WriteLine();

            BaseArray<Base> c = new BaseArray<Base>(3);
            c.Array[0] = new Base();
            c.Array[1] = new Derived();
            c.Array[2] = CreateInstance<Base>();
            Console.WriteLine();

            BaseArray<Derived> d = new BaseArray<Derived>(3);
            d.Array[0] = new Derived();     //Base형식은 여기에 할당 불가
            d.Array[1] = CreateInstance<Derived>();
            d.Array[2] = CreateInstance<Derived>();
            Console.WriteLine();

            BaseArray<Derived> e = new BaseArray<Derived>(3);
            e.CopyArray<Derived>(d.Array);
            Console.WriteLine();

            ShowMe<TestClass>(new TestClass());
        }
    }
}
