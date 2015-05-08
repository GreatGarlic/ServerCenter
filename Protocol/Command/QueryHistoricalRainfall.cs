using log4net;
using SuperSocket.SocketBase.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using SuperSocket.Common;
using Protocol.Entity;
using Protocol.Convert;


namespace Protocol.Command
{
    /**
    * 读取历史雨量响应处理.
    */
    public class QueryHistoricalRainfall : CommandBase<RainfallSession, RainfallRequestInfo>
    {
        private static ILog LOGGER = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public override string Name { get { return "FA"; } }
        public override void ExecuteCommand(RainfallSession session, RainfallRequestInfo requestInfo)
        {
            //数据包数量
            uint countPackage = (uint)(requestInfo.Body[0] & 0xFF);
            byte[] contextBytes = requestInfo.Body.CloneRange(1, requestInfo.Body.Length - 1);
            if (contextBytes.Length == countPackage * 7)
            {
                List<HistoricalRainfall> dataList = new List<HistoricalRainfall>();
                for (int i = 0; i < countPackage; i++)
                {
                    byte[] dataByte = contextBytes.CloneRange(i * 7, 7);
                    HistoricalRainfall data = new HistoricalRainfall();
                    data.historicalTime = ConvertUtil.Bcd2Date(dataByte.CloneRange(0, 6));
                    data.TipperCount = (uint)(dataByte[6] & 0xFF);
                    dataList.Add(data);
                }
                //正常收到数据包的回复
                byte[] responseData = { 0x38 };
                session.Send(responseData, 0, 1);
            }
        }
    }
}
