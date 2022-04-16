using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpuEmulator.p16 {
    public static partial class EncoderDecoder {
        public static Instruction Jump(
            Mode mode1, ushort address) {
            return new Instruction(OpCode.jmp, mode1, address);
        }
        public static Instruction JumpIfEqual(
            Mode mode1, ushort address1, 
            Mode mode2, ushort val2,
            Mode mode3, ushort val3) {
            return new Instruction(OpCode.jeq, mode1, address1, mode2, val2, mode3, val3);
        }
        public static Instruction JumpIfNotEqual(
            Mode mode1, ushort address1,
            Mode mode2, ushort val2,
            Mode mode3, ushort val3) {
            return new Instruction(OpCode.jne, mode1, address1, mode2, val2, mode3, val3);
        }

        public static Instruction RelativeJump(
            Mode mode1, ushort address) {
            return new Instruction(OpCode.rjmp, mode1, address);
        }
        public static Instruction RelativeJumpIfEqual(
            Mode mode1, ushort address1, 
            Mode mode2, ushort val2,
            Mode mode3, ushort val3) {
            return new Instruction(OpCode.rjeq, mode1, address1, mode2, val2, mode3, val3);
        }
        public static Instruction RelativeJumpIfNotEqual(
            Mode mode1, ushort address1,
            Mode mode2, ushort val2,
            Mode mode3, ushort val3) {
            return new Instruction(OpCode.rjne, mode1, address1, mode2, val2, mode3, val3);
        }
    }
}
