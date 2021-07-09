using System;
using System.IO;

namespace _18_BasicIO
{
    class Program
    {
        static void Main(string[] args)
        {
            long someValue = 0x123456789ABCDEF0;
            Console.WriteLine("{0,-1} : 0x{1:X16}", "Original Data", someValue);  //X16에서의 X는 16진수를 의미, 16은 16자리를 의미

            //original data
            Stream outstream = new FileStream("a.dat", FileMode.Create);
            byte[] wBytes = BitConverter.GetBytes(someValue); // someValue의 8바이트를 바이트 배열에 나눠 넣기

            //byte array
            Console.Write("{0,-13} : ", "Byte Array");
            foreach (byte b in wBytes)
                Console.Write("{0:X2} ", b);
            Console.WriteLine();

            outstream.Write(wBytes, 0, wBytes.Length); //Write()메소드를 이용해서 단번에 파일에 기록
            outstream.Close();

            //Read
            Stream inStream = new FileStream("a.dat", FileMode.Open);
            byte[] rbytes = new byte[8];

            int i = 0;
            while (inStream.Position < inStream.Length)
                rbytes[i++] = (byte)inStream.ReadByte();

            long readValue = BitConverter.ToInt64(rbytes, 0);

            Console.WriteLine("{0,-13} : 0x{1:X16} ", "Read Data", readValue);
            inStream.Close();
        }
    }
}
