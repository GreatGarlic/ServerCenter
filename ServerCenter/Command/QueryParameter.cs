using SuperSocket.SocketBase.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperSocket.Common;
using ServerCenter.Convert;
using log4net;
using System.Reflection;
namespace ServerCenter.Command
{
    /**
    *读取参数响应处理.
    */
    public class QueryParameter : CommandBase<RainfallSession, RainfallRequestInfo>
    {
        private static ILog LOGGER = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public override string Name { get { return "FC"; } }
        public override void ExecuteCommand(RainfallSession session, RainfallRequestInfo requestInfo)
        {
            //时间
            byte[] timeBytes = requestInfo.Body.CloneRange(0, 6);
            DateTime dt = ConvertUtil.Bcd2Date(timeBytes);
            LOGGER.Debug("设备时间:" + dt.ToString("yyyy年MM月dd日hh:mm:ss"));
            //18组报警阀值内容
            byte[] alarmValueListBytes = requestInfo.Body.CloneRange(6, 36);
            //雨量计分辨率
            byte resolutionByte = requestInfo.Body[requestInfo.Body.Length - 1];
            float resolution = 0.0f;
            if (resolutionByte == 0x01)
            {
                resolution = 0.2f;
            }
            else if (resolutionByte == 0x02)
            {
                resolution = 0.5f;
            }
            else if (resolutionByte == 0x03)
            {
                resolution = 1.0f;
            }
            List<float> alarmValueList = new List<float>();
            for (int i = 0; i < alarmValueListBytes.Length / 2; i++)
            {
                float alarmValue = ConvertUtil.bytes2Int(alarmValueListBytes.CloneRange(i * 2, 2)) * resolution;
                alarmValueList.Add(alarmValue);
            }
            int offset = 1;
            foreach (float value in alarmValueList)
            {
                LOGGER.DebugFormat("第[{0}]组报警阀值[{1}]", offset++, value);
            }

        }
    }
}
