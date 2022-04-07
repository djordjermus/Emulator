using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpuEmulator {
    public struct Instruction {
        public Instruction(uint operation, uint operand1, uint operand2, uint operand3) {
            Operation = operation;
            Operand1  = operand1;
            Operand2  = operand2;
            Operand3  = operand3;
        }
        public uint Operation { get; set; } = 0;
        public uint Operand1 { get; set; } = 0;
        public uint Operand2 { get; set; } = 0;
        public uint Operand3 { get; set; } = 0;
    }
}
