using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_SimpleWindow
{
    //System.Windows.Forms.Form 클래스에서 파생된 윈도우 폼 클래스 선언
    class Program : System.Windows.Forms.Form
    {
        static void Main(string[] args)
        {
            //클래스의 인스턴스를 Application.Run() 메소드의 매개변수로 넘겨 호출
            System.Windows.Forms.Application.Run(new Program());
        }
    }
}
