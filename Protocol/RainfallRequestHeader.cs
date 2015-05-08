using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Protocol
{
    public class RainfallRequestHeader
    {
        //功能码
        public byte FunctionCode { get; set; }
        //数据域
        public byte[] Body { get; set; }
        //数据域长度
        public byte BodyLen { get; set; }
        //CRC检验码
        public byte Crc { get; set; }
    }
}
