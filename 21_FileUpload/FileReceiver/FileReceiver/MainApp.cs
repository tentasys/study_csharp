using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using FUP;

namespace FileReceiver
{
    class MainApp
    {
        static void Main(string[] args)
        {
            if(args.Length < 1)
            {
                Console.WriteLine("사용법 : {0} <Directory>", Process.GetCurrentProcess().ProcessName);
                return;
            }
            uint msgId = 0;

            string dir = args[0]; //경로가 없으면 만들자
            if (Directory.Exists(dir) == false)
                Directory.CreateDirectory(dir);

            const int bindPort = 5245; //정의해놓은 서버 포트
            TcpListener server = null;
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
