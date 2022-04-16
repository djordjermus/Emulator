using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpuEmulator.p16 {
    public static partial class EncoderDecoder {
        public static Instruction And(
            Mode mode1, ushort register1,
            Mode mode2, ushort value2) {
            return new Instruction(OpCode.and, mode1, register1, mode2, value2);
        }
        public static Instruction And(
            Mode mode1, ushort register1,
            Mode mode2, ushort value2,
            Mode mode3, ushort value3) {
            return new Instruction(OpCode.and, mode1, register1, mode2, value2, mode3, value3);
        }
        public static Instruction Or(
            Mode mode1, ushort register1,
            Mode mode2, ushort value2) {
            return new Instruction(OpCode.or, mode1, register1, mode2, value2);
        }
        public static Instruction Or(
            Mode mode1, ushort register1,
            Mode mode2, ushort value2,
            Mode mode3, ushort value3) {
            return new Instruction(OpCode.or, mode1, register1, mode2, value2, mode3, value3);
        }
        public static Instruction Xor(
            Mode mode1, ushort register1,
            Mode mode2, ushort value2) {
            return new Instruction(OpCode.xor, mode1, register1, mode2, value2);
        }
        public static Instruction Xor(
            Mode mode1, ushort register1,
            Mode mode2, ushort value2,
            Mode mode3, ushort value3) {
            return new Instruction(OpCode.xor, mode1, register1, mode2, value2, mode3, value3);
        }
        public static Instruction Not(
            Mode mode1, ushort register1) {
            return new Instruction(OpCode.not, mode1, register1);
        }
        public static Instruction Not(
            Mode mode1, ushort register1,
            Mode mode2, ushort value2) {
            return new Instruction(OpCode.not, mode1, register1, mode2, value2);
        }
    }
}
