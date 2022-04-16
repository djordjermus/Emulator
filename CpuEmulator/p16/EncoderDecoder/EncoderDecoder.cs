using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpuEmulator.p16 {
    public static partial class EncoderDecoder {
        
        public static uint Encode(Memory memory, uint address, ref Instruction instruction) {
            
            // Test if instruction fits memory
            if (!memory.CanAccessRange(address, 2 + 2 * instruction.OpCount)) 
                return 0;

            // Compose core (OpCode + OpCt + m1? + m2? + m3?)
            ushort core = 0;
            core |= (ushort)instruction.Operation;
            core |= (ushort)((instruction.OpCount & 0b11) << 8);
            if (instruction.OpCount > 0)
                core |= (ushort)(((uint)instruction.Mode1 & 0b11) << 6);
            if (instruction.OpCount > 1)
                core |= (ushort)(((uint)instruction.Mode2 & 0b11) << 4);
            if (instruction.OpCount > 2)
                core |= (ushort)(((uint)instruction.Mode3 & 0b11) << 2);

            // Write core
            memory.Write(address, core);

            // Write operands
            if(instruction.OpCount > 0)
                memory.Write(address + 2, instruction.Operand1);
            if (instruction.OpCount > 1)
                memory.Write(address + 4, instruction.Operand2);
            if (instruction.OpCount > 2)
                memory.Write(address + 6, instruction.Operand3);

            return 2 + instruction.OpCount * 2;
        }
        public static uint Decode(Memory memory, uint address, out Instruction instruction) {
            instruction = new Instruction();

            // Test if operation is readable
            if (!memory.CanAccessRange(address, 2))
                return 0;

            // Read operation
            memory.Read(address, out ushort core);
            instruction.Operation = (OpCode)(core & 0b11111100_00000000);
            
            // Read operands
            instruction.OpCount = (uint)((core >> 8) & 0b11);
            // Test if operands are readable
            if (!memory.CanAccessRange(address, 2 + 2 * instruction.OpCount))
                return 0;

            if (instruction.OpCount > 0)
                instruction.Mode1 = (Mode)((core >> 6) & 0b11);
            if (instruction.OpCount > 1)
                instruction.Mode2 = (Mode)((core >> 4) & 0b11);
            if (instruction.OpCount > 2)
                instruction.Mode3 = (Mode)((core >> 2) & 0b11);

            ushort rd;
            if (instruction.OpCount > 0) { 
                memory.Read(address + 2, out rd);
                instruction.Operand1 = rd;
            }
            if (instruction.OpCount > 1) { 
                memory.Read(address + 4, out rd);
                instruction.Operand2 = rd;
            }
            if (instruction.OpCount > 2) { 
                memory.Read(address + 6, out rd);
                instruction.Operand3 = rd;
            }

            return 2 + instruction.OpCount * 2;
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
