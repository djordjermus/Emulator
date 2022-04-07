using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpuEmulator.p16 {
    public static partial class EncoderDecoder {
        
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
            ushort st = 0;
            memory.Read(address, out st);
            instruction.Operation = st;

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
