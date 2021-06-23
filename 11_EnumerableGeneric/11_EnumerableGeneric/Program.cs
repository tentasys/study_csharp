using System;
using System.Collections.Generic;
using System.Collections;

namespace _11_EnumerableGeneric
{
    class MyList<T> : IEnumerable<T>, IEnumerator<T>
    {
        private T[] array;
        int position = -1;  //컬렉션의 현재 위치를 다루는 변수
        public MyList()
        {
            array = new T[3];
        }
        public T this[int index]
        {
            get
            {
                return array[index];
            }
            set
            {
                if (index >= array.Length)
                {
                    Array.Resize<T>(ref array, index + 1);
                    Console.WriteLine($"Array Resized : {array.Length}");
                }
                array[index] = value;
            }
        }

        public T Current   //현재 위치의 요소를 반환
        {
            get
            {
                return array[position];
            }
        }
        object IEnumerator.Current
        {
            get { return array[position]; }
        }

        public bool MoveNext()      //다음 위치의 요소로 이동
        {
            if (position == array.Length - 1)
            {
                Reset();
                return false;
            }

            position++;
            return (position < array.Length);
        }

        public void Reset()     //요소의 위치를 첫 요소의 앞으로 옮김
        {
            position = -1;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < array.Length; i++)
                yield return (array[i]);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < array.Length; i++)
                yield return (array[i]);
        }
        public void Dispose()
        { }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyList<string> str_list = new MyList<string>();
            str_list[0] = "abc";
            str_list[1] = "def";
            str_list[2] = "ghi";
            str_list[3] = "jkl";
            str_list[4] = "mno";

            foreach (string e in str_list)
                Console.WriteLine(e);

            MyList<int> int_list = new MyList<int>();
            for (int i = 0; i < 5; i++)
                int_list[i] = i;

            foreach (int e in int_list)
                Console.WriteLine(e);
        }
    }
}
