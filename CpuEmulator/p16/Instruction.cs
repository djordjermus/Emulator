using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpuEmulator.p16 {
    public class Instruction {
        public Instruction(Memory memory, uint address) { Decode(memory, address); }
        public Instruction() {
            Operation = OpCode.noop;
            OpCount = 0;
        }
        public Instruction(OpCode code) {
            Operation = code;
            OpCount   = 0;
        }
        public Instruction(
            OpCode code,
            Mode mode1, ushort operand1) {
            Operation = code;
            OpCount   = 1;

            Mode1     = mode1; Operand1 = operand1;
        }
        public Instruction(
            OpCode code,
            Mode mode1, ushort operand1,
            Mode mode2, ushort operand2) {
            Operation = code;
            OpCount   = 2;

            Mode1 = mode1; Operand1 = operand1;
            Mode2 = mode2; Operand2 = operand2;
        }
        public Instruction(
            OpCode code,
            Mode mode1, ushort operand1,
            Mode mode2, ushort operand2,
            Mode mode3, ushort operand3) {
            Operation = code;
            OpCount   = 3;

            Mode1 = mode1; Operand1 = operand1;
            Mode2 = mode2; Operand2 = operand2;
            Mode3 = mode3; Operand3 = operand3;
        }

        public uint Encode(Memory memory, uint address) {

            // Test if instruction fits memory
            if (!memory.CanAccess(address, 2 + 2 * OpCount))
                return 0;

            // Compose core (OpCode + OpCt + m1? + m2? + m3?)
            ushort core = 0;
            core |= (ushort)Operation;
            core |= (ushort)((OpCount & 0b11) << 8);
            if (OpCount > 0)
                core |= (ushort)(((uint)Mode1 & 0b11) << 6);
            if (OpCount > 1)
                core |= (ushort)(((uint)Mode2 & 0b11) << 4);
            if (OpCount > 2)
                core |= (ushort)(((uint)Mode3 & 0b11) << 2);

            // Write core
            if (memory.CanAccess(address, 2))
                memory.Write(address, core);
            else return 0;

            // Write operands
            if (OpCount > 0 && memory.CanAccess(address + 2, 2))
                memory.Write(address + 2, Operand1);
            else return 2;

            if (OpCount > 1 && memory.CanAccess(address + 4, 2))
                memory.Write(address + 4, Operand2);
            else return 4;

            if (OpCount > 2 && memory.CanAccess(address + 6, 2))
                memory.Write(address + 6, Operand3);
            else return 6;

            return 8;
        }
        public uint Decode(Memory memory, uint address) {

            // Reset instruction description
            Operation   = OpCode.noop;
            OpCount     = 0;
            Mode1       = Mode2    = Mode3    = Mode.immediate;

            Operand1    = Operand2 = Operand3 = 0;
            // Test if core is readable
            if (!memory.CanAccess(address, 2))
                return 0;

            // Read operation
            memory.Read(address, out ushort core);
            Operation = (OpCode)(core & 0b11111100_00000000);

            // Read operands
            OpCount = (uint)((core >> 8) & 0b11);
            // Test if operands are readable
            if (!memory.CanAccess(address, 2 + 2 * OpCount))
                return 0;

            if (OpCount > 0)
                Mode1 = (Mode)((core >> 6) & 0b11);
            if (OpCount > 1)
                Mode2 = (Mode)((core >> 4) & 0b11);
            if (OpCount > 2)
                Mode3 = (Mode)((core >> 2) & 0b11);

            ushort rd;
            if (OpCount > 0 && memory.Read(address + 2, out rd) == 2)
                Operand1 = rd;
            else return 2;

            if (OpCount > 1 && memory.Read(address + 4, out rd) == 2)
                Operand2 = rd;
            else return 4;

            if (OpCount > 2 && memory.Read(address + 6, out rd) == 2)
                Operand3 = rd;
            else return 6;

            return 8;
        }

        public OpCode Operation { get; set; } = OpCode.noop;
        public uint OpCount { get; set; } = 0;

        public Mode Mode1 { get; set; } = Mode.immediate;
        public Mode Mode2 { get; set; } = Mode.immediate;
        public Mode Mode3 { get; set; } = Mode.immediate;

        public ushort Operand1 { get; set; } = 0;
        public ushort Operand2 { get; set; } = 0;
        public ushort Operand3 { get; set; } = 0;
    }
}
