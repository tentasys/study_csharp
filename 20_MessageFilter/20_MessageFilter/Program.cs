using System;
using System.Windows.Forms;

namespace _20_MessageFilter
{
    class MessageFilter : IMessageFilter
    {
        public bool PreFilterMessage(ref Message m)
        {
            //너무 많이 발생하는 메시지들이라 제외
            if (m.Msg == 0x0F || m.Msg == 0xA0 || m.Msg == 0x200 || m.Msg == 0x113)
                return false;  //메시지를 건드리지 않았으니 응용 프로그램이 처리해야 한다

            Console.WriteLine($"{m.ToString()} : {m.Msg}");

            if (m.Msg == 0x201)
                Application.Exit();

            return true;    //메시지를 처리했으니 프로그램은 관심가지지 말아라
        }
    }
    class Program : Form
    {
        static void Main(string[] args)
        {
            Application.AddMessageFilter(new MessageFilter());      //응용 프로그램에 메시지 필터 설치
            Application.Run(new Program());
        }
    }
}
