using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpuEmulator.p16 {
    public static partial class EncoderDecoder {
        public static Instruction Push(
            Mode mode1, ushort value1) {
            return new Instruction(OpCode.push, mode1, value1);
        }
        public static Instruction PushHB(
            Mode mode1, ushort value1) {
            return new Instruction(OpCode.pushhb, mode1, value1);
        }
        public static Instruction PushLB(
            Mode mode1, ushort value1) {
            return new Instruction(OpCode.pushlb, mode1, value1);
        }
    }
}
