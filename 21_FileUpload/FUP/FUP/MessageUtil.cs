using System;
using System.IO;

namespace FUP
{
    //스트림으로부터 메시지를 보내고 받기 위한 메소드를 가지는 클래스
    public class MessageUtil
    {
        //스트림을 통해 메시지를 내보내는 클래스
        public static void Send(Stream writer, Message msg)
        {
            writer.Write(msg.GetBytes(), 0, msg.GetSize());
        }
        public static Message Receive(Stream reader)
        {
            int totalRecev = 0;
            int sizetoRead = 16;  //초기화값 16 : 헤더의 사이즈는 16바이트로 설정했으므로
            byte[] hBuffer = new byte[sizetoRead]; //헤더에 대한 버퍼

            //sizetoRead를 사용하는 의미는 무엇이지??
            while(sizetoRead > 0)
            {
                byte[] buffer = new byte[sizetoRead];
                int recv = reader.Read(buffer, 0, sizetoRead);
                if (recv == 0) return null;

                buffer.CopyTo(hBuffer, totalRecev);
                totalRecev += recv;
                sizetoRead -= recv;
            }

            Header header = new Header(hBuffer);

            totalRecev = 0;
            byte[] bBuffer = new byte[header.BODYLEN]; //body의 길이만큼 받는다, 바디에 대한 버퍼
            sizetoRead = (int)header.BODYLEN;

            while(sizetoRead > 0)
            {
                byte[] buffer = new byte[sizetoRead];
                int recv = reader.Read(buffer, 0, sizetoRead);
                if (recv == 0) return null;

                buffer.CopyTo(bBuffer, totalRecev);
                totalRecev += recv;
                sizetoRead -= recv;
            }

            ISerializable body = null;
            //헤더 타입에 따라 바디 객체를 세팅
            switch(header.MSGTYPE)
            {
                case CONSTANTS.REQ_FILE_SEND:
                    body = new BodyRequest(bBuffer);
                    break;
                case CONSTANTS.REP_FILE_SEND:
                    body = new BodyResponse(bBuffer);
                    break;
                case CONSTANTS.FILE_SEND_DATA:
                    body = new BodyData(bBuffer);
                    break;
                case CONSTANTS.FILE_SEND_RES:
                    body = new BodyResult(bBuffer);
                    break;
                default:
                    throw new Exception(
                        String.Format("Unknown MSGTYPE : {0}", header.MSGTYPE));
            }

            return new Message() { Header = header, Body = body };
        }
    }
}
