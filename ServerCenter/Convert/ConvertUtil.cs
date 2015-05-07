using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerCenter.Convert
{
    class ConvertUtil
    {
        /**
	     * 
	     * BCD码转换int型
	     * 
	     * 方法添加日期: 2013-7-29 创建者:刘源
	     */
        public static int byteToBCD(byte val)
        {
            return ((val >> 4) * 10 + (val & 0x0f));
        }
        /**
	     * 
	     * Int转换BCD码(byte数组)
	     * 
	     * 方法添加日期: 2013-9-4 创建者:刘源
	     */
        public static byte[] Int2Bcd(int n, int dec)
        {
            byte high, low;
            byte[] buf = new byte[n];
            for (int i = 0; i < n; i++)
            {
                low = (byte)(dec % 10);
                dec /= 10;
                high = (byte)(dec % 10);
                dec /= 10;
                buf[i] = (byte)((high << 4) + (low & 0x0f));
            }
            return buf;
        }
        /**
         * 
         * Int转换BCD码(byte)
         * 
         * 方法添加日期: 2013-9-4 创建者:刘源
         */
        public static byte Int2Bcd(int value)
        {
            return Int2Bcd(1, value)[0];
        }
    }
}
