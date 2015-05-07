using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;
using System;
using SuperSocket.Common;

using System.Reflection;
using log4net;

namespace ServerCenter
{
    /*
     * 解码器.
    */
    class RainfallReceiveFilter : ReceiveFilterBase<RainfallRequestInfo>
    {
        private static ILog LOGGER = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

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
            if (length < 4)
            {
                LOGGER.DebugFormat("数据长度不够[{0}]", BitConverter.ToString(readBuffer, offset, length));
                rest = 0;
                return NullRequestInfo;
            }
            byte[] original = null;
            original = readBuffer.CloneRange(offset, length);

            LOGGER.DebugFormat("收到数据[{0}]", BitConverter.ToString(original, 0, original.Length));



            RainfallRequestHeader header = new RainfallRequestHeader();

            rest = 0;
            // base.Reset();

            return new RainfallRequestInfo(BitConverter.ToString(new byte[] { header.FunctionCode }), header, original);
        }
    }
}
