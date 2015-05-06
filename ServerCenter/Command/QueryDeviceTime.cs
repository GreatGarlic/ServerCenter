using SuperSocket.SocketBase.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerCenter.Command
{
    /**
     * 读取设备时间响应处理.
     */
    public class QueryDeviceTime : CommandBase<RainfallSession, RainfallRequestInfo>
    {

        public override string Name { get { return "FE"; } }
        public override void ExecuteCommand(RainfallSession session, RainfallRequestInfo requestInfo)
        {
           
         
        }
    }
}
