using System;

namespace FUP
{
    //0x01에 사용할 본문 클래스
    public class BodyRequest : ISerializable
    {
        public long FILESIZE;
        public byte[] FILENAME;

        public BodyRequest() { }
        public BodyRequest(byte[] bytes)
        {
            FILESIZE = BitConverter.ToInt64(bytes, 0)
        }
    }
    class Body
    {
    }
}
