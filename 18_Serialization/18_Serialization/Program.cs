using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace _18_Serialization
{
    [Serializable]
    class NameCard
    {
        public string Name{get;set;}
        public string Phone { get; set; }
        public int Age { get; set; }
        [NonSerialized]
        public int num = 0;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Stream ws = new FileStream("a.dat", FileMode.Create);
            BinaryFormatter serializer = new BinaryFormatter();

            NameCard nc = new NameCard();
            nc.Name = "강희정";
            nc.Phone = "010-1234-1234";
            nc.Age = 27;
            nc.num = 7;

            serializer.Serialize(ws, nc);
            ws.Close();

            Stream rs = new FileStream("a.dat", FileMode.Open);
            BinaryFormatter deserializer = new BinaryFormatter();

            NameCard nc2;
            nc2 = (NameCard)deserializer.Deserialize(rs);
            rs.Close();

            Console.WriteLine($"Name: {nc2.Name}");
            Console.WriteLine($"Phone : {nc2.Phone}");
            Console.WriteLine($"Age : {nc2.Age}");
            Console.WriteLine($"num : {nc2.num}"); //input은 7이었지만 직렬화/역직렬화되지 않아 0으로 출력됨
        }
    }
}
