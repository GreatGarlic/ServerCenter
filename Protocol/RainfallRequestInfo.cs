using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Protocol
{
    public class RainfallRequestInfo : BinaryRequestInfo
    {   
        //原始报文
        private readonly byte[] originalData;
        //报文头部信息
        public RainfallRequestHeader Header { get; set; }
        public RainfallRequestInfo(string key, RainfallRequestHeader header, byte[] originalData)
            : base(key, header.Body)
        {
            Header = header;    
            this.originalData = originalData;
        }
        public byte[] OriginalData
        {
            get { return originalData; }
        }
    }
}
