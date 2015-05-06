using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;
using System;
using SuperSocket.Common;

namespace ServerCenter
{
    /*
     * 解码器.
    */
    class RainfallReceiveFilter : ReceiveFilterBase<RainfallRequestInfo> 
    {
        public IAppSession AppSession { get; private set; }
        //空对象.
        protected RainfallRequestInfo NullRequestInfo = default(RainfallRequestInfo);

        public RainfallReceiveFilter(IAppSession appSession)
        {
            AppSession = appSession;
        }
        /**
         * 接收收到的消息
         */
        public override RainfallRequestInfo Filter(byte[] readBuffer, int offset, int length, bool toBeCopied, out int rest)
        {
            RainfallRequestHeader header = new RainfallRequestHeader();
            byte[] original = null;
            original = readBuffer.CloneRange(offset, length);
            rest = 0;
            return new RainfallRequestInfo(BitConverter.ToString(new byte[] { header.FunctionCode }), header, original);
        }
    }
}
