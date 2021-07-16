using System;
using System.Windows.Forms;

namespace _20_FormStyle
{
    class Program : Form
    {
        static void Main(string[] args)
        {
            Program form = new Program();

            form.Width = 400;
            form.MouseDown += new MouseEventHandler(form_MouseDown);

            Application.Run(form);
        }
        static void form_MouseDown(object sender, MouseEventArgs e)
        {
            Form form = (Form)sender;

            if(e.Button == MouseButtons.Left)
            {
                form.MaximizeBox = true;
                form.MinimizeBox = true;
                form.Text = "최소화/최대화 버튼이 활성화되었습니다.";
            }
            else if (e.Button == MouseButtons.Right)
            {
                form.MaximizeBox = false;
                form.MinimizeBox = false;
                form.Text = "최소화/최대화 버튼이 비활성화되었습니다.";
            }
        }
    }
}
