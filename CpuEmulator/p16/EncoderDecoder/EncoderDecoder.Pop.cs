using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpuEmulator.p16 {
    public static partial class EncoderDecoder {
        public static Instruction Pop(Mode mode1, ushort register1) {
            return Custom(OpCode.push, mode1, register1);
        }
        public static Instruction PopUB(Mode mode1, ushort register1) {
            return Custom(OpCode.popub, mode1, register1);
        }
        public static Instruction PopSB(Mode mode1, ushort register1) {
            return Custom(OpCode.popsb, mode1, register1);
        }
    }
}
