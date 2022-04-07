using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpuEmulator.p16 {
    public static partial class EncoderDecoder {
        public static Instruction Store(
            Mode mode1, ushort address1,
            Mode mode2, ushort value2) {
            return Custom(OpCode.store, mode1, address1, mode2, value2);
        }
        public static Instruction StoreHB(
            Mode mode1, ushort address1,
            Mode mode2, ushort value2) {
            return Custom(OpCode.storehb, mode1, address1, mode2, value2);
        }
        public static Instruction StoreLB(
            Mode mode1, ushort address1,
            Mode mode2, ushort value2) {
            return Custom(OpCode.storelb, mode1, address1, mode2, value2);
        }
    }
}
