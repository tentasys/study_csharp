using System;
using System.Windows.Forms;

namespace _20_UsingApplication
{
    class Program : Form
    {
        static void Main(string[] args)
        {
            Program form = new Program();

            //윈도우 클릭 시 발생하는 메소드
            form.Click += new EventHandler((sender, eventArgs) =>
            {
                Console.WriteLine("Closing Window...");
                Application.Exit();  //응용 프로그램을 종료시키는 메소드 -> 모든 윈도우를 닫은 뒤 Run메소드를 반환한다
            });

            Console.WriteLine("Starting Window Application...");
            Application.Run(form);  //응용 프로그램을 시작하도록 하는 메소드
            //Run() 뒤에는 자원을 정리하는 코드를 넣는다.
            Console.WriteLine("Exiting Window Application...");
        }
    }
}
