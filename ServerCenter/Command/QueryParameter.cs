using SuperSocket.SocketBase.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerCenter.Command
{
    /**
    *读取参数响应处理.
    */
    public class QueryParameter : CommandBase<RainfallSession, RainfallRequestInfo>
    {

        public override string Name { get { return "FC"; } }
        public override void ExecuteCommand(RainfallSession session, RainfallRequestInfo requestInfo)
        {
            throw new NotImplementedException();
        }
    }
}
