using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Structure
{
    struct Point3D
    {
        public int X;
        public int Y;
        public int Z;
        public Point3D(int X, int Y, int Z) //구조체의 생성자 -> 구조체의 모든 필드를 할당해야 한다.
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }
        public override string ToString() //System.Object 형식의 ToString() 메소드 오버라이딩
        {
            return string.Format($"{X}, {Y}, {Z}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Point3D p3d1;
            p3d1.X = 10;
            p3d1.Y = 20;
            p3d1.Z = 40;

            Console.WriteLine(p3d1.ToString());

            Point3D p3d2 = new Point3D(100, 200, 300);
            Point3D p3d3 = p3d2;
            p3d3.Z = 400;

            Console.WriteLine(p3d2.ToString());
            Console.WriteLine(p3d3.ToString());
        }
    }
}
