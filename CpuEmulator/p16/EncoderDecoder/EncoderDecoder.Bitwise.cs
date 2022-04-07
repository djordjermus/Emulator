using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpuEmulator.p16 {
    public static partial class EncoderDecoder {
        public static Instruction BitwiseAnd(
            Mode mode1, ushort register1,
            Mode mode2, ushort value2) {
            return Custom(OpCode.band, mode1, register1, mode2, value2);
        }
        public static Instruction BitwiseAnd(
            Mode mode1, ushort register1,
            Mode mode2, ushort value2,
            Mode mode3, ushort value3) {
            return Custom(OpCode.band, mode1, register1, mode2, value2, mode3, value3);
        }
        public static Instruction BitwiseOr(
            Mode mode1, ushort register1,
            Mode mode2, ushort value2) {
            return Custom(OpCode.bor, mode1, register1, mode2, value2);
        }
        public static Instruction BitwiseOr(
            Mode mode1, ushort register1,
            Mode mode2, ushort value2,
            Mode mode3, ushort value3) {
            return Custom(OpCode.bor, mode1, register1, mode2, value2, mode3, value3);
        }
        public static Instruction BitwiseXor(
            Mode mode1, ushort register1,
            Mode mode2, ushort value2) {
            return Custom(OpCode.bxor, mode1, register1, mode2, value2);
        }
        public static Instruction BitwiseXor(
            Mode mode1, ushort register1,
            Mode mode2, ushort value2,
            Mode mode3, ushort value3) {
            return Custom(OpCode.bxor, mode1, register1, mode2, value2, mode3, value3);
        }
        public static Instruction Invert(
            Mode mode1, ushort register1) {
            return Custom(OpCode.binv, mode1, register1);
        }
        public static Instruction Invert(
            Mode mode1, ushort register1,
            Mode mode2, ushort value2) {
            return Custom(OpCode.binv, mode1, register1, mode2, value2);
        }
    }
}
