using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmulatorGui {
    public class NumberFormat {
        public NumberFormat() { }
        public virtual string To(uint value) 
            => value.ToString();
        public virtual bool From(string text, out uint value) 
            => uint.TryParse(text, out value);
        
        
    }
    public class BinaryFormat : NumberFormat{
        int _length;
        public BinaryFormat(int length) { _length = length; }

        public static BinaryFormat Instance32 { get; } = new BinaryFormat(32);
        public static BinaryFormat Instance16 { get; } = new BinaryFormat(16);
        public static BinaryFormat Instance8 { get; } = new BinaryFormat(8);
        public override string To(uint value) {
            StringBuilder builder = new StringBuilder(64);
            for (int i = _length - 1; i >= 0; i--) {
                bool bit = ((value >> i) & 1) != 0;
                builder.Append(bit ? '1' : '0');
            }
            return builder.ToString();
        }
        public override bool From(string text, out uint value) {
            value = 0;
            foreach (char c in text) {
                if (c != '1' && c != '0') return false;
                value = (value << 1) | (uint)(c == '1' ? 1 : 0);
            }
            return true;
        }
        public override string ToString() => "bin";
    }
    public class HexadecimalFormat : NumberFormat{
        int _length;
        public HexadecimalFormat(int length) { _length = length; }
        public static HexadecimalFormat Instance32 { get; } = new HexadecimalFormat(8);
        public static HexadecimalFormat Instance16 { get; } = new HexadecimalFormat(4);
        public static HexadecimalFormat Instance8  { get; } = new HexadecimalFormat(2);


        public override string To(uint value) => value.ToString( $"X{_length}" );
        public override bool From(string text, out uint value) {
            value = 0;
            foreach (char rd in text) {
                char c = char.ToUpper(rd);

                if (char.IsLetter(c))
                    if (c > 'F') return false;
                    else value = (value << 4) | (uint)(c - 'A' + 10);

                if (char.IsDigit(c))
                    value = (value << 4) | (uint)(c - '0');
            }

            return true;
        }
        public override string ToString() => "hex";
    }
    public class DecimalFormat : NumberFormat {
        public static DecimalFormat Instance { get; } = new DecimalFormat();
        public override string To(uint value)
            => value.ToString();
        public override bool From(string text, out uint value)
            => uint.TryParse(text, out value);
        public override string ToString() => "dec";
    }
}
