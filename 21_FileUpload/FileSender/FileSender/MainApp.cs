﻿using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using FUP;

namespace FileSender
{
    class MainApp
    {
        const int CHUNK_SIZE = 4096;
        static void Main(string[] args)
        {
            if(args.Length < 2)
            {
                Console.WriteLine("사용법 : {0} <Server IP> <File Path>", Process.GetCurrentProcess().ProcessName);
                return;
            }

            string serverIp = args[0];
            const int serverPort = 5425;
            string filepath = args[1];

            try
            {
                //클라이언트는 OS에서 할당한 IP주소와 포트에 바인딩
                IPEndPoint clientAddress = new IPEndPoint(0, 0);
                IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse(serverIp), serverPort);

                Console.WriteLine("클라이언트 : {0}, 서버 : {1}", clientAddress.ToString(), serverAddress.ToString());

                uint msgId = 0;

                //파일 전송을 요청하는 메시지. 파일이름과 파일크기로 구성되어 있음
                Message reqMsg = new Message();
                reqMsg.Body = new BodyRequest()
                {
                    FILESIZE = new FileInfo(filepath).Length,
                    FILENAME = System.Text.Encoding.Default.GetBytes(filepath)
                };
                reqMsg.Header = new Header()
                {
                    MSGID = msgId++,
                    MSGTYPE = CONSTANTS.REQ_FILE_SEND,
                    BODYLEN = (uint)reqMsg.Body.GetSize(),
                    FRAGMENTED = CONSTANTS.NOT_FRAGMENTED,
                    LASTMSG = CONSTANTS.LASTMSG,
                    SEQ = 0
                };

                TcpClient client = new TcpClient(clientAddress);
                client.Connect(serverAddress);
                NetworkStream stream = client.GetStream();

                MessageUtil.Send(stream, reqMsg);   //클라이언트는 서버에 접속하자마자 파일 전송 요청 메시지를 보냄
                Message rspMsg = MessageUtil.Receive(stream); //서버의 응답 받기

                if(rspMsg.Header.MSGTYPE != CONSTANTS.REP_FILE_SEND)
                {
                    Console.WriteLine("정상적인 서버 응답이 아닙니다. {0}", rspMsg.Header.MSGTYPE);
                    return;
                }

                if(((BodyResponse)rspMsg.Body).RESPONSE == CONSTANTS.DENIED)
                {
                    Console.WriteLine("서버에서 파일 전송을 거부했습니다.");
                    return;
                }

                //서버에서 전송 요청을 수락했다면 파일 스트림을 열어 서버로 보낼 준비를 함ㄷ
                using(Stream fileStream = new FileStream(filepath, FileMode.Open))
                {
                    byte[] rbytes = new byte[CHUNK_SIZE];
                    long readValue = BitConverter.ToInt64(rbytes, 0);

                    int totalRead = 0;
                    ushort msgSeq = 0;
                    byte fragmented = (fileStream.Length < CHUNK_SIZE) ? CONSTANTS.NOT_FRAGMENTED : CONSTANTS.FRAGMENTED; //버퍼 사이즈보다 작으면 단일 파일. 아니면 분할로 전송

                    while(totalRead < fileStream.Length)
                    {
                        //Console.WriteLine("totalRead :{0}, fielStream.Length:{1}", totalRead, fileStream.Length);
                        int read = fileStream.Read(rbytes, 0, CHUNK_SIZE);
                        totalRead += read;
                        Message fileMsg = new Message();

                        byte[] sendBytes = new byte[read];
                        Array.Copy(rbytes, 0, sendBytes, 0, read);
                        fileMsg.Body = new BodyData(sendBytes);
                        fileMsg.Header = new Header()
                        {
                            MSGID = msgId,
                            MSGTYPE = CONSTANTS.FILE_SEND_DATA,
                            BODYLEN = (uint)fileMsg.Body.GetSize(),
                            FRAGMENTED = fragmented,
                            LASTMSG = (totalRead < fileStream.Length) ? CONSTANTS.NOT_LASTMSG : CONSTANTS.LASTMSG,
                            SEQ = msgSeq++
                        };

                        Console.Write("#");
                        MessageUtil.Send(stream, fileMsg); //모든 파일의 내용이 전송될 때까지 파일 스트림을 0x03메시지에 담아 서버로 보냄
                    }

                    Console.WriteLine();

                    //서버에서 파일을 제대로 받았는지에 대한 응답
                    Message rstMsg = MessageUtil.Receive(stream);

                    BodyResult result = ((BodyResult)rstMsg.Body);
                    Console.WriteLine("파일 전송 성공 : {0}", result.RESULT == CONSTANTS.SUCCESS);
                }
                stream.Close();
                client.Close();
            }
            catch (SocketException e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("클라이언트를 종료합니다.");
        }
    }
}
