using log4net;
using SuperSocket.SocketBase;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Protocol
{
    public class RainfallSession : AppSession<RainfallSession, RainfallRequestInfo>
    {
        private static ILog LOGGER = log4net.LogManager.GetLogger(typeof(RainfallSession));
        protected override void OnSessionStarted()
        {
            LOGGER.Debug("客户端地址为:" + base.RemoteEndPoint.Address + "端口为:" + base.RemoteEndPoint.Port);
            LOGGER.Debug("连接打开!");
        }
        protected override void HandleException(Exception e)
        {

        }
        protected override void OnSessionClosed(CloseReason reason)
        {
            LOGGER.Debug("连接关闭!");
        }
    }
}
