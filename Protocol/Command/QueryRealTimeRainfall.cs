using log4net;
using SuperSocket.SocketBase.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using SuperSocket.Common;
using Protocol.Convert;

namespace Protocol.Command
{
    /**
    *读取实时雨量响应处理.
    */
    public class QueryRealTimeRainfall : CommandBase<RainfallSession, RainfallRequestInfo>
    {
        private static ILog LOGGER = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public override string Name { get { return "FD"; } }

        public override void ExecuteCommand(RainfallSession session, RainfallRequestInfo requestInfo)
        {
            LOGGER.Debug("===================读取实时雨量数据响应处理====================");

            try
            {
                byte[] body = requestInfo.Body;
                float resolution = 0.0f;
                if (body[0] == 0x01)
                {
                    resolution = 0.2f;
                }
                else if (body[0] == 0x02)
                {
                    resolution = 0.5f;
                }
                else if (body[0] == 0x03)
                {
                    resolution = 1.0f;
                }
                int offset = 1;
                float oneHours = ConvertUtil.bytes2Int(body.CloneRange(offset, 2)) * resolution;
                float twoHours = ConvertUtil.bytes2Int(body.CloneRange(offset += 2, 2)) * resolution;
                float threeHours = ConvertUtil.bytes2Int(body.CloneRange(offset += 2, 2)) * resolution;
                float sixHours = ConvertUtil.bytes2Int(body.CloneRange(offset += 2, 2)) * resolution;
                float twelveHours = ConvertUtil.bytes2Int(body.CloneRange(offset += 2, 2)) * resolution;
                float twentyFourHours = ConvertUtil.bytes2Int(body.CloneRange(offset += 2, 2)) * resolution;
                LOGGER.Debug("一小时雨量:" + oneHours);
                LOGGER.Debug("两小时雨量:" + twoHours);
                LOGGER.Debug("三小时雨量:" + threeHours);
                LOGGER.Debug("六小时雨量:" + sixHours);
                LOGGER.Debug("十二小时雨量:" + twelveHours);
                LOGGER.Debug("二十四小时雨量:" + twentyFourHours);
            }
            catch (Exception e)
            {
                LOGGER.Error("读取实时雨量数据响应错误:", e);
            }
        }
    }
}
