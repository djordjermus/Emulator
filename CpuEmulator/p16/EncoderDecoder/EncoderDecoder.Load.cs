using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpuEmulator.p16 {
    public static partial class EncoderDecoder {
        public static Instruction Load(
            Mode mode1, ushort register1, 
            Mode mode2, ushort value2) {
            return Custom(OpCode.load, mode1, register1, mode2, value2);
        }
        public static Instruction LoadUB(
            Mode mode1, ushort register1,
            Mode mode2, ushort value2) {
            return Custom(OpCode.loadub, mode1, register1, mode2, value2);
        }
        public static Instruction LoadSB(
            Mode mode1, ushort register1,
            Mode mode2, ushort value2) {
            return Custom(OpCode.loadsb, mode1, register1, mode2, value2);
        }
    }
}
