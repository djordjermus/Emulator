using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpuEmulator.p16 {
    public static partial class EncoderDecoder {
        public static uint Encode(Memory memory, uint address, ref Instruction instruction) {
            
            // Test if instruction fits memory
            if (!memory.CanAccess(address, 2 + 2 * instruction.OpCount)) 
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
            if (memory.CanAccess(address, 2))
                memory.Write(address, core);
            else return 0;

            // Write operands
            if (instruction.OpCount > 0 && memory.CanAccess(address + 2, 2))
                memory.Write(address + 2, instruction.Operand1);
            else return 2;

            if (instruction.OpCount > 1 && memory.CanAccess(address + 4, 2))
                memory.Write(address + 4, instruction.Operand2);
            else return 4;

            if (instruction.OpCount > 2 && memory.CanAccess(address + 6, 2))
                memory.Write(address + 6, instruction.Operand3);
            else return 6;

            return 8;
        }
        public static uint Decode(Memory memory, uint address, out Instruction instruction) {
            instruction = new Instruction();

            // Test if operation is readable
            if (!memory.CanAccess(address, 2))
                return 0;

            // Read operation
            memory.Read(address, out ushort core);
            instruction.Operation = (OpCode)(core & 0b11111100_00000000);
            
            // Read operands
            instruction.OpCount = (uint)((core >> 8) & 0b11);
            // Test if operands are readable
            if (!memory.CanAccess(address, 2 + 2 * instruction.OpCount))
                return 0;

            if (instruction.OpCount > 0)
                instruction.Mode1 = (Mode)((core >> 6) & 0b11);
            if (instruction.OpCount > 1)
                instruction.Mode2 = (Mode)((core >> 4) & 0b11);
            if (instruction.OpCount > 2)
                instruction.Mode3 = (Mode)((core >> 2) & 0b11);

            ushort rd;
            if (instruction.OpCount > 0 && memory.Read(address + 2, out rd) == 2)
                instruction.Operand1 = rd;
            else return 2;

            if (instruction.OpCount > 1 && memory.Read(address + 4, out rd) == 2) 
                instruction.Operand2 = rd;
            else return 4;

            if (instruction.OpCount > 2 && memory.Read(address + 6, out rd) == 2)
                instruction.Operand3 = rd;
            else return 6;

            return 8;
        }
    }
}
