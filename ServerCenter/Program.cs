using SuperSocket.SocketBase;
using SuperSocket.SocketEngine;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using log4net;
using System.Reflection;

namespace ServerCenter
{
    class Program
    {
        private static ILog LOGGER = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            var bootstrap = BootstrapFactory.CreateBootstrap();
            if (!bootstrap.Initialize())
            {
                LOGGER.Error("初始化失败!");
                Console.ReadKey();
                return;
            }
            if (bootstrap.Start() == SuperSocket.SocketBase.StartResult.Failed)
            {
                LOGGER.Error("协议解析器启动失败!");
                Console.ReadKey();
                return;
            }
            EchoServer server = bootstrap.AppServers.SingleOrDefault(s => s.Name == "EchoServer") as EchoServer;
            if (server==null)
            {
                LOGGER.Error("协议解析器服务器未找到.");
                return;
            }
            LOGGER.Error("输入任意键结束...");
            Console.ReadLine();
            bootstrap.Stop();
        }
    }
}
