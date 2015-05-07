using SuperSocket.SocketBase.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerCenter.Command
{
    /**
    * 读取历史雨量响应处理.
    */
    public class QueryHistoricalRainfall : CommandBase<RainfallSession, RainfallRequestInfo>
    {
        public override string Name { get { return "FA"; } }
        public override void ExecuteCommand(RainfallSession session, RainfallRequestInfo requestInfo)
        {
            throw new NotImplementedException();
        }
    }
}
