using log4net;
using ServerCenter.Convert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using SuperSocket.Common;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Command;
namespace ServerCenter.Command
{
    /**
    *参数设置响应处理.
    */
    public class SetParameter : CommandBase<RainfallSession, RainfallRequestInfo>
    {
        private static ILog LOGGER = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public override string Name { get { return "FB"; } }
        public override void ExecuteCommand(RainfallSession session, RainfallRequestInfo requestInfo)
        {
            try
            {
                int bodyLength = requestInfo.Body.Length;
                if (bodyLength == 1)
                {
                    if (requestInfo.Body[0] == 0x52)
                    {
                        LOGGER.Debug("参数设置成功");
                    }
                    else if (requestInfo.Body[0] == 0x51)
                    {
                        LOGGER.Debug("参数设置失败");
                    }
                    return;
                }
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
            catch (Exception e)
            {
                LOGGER.Error("参数设置响应处理异常",e);
            }






        }
    }
}
