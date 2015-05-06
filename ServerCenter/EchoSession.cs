using log4net;
using SuperSocket.SocketBase;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ServerCenter
{
    public class EchoSession : AppSession<EchoSession>
    {
        private  static ILog LOGGER = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        protected override void OnSessionStarted()
        {
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
