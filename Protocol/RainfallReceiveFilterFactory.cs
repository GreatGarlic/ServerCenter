﻿using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Protocol
{
    class RainfallReceiveFilterFactory<TRequestInfo> : IReceiveFilterFactory<TRequestInfo>
        where TRequestInfo : IRequestInfo
    {
        public virtual IReceiveFilter<TRequestInfo> CreateFilter(IAppServer appServer, IAppSession appSession,
                                                         IPEndPoint remoteEndPoint)
        {
            //通过session获取服务实例.
            RainfallServer server=appSession.AppServer as RainfallServer;

            var filter = new RainfallReceiveFilterReserve(appSession);
            return (filter as IReceiveFilter<TRequestInfo>);
        }
    }

}
