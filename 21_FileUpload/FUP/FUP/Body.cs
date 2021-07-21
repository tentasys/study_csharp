using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FUP
{
    //파일 전송 요청(0x01)에 사용할 본문 클래스
    //클라이언트에서 사용하며, 파일의 크기와 파일의 이름으로 이루어져 있음
    public class BodyRequest : ISerializable
    {
        public long FILESIZE;
        public byte[] FILENAME;

        public BodyRequest() { }
        public BodyRequest(byte[] bytes)
        {
            FILESIZE = BitConverter.ToInt64(bytes, 0);
            FILENAME = new byte[bytes.Length - sizeof(long)];
            Array.Copy(bytes, sizeof(long), FILENAME, 0, FILENAME.Length);
        }
        public byte[] GetBytes()
        {
            byte[] bytes = new byte[GetSize()];
            byte[] temp = BitConverter.GetBytes(FILESIZE);
            Array.Copy(temp, 0, bytes, 0, temp.Length);
            Array.Copy(FILENAME, 0, bytes, temp.Length, FILENAME.Length);

            return bytes;
        }
        public int GetSize()
        {
            return sizeof(long) + FILENAME.Length;
        }
    }

    //파일 전송 요청 응답(0x02)에 사용할 본문 클래스
    //서버에서 사용하며, 클라이언트의 요청 메시지 식별 번호와 결과를 클라이언트에 전송한다.
    public class BodyResponse : ISerializable
    {
        public uint MSGID;
        public byte RESPONSE;
        public BodyResponse() { }
        public BodyResponse(byte[] bytes)
        {
            MSGID = BitConverter.ToUInt32(bytes, 0);
            RESPONSE = bytes[4];
        }
        public byte[] GetBytes()
        {
            byte[] bytes = new byte[GetSize()];
            byte[] temp = BitConverter.GetBytes(MSGID);
            Array.Copy(temp, 0, bytes, 0, temp.Length);
            bytes[temp.Length] = RESPONSE;

            return bytes;
        }
        public int GetSize()
        {
            return sizeof(uint) + sizeof(byte);
        }
    }

    //파일 전송(0x03)에 사용할 본문 클래스
    //클라이언트에서 서버로 전송하는 파일이 전송되는 메시지. 파일의 데이터만 존재한다.
    public class BodyData : ISerializable
    {
        public byte[] DATA;
        public BodyData(byte[] bytes)
        {
            DATA = new byte[bytes.Length];
            bytes.CopyTo(DATA, 0);
        }
        public byte[] GetBytes()
        {
            return DATA;
        }
        public int GetSize()
        {
            return DATA.Length;
        }
    }

    //파일 전송 요청(0x04)에 사용할 본문 클래스
    //서버가 파일 전송 여부를 클라이언트에 보내줌.
    public class BodyResult : ISerializable
    {
        public uint MSGID;
        public byte RESULT;

        public BodyResult() { }
        public BodyResult(byte[] bytes)
        {
            MSGID = BitConverter.ToUInt32(bytes, 0);
            RESULT = bytes[4];
        }
        public byte[] GetBytes()
        {
            byte[] bytes = new byte[GetSize()];
            byte[] temp = BitConverter.GetBytes(MSGID);
            Array.Copy(temp, 0, bytes, 0, temp.Length);
            bytes[temp.Length] = RESULT;

            return bytes;
        }
        public int GetSize()
        {
            return sizeof(uint) + sizeof(Byte);
        }
    }
}
