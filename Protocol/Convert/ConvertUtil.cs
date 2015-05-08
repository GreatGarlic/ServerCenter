using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Protocol.Convert
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
        /**
	     * 
	     * 将4个字节的字节数组转换为Int值
	     *  由高位到低位
	     * @param bytes
	     * @return result 整型
	     * 
	     *         方法添加日期: 2014年3月3日 创建者:刘源
	     */
        public static int bytes2Int(byte[] bytes)
        {
            int result = 0;
            for (int i = 0; i < bytes.Length; i++)
            {
                result += ((int)(bytes[i] & 0xFF)) << (8 * (bytes.Length - i - 1));
            }
            return result;
        }

        public static DateTime Bcd2Date(byte[] src) {
            int offset = 0;
            int year = ConvertUtil.byteToBCD(src[offset++]) + 2000;
            int month = ConvertUtil.byteToBCD(src[offset++]);
            int day = ConvertUtil.byteToBCD(src[offset++]);
            int hour = ConvertUtil.byteToBCD(src[offset++]);
            int minute = ConvertUtil.byteToBCD(src[offset++]);
            int second = ConvertUtil.byteToBCD(src[offset++]);
            return new DateTime(year, month, day, hour, minute, second);
        }
    }
}
