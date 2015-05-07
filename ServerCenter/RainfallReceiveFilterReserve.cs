using SuperSocket.Facility.Protocol;
using SuperSocket.SocketBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperSocket.Common;

namespace ServerCenter
{
    class RainfallReceiveFilterReserve : FixedHeaderReceiveFilter<RainfallRequestInfo>
    {
        public IAppSession AppSession { get; private set; }
        public RainfallReceiveFilterReserve(IAppSession appSession)
            : base(2)
        {
            AppSession = appSession;
        }

        protected override int GetBodyLengthFromHeader(byte[] header, int offset, int length)
        {
            return ((int)header[offset + 1]) + 1;
        }

        protected override RainfallRequestInfo ResolveRequestInfo(ArraySegment<byte> header, byte[] bodyBuffer, int offset, int length)
        {
            //功能码.
            byte functionCode = header.Array[header.Offset];
            //数据段长度.
            byte BodyLen = header.Array[header.Offset + 1];
            //数据段+CRC码内容.
            byte[] bodyBytesAndCrc = bodyBuffer.CloneRange(offset, length);

            RainfallRequestHeader contextHeader = new RainfallRequestHeader();
            contextHeader.FunctionCode = functionCode;
            contextHeader.BodyLen = BodyLen;
            //数据段内容.
            byte[] bodyBytes = new byte[bodyBytesAndCrc.Length - 1];
            Array.Copy(bodyBytesAndCrc, bodyBytes, bodyBytes.Length);
            contextHeader.Body = bodyBytes;
            //CRC码内容.
            contextHeader.Crc = bodyBytesAndCrc[bodyBytesAndCrc.Length - 1];
            //完整报文内容.
            byte[] original = new byte[header.Array.Length + bodyBytesAndCrc.Length];
            header.Array.CopyTo(original, 0);
            bodyBytesAndCrc.CopyTo(original, header.Array.Length);
            return new RainfallRequestInfo(BitConverter.ToString(new byte[] { contextHeader.FunctionCode }), contextHeader, original);
        }
    }
}
