

namespace N5_API.Project.Base.Utiles
{
    public class TimestampUtils
    {
        private static char[] _hexDigits = {
                                       '0', '1', '2', '3', '4', '5', '6', '7',
                                       '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'};

        #region Method CharPairToByte()

        private static byte CharPairToByte(char vF, char v0)
        {
            byte resultado;
            switch (vF)
            {
                case '0': resultado = 0; break;
                case '1': resultado = 16; break;
                case '2': resultado = 32; break;
                case '3': resultado = 48; break;
                case '4': resultado = 64; break;
                case '5': resultado = 80; break;
                case '6': resultado = 96; break;
                case '7': resultado = 112; break;
                case '8': resultado = 128; break;
                case '9': resultado = 144; break;
                case 'A':
                case 'a': resultado = 160; break;
                case 'B':
                case 'b': resultado = 176; break;
                case 'C':
                case 'c': resultado = 192; break;
                case 'D':
                case 'd': resultado = 208; break;
                case 'E':
                case 'e': resultado = 224; break;
                case 'F':
                case 'f': resultado = 240; break;
                default: resultado = 0; break;
            }
            switch (v0)
            {
                case '0': resultado += 0; break;
                case '1': resultado += 1; break;
                case '2': resultado += 2; break;
                case '3': resultado += 3; break;
                case '4': resultado += 4; break;
                case '5': resultado += 5; break;
                case '6': resultado += 6; break;
                case '7': resultado += 7; break;
                case '8': resultado += 8; break;
                case '9': resultado += 9; break;
                case 'A':
                case 'a': resultado += 10; break;
                case 'B':
                case 'b': resultado += 11; break;
                case 'C':
                case 'c': resultado += 12; break;
                case 'D':
                case 'd': resultado += 13; break;
                case 'E':
                case 'e': resultado += 14; break;
                case 'F':
                case 'f': resultado += 15; break;
            }
            return resultado;
        }

        #endregion Method CharPairToByte()

        #region Method TimestampToString

        public static string TimestampToString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length * 2];
            for (int i = 0, j = 0; i < bytes.Length; i++)
            {
                int b = bytes[i];
                chars[j++] = _hexDigits[b >> 4];
                chars[j++] = _hexDigits[b & 0xF];
            }
            return new string(chars);
        }

        #endregion Method TimestampToString

        public static byte[] StringToTimestamp(string s)
        {
            byte[] b = new byte[8];
            b[0] = CharPairToByte(s[0], s[1]);
            b[1] = CharPairToByte(s[2], s[3]);
            b[2] = CharPairToByte(s[4], s[5]);
            b[3] = CharPairToByte(s[6], s[7]);
            b[4] = CharPairToByte(s[8], s[9]);
            b[5] = CharPairToByte(s[10], s[11]);
            b[6] = CharPairToByte(s[12], s[13]);
            b[7] = CharPairToByte(s[14], s[15]);
            return b;
        }

        public static bool TimestampCompareBigger(byte[] Timestamp1, byte[] Timestamp2)
        {
            return BitConverter.ToInt64(Timestamp1.Reverse().ToArray(), 0) > BitConverter.ToInt64(Timestamp2.Reverse().ToArray(), 0) ? true : false;
        }
    }

}
