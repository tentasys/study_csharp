using System;
using System.Drawing;
using System.Windows.Forms;

namespace _20_FormBackground
{
    class Program : Form
    {
        Random rand;
        public Program()
        {
            rand = new Random();

            this.MouseWheel += new MouseEventHandler(Program_MouseWheel);
            this.MouseDown += new MouseEventHandler(Program_MouseDown);
        }
        void Program_MouseDown(object sendet, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                Color oldColor = this.BackColor;
                this.BackColor = Color.FromArgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
            }
            else if(e.Button == MouseButtons.Right)
            {
                if (this.BackgroundImage != null)
                {
                    this.BackgroundImage = null;
                    return;
                }
                string file = "sample.jpg";
                if (System.IO.File.Exists(file) == false)
                    MessageBox.Show("이미지 파일이 없습니다.");
                else
                    this.BackgroundImage = Image.FromFile(file);
            }
        }
        void Program_MouseWheel(object sender, MouseEventArgs e)
        {
            this.Opacity = this.Opacity + (e.Delta > 0 ? 0.1 : -0.1);
            Console.WriteLine($"Opacity : {this.Opacity}");
        }
        static void Main(string[] args)
        {
            Application.Run(new Program());
        }
    }
}
