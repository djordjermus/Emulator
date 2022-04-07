using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpuEmulator.p16 {
    public static partial class EncoderDecoder {
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
    }
}
