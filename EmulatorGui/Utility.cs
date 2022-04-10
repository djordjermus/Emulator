using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmulatorGui {
    public static class Utility {
        public static string ToBin(ushort value) {
            StringBuilder builder = new StringBuilder(16);
            for (int i = 15; i > -1; i--) {
                bool bit = ((value >> i) & 1) != 0;
                builder.Append(bit == true ? '1' : '0');
            }
            return builder.ToString();
        }
        public static string ToBin(byte value) {
            StringBuilder builder = new StringBuilder(16);
            for (int i = 7; i > -1; i--) {
                bool bit = ((value >> i) & 1) != 0;
                builder.Append(bit == true ? '1' : '0');
            }
            return builder.ToString();
        }
        public static bool FromBin(string binary, out ushort ret) {
            ret = 0;
            foreach (char c in binary) {
                if (c != '1' && c != '0') return false;
                ret = (ushort)((ret << 1) | (c == '1' ? 1 : 0));
            }
            return true;
        }
        public static bool FromHex(string hex, out ushort ret) {
            ret = 0;
            foreach (char rd in hex) {
                char c = char.ToUpper(rd);

                if (char.IsLetter(c))
                    if (c > 'F') return false;
                    else ret = (ushort)((ret << 4) | (c - 'A' + 10));

                if (char.IsDigit(c))
                    ret = (ushort)((ret << 4) | (c - '0'));
            }


            return true;
        }

    }
}
