using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpuEmulator.p16 {
    public static partial class EncoderDecoder {
        public static Instruction Add(
            Mode mode1, ushort register1,
            Mode mode2, ushort value2) {
            return new Instruction(OpCode.add, mode1, register1, mode2, value2);
        }
        public static Instruction Add(
            Mode mode1, ushort register1,
            Mode mode2, ushort value2,
            Mode mode3, ushort value3) {
            return new Instruction(OpCode.add, mode1, register1, mode2, value2, mode3, value3);
        }
        public static Instruction Subtract(
            Mode mode1, ushort register1,
            Mode mode2, ushort value2) {
            return new Instruction(OpCode.sub, mode1, register1, mode2, value2);
        }
        public static Instruction Subtract(
            Mode mode1, ushort register1,
            Mode mode2, ushort value2,
            Mode mode3, ushort value3) {
            return new Instruction(OpCode.sub, mode1, register1, mode2, value2, mode3, value3);
        }
        public static Instruction Multiply(
            Mode mode1, ushort register1,
            Mode mode2, ushort value2) {
            return new Instruction(OpCode.mul, mode1, register1, mode2, value2);
        }
        public static Instruction Multiply(
            Mode mode1, ushort register1,
            Mode mode2, ushort value2,
            Mode mode3, ushort value3) {
            return new Instruction(OpCode.mul, mode1, register1, mode2, value2, mode3, value3);
        }
        public static Instruction Divide(
            Mode mode1, ushort register1,
            Mode mode2, ushort value2) {
            return new Instruction(OpCode.div, mode1, register1, mode2, value2);
        }
        public static Instruction Divide(
            Mode mode1, ushort register1,
            Mode mode2, ushort value2,
            Mode mode3, ushort value3) {
            return new Instruction(OpCode.div, mode1, register1, mode2, value2, mode3, value3);
        }
    }
}
