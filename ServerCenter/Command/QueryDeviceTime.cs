using log4net;
using ServerCenter.Convert;
using SuperSocket.SocketBase.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ServerCenter.Command
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
            int offset = 0;
            byte[] body = requestInfo.Body;
            int year = ConvertUtil.byteToBCD(body[offset++])+2000;
            int month = ConvertUtil.byteToBCD(body[offset++]);
            int day = ConvertUtil.byteToBCD(body[offset++]);
            int hour = ConvertUtil.byteToBCD(body[offset++]);
            int minute = ConvertUtil.byteToBCD(body[offset++]);
            int second = ConvertUtil.byteToBCD(body[offset++]);
            DateTime dt = new DateTime(year, month, day, hour, minute, second);
            LOGGER.Debug("设备时间:"+dt.ToString("yyyy年MM月dd日hh:mm:ss"));
        }
    }
}
