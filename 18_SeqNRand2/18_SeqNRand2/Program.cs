using System;
using System.IO;

namespace _18_SeqNRand2
{
    class Program
    {
        static void Main(string[] args)
        {
            Stream inStream = new FileStream("a.dat", FileMode.Open);

            Console.WriteLine("---- Start ----");
            Console.Write($"{inStream.ReadByte()} "); //1
            Console.Write($"{inStream.ReadByte()} "); //2
            Console.Write($"{inStream.ReadByte()} "); //3

            inStream.Seek(5, SeekOrigin.Current);     //이동

            Console.Write($"{inStream.ReadByte()} "); //4

            Console.WriteLine();
            inStream.Close();
        }
    }
}
