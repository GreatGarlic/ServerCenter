using SuperSocket.SocketBase.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerCenter.Command
{
    public class ECHO : StringCommandBase<EchoSession>
    {


        public override void ExecuteCommand(EchoSession session, SuperSocket.SocketBase.Protocol.StringRequestInfo requestInfo)
        {
          
        }


  
    

    }
}
