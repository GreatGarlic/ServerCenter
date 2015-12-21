using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Protocol
{
    public class RainfallServer : AppServer<RainfallSession, RainfallRequestInfo>
    {
        public RainfallServer()
            : base(new RainfallReceiveFilterFactory<RainfallRequestInfo>())
        {

        }
        /// <summary>
        /// 读取你的自定义配置信息.
        /// </summary>
        /// <param name="rootConfig"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        protected override bool Setup(IRootConfig rootConfig, IServerConfig config)
        {
            return base.Setup(rootConfig, config);
        }
        /// <summary>
        /// 服务启动时.
        /// </summary>
        protected override void OnStarted()
        {
            base.OnStarted();
        }
        /// <summary>
        /// 服务关闭时.
        /// </summary>
        protected override void OnStopped()
        {
            base.OnStopped();
        }
    }
}
