using SuperSocket.SocketBase.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerCenter.Command
{
    /**
    *参数设置响应处理.
    */
    public class SetParameter : CommandBase<RainfallSession, RainfallRequestInfo>
    {
        public override string Name { get { return "FB"; } }
        public override void ExecuteCommand(RainfallSession session, RainfallRequestInfo requestInfo)
        {
            throw new NotImplementedException();
        }
    }
}
