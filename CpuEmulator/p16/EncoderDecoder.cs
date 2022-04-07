using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpuEmulator.p16 {
    public static class EncoderDecoder {
        public static uint Encode(Memory memory, uint address, ref Instruction instruction) {
            uint opct = GetOpCount(ref instruction);
            
            // Test if instruction fits memory
            if (!memory.CanAccessRange(address, 2 + 2 * opct)) 
                return 0;

            // Encode operation
            memory.Write(address, (ushort)instruction.Operation);
            if(opct > 0)
                memory.Write(address + 2, (ushort)instruction.Operand1);
            if (opct > 1)
                memory.Write(address + 4, (ushort)instruction.Operand2);
            if (opct > 2)
                memory.Write(address + 6, (ushort)instruction.Operand3);

            return 2 + opct * 2;
        }
        public static uint Decode(Memory memory, uint address, out Instruction instruction) {
            instruction = new Instruction();

            // Test if operation is readable
            if (!memory.CanAccessRange(address, 2))
                return 0;

            // Read operation
            instruction.Operation = GetOpCount(ref instruction);

            // Read operands
            uint opct = GetOpCount(ref instruction);
            // Test if operands are readable
            if (!memory.CanAccessRange(address, 2 + 2 * opct))
                return 0;

            ushort rd = 0;
            if (opct > 0) { 
                memory.Read(address + 2, out rd);
                instruction.Operand1 = rd;
            }
            if (opct > 1) { 
                memory.Read(address + 4, out rd);
                instruction.Operand2 = rd;
            }
            if (opct > 2) { 
                memory.Read(address + 6, out rd);
                instruction.Operand3 = rd;
            }

            return 2 + opct * 2;
        }

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
        public static Instruction Store(
            Mode mode1, ushort address1,
            Mode mode2, ushort value2) {
            return Custom(OpCode.store, mode1, address1, mode2, value2);
        }
        public static Instruction Push(
            Mode mode1, ushort value1) { 
            return Custom(OpCode.push, mode1, value1);
        }
        public static Instruction Pop(
            Mode mode1, ushort register1) { 
            return Custom(OpCode.push, mode1, register1);
        }

        //
        // Arithmetics

        public static Instruction Add(
            Mode mode1, ushort register1,
            Mode mode2, ushort value2) {
            return Custom(OpCode.add, mode1, register1, mode2, value2);
        }
        public static Instruction Add(
            Mode mode1, ushort register1,
            Mode mode2, ushort value2,
            Mode mode3, ushort value3) {
            return Custom(OpCode.add, mode1, register1, mode2, value2, mode3, value3);
        }
        public static Instruction Subtract(
            Mode mode1, ushort register1,
            Mode mode2, ushort value2) {
            return Custom(OpCode.sub, mode1, register1, mode2, value2);
        }
        public static Instruction Subtract(
            Mode mode1, ushort register1,
            Mode mode2, ushort value2,
            Mode mode3, ushort value3) {
            return Custom(OpCode.sub, mode1, register1, mode2, value2, mode3, value3);
        }
        public static Instruction Multiply(
            Mode mode1, ushort register1,
            Mode mode2, ushort value2) {
            return Custom(OpCode.mul, mode1, register1, mode2, value2);
        }
        public static Instruction Multiply(
            Mode mode1, ushort register1,
            Mode mode2, ushort value2,
            Mode mode3, ushort value3) {
            return Custom(OpCode.mul, mode1, register1, mode2, value2, mode3, value3);
        }
        public static Instruction Divide(
            Mode mode1, ushort register1,
            Mode mode2, ushort value2) {
            return Custom(OpCode.div, mode1, register1, mode2, value2);
        }
        public static Instruction Divide(
            Mode mode1, ushort register1,
            Mode mode2, ushort value2,
            Mode mode3, ushort value3) {
            return Custom(OpCode.div, mode1, register1, mode2, value2, mode3, value3);
        }

        //
        // Bitwise logical

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

        // Bitwise logical
        public static Instruction And(
            Mode mode1, ushort register1,
            Mode mode2, ushort value2) {
            return Custom(OpCode.band, mode1, register1, mode2, value2);
        }
        public static Instruction And(
            Mode mode1, ushort register1,
            Mode mode2, ushort value2,
            Mode mode3, ushort value3) {
            return Custom(OpCode.band, mode1, register1, mode2, value2, mode3, value3);
        }
        public static Instruction Or(
            Mode mode1, ushort register1,
            Mode mode2, ushort value2) {
            return Custom(OpCode.bor, mode1, register1, mode2, value2);
        }
        public static Instruction Or(
            Mode mode1, ushort register1,
            Mode mode2, ushort value2,
            Mode mode3, ushort value3) {
            return Custom(OpCode.bor, mode1, register1, mode2, value2, mode3, value3);
        }
        public static Instruction Xor(
            Mode mode1, ushort register1,
            Mode mode2, ushort value2) {
            return Custom(OpCode.bxor, mode1, register1, mode2, value2);
        }
        public static Instruction Xor(
            Mode mode1, ushort register1,
            Mode mode2, ushort value2,
            Mode mode3, ushort value3) {
            return Custom(OpCode.bxor, mode1, register1, mode2, value2, mode3, value3);
        }
        public static Instruction Not(
            Mode mode1, ushort register1) {
            return Custom(OpCode.binv, mode1, register1);
        }
        public static Instruction Not(
            Mode mode1, ushort register1,
            Mode mode2, ushort value2) {
            return Custom(OpCode.binv, mode1, register1, mode2, value2);
        }

        //
        // Jumps

        public static Instruction Jump(
            Mode mode1, ushort value1) {
            return Custom(OpCode.jmp, mode1, value1);
        }


        public static Instruction Custom(
            OpCode opcode,
            Mode mode1, ushort value1,
            Mode mode2, ushort value2,
            Mode mode3, ushort value3) {
            return new Instruction(
                (uint)opcode |
                threeOperands |

                (uint)mode1 << mode1Offset | 
                (uint)mode2 << mode2Offset | 
                (uint)mode3 << mode3Offset,

                value1, value2, value3);
        }
        public static Instruction Custom(
            OpCode opcode,
            Mode mode1, ushort value1,
            Mode mode2, ushort value2) {
            return new Instruction(
                (uint)opcode |
                twoOperands |

                (uint)mode1 << mode1Offset |
                (uint)mode2 << mode2Offset,

                value1, value2, 0);
        }
        public static Instruction Custom(
            OpCode opcode,
            Mode mode1, ushort value1) {
            return new Instruction(
                (uint)opcode |
                oneOperands |

                (uint)mode1 << mode1Offset,

                value1, 0, 0);
        }

        public static Instruction Custom(
            OpCode opcode) {
            return new Instruction(
                (uint)opcode |
                zeroOperands,

                0, 0, 0);
        }

        // Extraction functions

        public static OpCode GetOpCode(ref Instruction instruction) { 
            return (OpCode)((instruction.Operation >> opCodeOffset) & opCodeMask);
        }
        public static uint GetOpCount(ref Instruction instruction) {
            return (instruction.Operation >> opCountOffset) & opCountMask;
        }
        public static Mode GetMode1(ref Instruction instruction) {
            return (Mode)((instruction.Operation >> mode1Offset) & modeMask);
        }
        public static Mode GetMode2(ref Instruction instruction) {
            return (Mode)((instruction.Operation >> mode2Offset) & modeMask);
        }
        public static Mode GetMode3(ref Instruction instruction) {
            return (Mode)((instruction.Operation >> mode3Offset) & modeMask);
        }

        // CONSTANTS

        public const int opCodeOffset  = 0;
        public const uint opCodeMask   = 0b11111100_00000000;

        public const int opCountOffset = 8;
        public const uint opCountMask  = 0b00000000_00000011;

        public const int  mode1Offset  = 6;
        public const int  mode2Offset  = 4;
        public const int  mode3Offset  = 2;
        public const uint modeMask     = 0b00000000_00000011;

        public const uint zeroOperands  = 0b000000_00_00000000;
        public const uint oneOperands   = 0b000000_01_00000000;
        public const uint twoOperands   = 0b000000_10_00000000;
        public const uint threeOperands = 0b000000_11_00000000;
    }
}
