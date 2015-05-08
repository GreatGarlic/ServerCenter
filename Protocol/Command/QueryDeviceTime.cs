using log4net;
using Protocol.Convert;
using SuperSocket.SocketBase.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Protocol.Command
{
    /**
     * 读取设备时间响应处理.
     */
    public class QueryDeviceTime : CommandBase<RainfallSession, RainfallRequestInfo>
    {
        private static ILog LOGGER = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public override string Name { get { return "FE"; } }
        public override void ExecuteCommand(RainfallSession session, RainfallRequestInfo requestInfo)
        {
            LOGGER.Debug("===================读取设备时间响应处理====================");
            byte[] body = requestInfo.Body;
            DateTime dt = ConvertUtil.Bcd2Date(body);
            LOGGER.Debug("设备时间:" + dt.ToString("yyyy年MM月dd日hh:mm:ss"));
        }
    }
}
