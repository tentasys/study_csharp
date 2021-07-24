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

            const int bindPort = 5425; //정의해놓은 서버 포트
            TcpListener server = null;
            try
            {
                //IP주소를 0으로 입력하면 127.0.0.1뿐만 아니라 OS에 할당되어 있는 어떤 주소로도 서버에 접속이 가능
                IPEndPoint localAddress = new IPEndPoint(0, bindPort);

                server = new TcpListener(localAddress);
                server.Start();

                Console.WriteLine("파일 업로드 서버 시작...");

                while(true)
                {
                    //클라이언트가 접속하는걷을 받기 위해 대기
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("클라이언트 접속 : {0}", ((IPEndPoint)client.Client.RemoteEndPoint).ToString());

                    //스트림을 통해 읽고 쓰기 수행
                    NetworkStream stream = client.GetStream();
                    Message reqMsg = MessageUtil.Receive(stream);

                    //파일 전송 요청이 아니면 넘기기
                    if(reqMsg.Header.MSGTYPE != CONSTANTS.REQ_FILE_SEND)
                    {
                        stream.Close();
                        client.Close();
                        continue;
                    }

                    BodyRequest reqBody = (BodyRequest)reqMsg.Body;

                    Console.WriteLine("파일 업로드 요청이 왔습니다. 수락하시겠습니까? yes/no");
                    string answer = Console.ReadLine();

                    Message rspMsg = new Message();
                    rspMsg.Body = new BodyResponse()  //파일 전송 요청에 사용할 응답
                    {
                        MSGID = reqMsg.Header.MSGID,
                        RESPONSE = CONSTANTS.ACCEPTED
                    };
                    
                    rspMsg.Header = new Header()
                    {
                        MSGID = msgId++,
                        MSGTYPE = CONSTANTS.REP_FILE_SEND,
                        BODYLEN = (uint)rspMsg.Body.GetSize(), //4+1 = 5;
                        FRAGMENTED = CONSTANTS.NOT_FRAGMENTED, //분할될 일이 없음
                        LASTMSG = CONSTANTS.LASTMSG, //마지막 메시지이긴 하니까
                        SEQ = 0
                    };

                    if (answer != "yes")  //파일 전송 요청 거절
                    {
                        //거절하면 클라이언트에 거부 응답 보냄
                        //요청 메시지의 바디 구조 : MSGID(4바이트), 파일 전송 승인 여부 RESPONSE(1)
                        rspMsg.Body = new BodyResponse()
                        {
                            MSGID = reqMsg.Header.MSGID,
                            RESPONSE = CONSTANTS.DENIED
                        };
                        MessageUtil.Send(stream, rspMsg);
                        stream.Close();
                        client.Close();

                        continue;
                    }
                    else
                        MessageUtil.Send(stream, rspMsg); //승낙 메시지 전송

                    Console.WriteLine("파일 전송을 시작합니다...");

                    long fileSize = reqBody.FILESIZE;
                    string fileName = Encoding.Default.GetString(reqBody.FILENAME);
                    FileStream file = new FileStream(dir + "\\" + fileName, FileMode.Create); //업로드 파일 스트림 생성

                    uint? dataMsgId = null;
                    ushort prevSeq = 0;
                    while((reqMsg = MessageUtil.Receive(stream)) != null)
                    {
                        Console.Write("#");
                        if (reqMsg.Header.MSGTYPE != CONSTANTS.FILE_SEND_DATA)
                            break;

                        if (dataMsgId == null) //초기 메시지ID 세팅
                            dataMsgId = reqMsg.Header.MSGID;
                        else
                            if (dataMsgId != reqMsg.Header.MSGID)
                                break;
                        
                        //메시지 순서가 어긋나면 전송을 중단
                        if(prevSeq++ != reqMsg.Header.SEQ)
                        {
                            Console.WriteLine("{0}, {1}", prevSeq, reqMsg.Header.SEQ);
                            break;
                        }

                        //전송받은 스트림을 서버에서 생성한 파일에 기록
                        file.Write(reqMsg.Body.GetBytes(), 0, reqMsg.Body.GetSize());

                        //분할 메시지가 아니라면 반복을 한번만 하고 빠져나온다
                        //if (reqMsg.Header.FRAGMENTED == CONSTANTS.NOT_FRAGMENTED)
                        //    break;
                        //마지막 메시지면 반복문을 빠져나온다
                        if (reqMsg.Header.LASTMSG == CONSTANTS.LASTMSG)
                            break;
                    }

                    long recvFileSize = file.Length;
                    file.Close();

                    Console.WriteLine();
                    Console.WriteLine("수신 파일 크기 : {0} bytes", recvFileSize);

                    //결과를 주는 메시지
                    Message rstMsg = new Message();
                    rstMsg.Body = new BodyResult()
                    {
                        MSGID = reqMsg.Header.MSGID,
                        RESULT = CONSTANTS.SUCCESS
                    };
                    rstMsg.Header = new Header()
                    {
                        MSGID = msgId++,
                        MSGTYPE = CONSTANTS.FILE_SEND_RES,
                        BODYLEN = (uint)rstMsg.Body.GetSize(),
                        FRAGMENTED = CONSTANTS.NOT_FRAGMENTED,
                        LASTMSG = CONSTANTS.LASTMSG,
                        SEQ = 0
                    };

                    //전송 요청에 담겨온 크기와 실제로 받은 크기를 비교하여 같으면 성공 메시지 보냄
                    if (fileSize == recvFileSize)
                        MessageUtil.Send(stream, rstMsg);
                    else
                    {
                        rstMsg.Body = new BodyResult()
                        {
                            MSGID = reqMsg.Header.MSGID,
                            RESULT = CONSTANTS.FAIL
                        };
                        //파일 크기에 이상이 있으면 실패 메시지 보냄
                        MessageUtil.Send(stream, rstMsg);
                    }

                    Console.WriteLine("파일 전송을 마쳤습니다.");

                    stream.Close();
                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                server.Stop();
            }

            Console.WriteLine("서버를 종료합니다.");
        }
    }
}
