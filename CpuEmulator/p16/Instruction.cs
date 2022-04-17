using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpuEmulator.p16 {
    public class Instruction {
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
