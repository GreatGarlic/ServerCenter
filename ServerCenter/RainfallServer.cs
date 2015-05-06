using SuperSocket.SocketBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerCenter
{
    public class RainfallServer : AppServer<RainfallSession, RainfallRequestInfo>
    {
        public RainfallServer()
            : base(new RainfallReceiveFilterFactory<RainfallRequestInfo>())
        {

        }
    }
}
