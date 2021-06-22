using System;
using System.Collections;

namespace _10_Yield
{
    class MyEnumerator
    {
        int[] numbers = { 1, 2, 3, 4, 5 };
        public IEnumerator GetEnumerator()
        {
            yield return numbers[0];  //현재 메소드의 실행을 일시정지 시켜놓고 호출자에게 결과를 반환
            yield return numbers[1];
            yield return numbers[2];
            yield break;
            yield return numbers[3];
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new MyEnumerator();
            foreach (int i in obj)
                Console.WriteLine(i);
        }
    }
}
