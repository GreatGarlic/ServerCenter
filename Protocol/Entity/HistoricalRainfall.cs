using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Protocol.Entity
{
    /*
     * 雨量历史数据实体对象.
     */
    class HistoricalRainfall
    {
        /*
         * 历史时间.
         */ 
        public DateTime historicalTime { get; set; }
        /*
         * 翻斗数.
         */
        public uint TipperCount { get; set; }

    }
}
