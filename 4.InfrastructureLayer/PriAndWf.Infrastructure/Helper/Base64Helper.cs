using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriAndWf.Infrastructure.Helper
{
    public class Base64Helper
    {
        private static readonly char[] _base64Alphabet = new char[]
        {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
            'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
            'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd',
            'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n',
            'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
            'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7',
            '8', '9', '+', '/'
        };
        private static readonly char _equal = '=';

        /// <summary>
        /// 编码
        /// </summary>
        /// <param name="originalStr">原始字符串</param>
        /// <returns>编码后的字符串</returns>
        public static string Encode(string originalStr)
        {
            var bytes = Encoding.Default.GetBytes(originalStr);
            var bytesCount = bytes.Count();
            var quotient = (bytesCount / 3);//商
            var remainder = (bytesCount % 3);//余数

            var sb = new StringBuilder((quotient * 4) + ((3 - remainder > 0) ? 4 : 0));
            var tempBytes = new byte[3];
            var tempIndexs = new int[4];
            for (int i = 0; i < quotient; i++)
            {
                tempBytes[0] = bytes[i * 3];
                tempBytes[1] = bytes[i * 3 + 1];
                tempBytes[2] = bytes[i * 3 + 2];

                tempIndexs[0] = tempBytes[0] >> 2;
                tempIndexs[1] = ((tempBytes[0] & 0x03) << 4) ^ (tempBytes[1] >> 4);
                tempIndexs[2] = ((tempBytes[1] & 0x0f) << 2) ^ (tempBytes[2] >> 6);
                tempIndexs[3] = (tempBytes[2] & 0x3f);

                sb.Append(_base64Alphabet[tempIndexs[0]]);
                sb.Append(_base64Alphabet[tempIndexs[1]]);
                sb.Append(_base64Alphabet[tempIndexs[2]]);
                sb.Append(_base64Alphabet[tempIndexs[3]]);
            }
            if (remainder == 1)
            {
                tempBytes[0] = bytes[bytesCount - 1];
                tempBytes[1] = 0;

                tempIndexs[0] = tempBytes[0] >> 2;
                tempIndexs[1] = ((tempBytes[0] & 0x03) << 4) ^ (tempBytes[1] >> 4);

                sb.Append(_base64Alphabet[tempIndexs[0]]);
                sb.Append(_base64Alphabet[tempIndexs[1]]);
                sb.Append(_equal);
                sb.Append(_equal);
            }
            else if (remainder == 2)
            {
                tempBytes[0] = bytes[bytesCount - 2];
                tempBytes[1] = bytes[bytesCount - 1];
                tempBytes[2] = 0;

                tempIndexs[0] = tempBytes[0] >> 2;
                tempIndexs[1] = ((tempBytes[0] & 0x03) << 4) ^ (tempBytes[1] >> 4);
                tempIndexs[2] = ((tempBytes[1] & 0x0f) << 2) ^ (tempBytes[2] >> 6);

                sb.Append(_base64Alphabet[tempIndexs[0]]);
                sb.Append(_base64Alphabet[tempIndexs[1]]);
                sb.Append(_base64Alphabet[tempIndexs[2]]);
                sb.Append(_equal);
            }
            return sb.ToString();
        }
        /// <summary>
        /// 解码
        /// </summary>
        /// <param name="base64Str">Base64 编码后的字符串</param>
        /// <returns>原始字符串</returns>
        public static string Decode(string base64Str)
        {
            var strBase64Alphabet = string.Concat(_base64Alphabet);
            var chars = base64Str.ToCharArray();
            var charsCount = chars.Count();
            var quotient = (charsCount / 4);//商

            var tempBytes4 = new byte[4];
            var tempBytes3 = new byte[3];
            byte[] bytes;

            if (chars[charsCount - 2] == _equal)
            {
                bytes = new byte[quotient * 3 - 2];
                tempBytes4[0] = (byte)strBase64Alphabet.IndexOf(chars[charsCount - 4]);
                tempBytes4[1] = (byte)strBase64Alphabet.IndexOf(chars[charsCount - 3]);

                tempBytes3[0] = (byte)((tempBytes4[0] << 2) ^ ((tempBytes4[1] & 0x30) >> 4));

                bytes[quotient * 3 - 3] = tempBytes3[0];
            }
            else if (chars[charsCount - 1] == _equal)
            {
                bytes = new byte[quotient * 3 - 1];
                tempBytes4[0] = (byte)strBase64Alphabet.IndexOf(chars[charsCount - 4]);
                tempBytes4[1] = (byte)strBase64Alphabet.IndexOf(chars[charsCount - 3]);
                tempBytes4[2] = (byte)strBase64Alphabet.IndexOf(chars[charsCount - 2]);

                tempBytes3[0] = (byte)((tempBytes4[0] << 2) ^ ((tempBytes4[1] & 0x30) >> 4));
                tempBytes3[1] = (byte)((tempBytes4[1] << 4) ^ ((tempBytes4[2] & 0x3c) >> 2));

                bytes[quotient * 3 - 3] = tempBytes3[0];
                bytes[quotient * 3 - 2] = tempBytes3[1];
            }
            else
            {
                bytes = new byte[quotient * 3];
                tempBytes4[0] = (byte)strBase64Alphabet.IndexOf(chars[charsCount - 4]);
                tempBytes4[1] = (byte)strBase64Alphabet.IndexOf(chars[charsCount - 3]);
                tempBytes4[2] = (byte)strBase64Alphabet.IndexOf(chars[charsCount - 2]);
                tempBytes4[3] = (byte)strBase64Alphabet.IndexOf(chars[charsCount - 1]);

                tempBytes3[0] = (byte)((tempBytes4[0] << 2) ^ ((tempBytes4[1] & 0x30) >> 4));
                tempBytes3[1] = (byte)((tempBytes4[1] << 4) ^ ((tempBytes4[2] & 0x3c) >> 2));
                tempBytes3[2] = (byte)((tempBytes4[2] << 6) ^ tempBytes4[3]);

                bytes[quotient * 3 - 4] = tempBytes3[0];
                bytes[quotient * 3 - 3] = tempBytes3[1];
                bytes[quotient * 3 - 2] = tempBytes3[2];
            }
            for (int i = 0; i < quotient - 1; i++)
            {
                tempBytes4[0] = (byte)strBase64Alphabet.IndexOf(chars[i * 4]);
                tempBytes4[1] = (byte)strBase64Alphabet.IndexOf(chars[i * 4 + 1]);
                tempBytes4[2] = (byte)strBase64Alphabet.IndexOf(chars[i * 4 + 2]);
                tempBytes4[3] = (byte)strBase64Alphabet.IndexOf(chars[i * 4 + 3]);

                tempBytes3[0] = (byte)((tempBytes4[0] << 2) ^ ((tempBytes4[1] & 0x30) >> 4));
                tempBytes3[1] = (byte)((tempBytes4[1] << 4) ^ ((tempBytes4[2] & 0x3c) >> 2));
                tempBytes3[2] = (byte)((tempBytes4[2] << 6) ^ tempBytes4[3]);

                bytes[i * 3] = tempBytes3[0];
                bytes[i * 3 + 1] = tempBytes3[1];
                bytes[i * 3 + 2] = tempBytes3[2];
            }
            return Encoding.Default.GetString(bytes);
        }

        /// <summary>
        /// 编码
        /// </summary>
        /// <param name="originalStr">原始字符串</param>
        /// <returns>编码后的字符串</returns>
        public static string UrlSafeEncode(string originalStr)
        {
            return Encode(originalStr).Replace("+", "-").Replace("/", "_").Replace("=", "");
        }
        /// <summary>
        /// 解码
        /// </summary>
        /// <param name="urlSafeBase64Str">Base64 编码（Url Safe）后的字符串</param>
        /// <returns>原始字符串</returns>
        public static string UrlSafeDecode(string urlSafeBase64Str)
        {
            var base64Str = urlSafeBase64Str.Replace("-", "+").Replace("_", "/");
            var remainder = base64Str.Length % 4;
            if (remainder > 0)
            {
                base64Str += ("====").Substring(remainder);
            }
            return Decode(base64Str);
        }
    }
}
