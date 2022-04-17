using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpuEmulator.p16 {
    public enum Interrupt : ushort {
        none            = 0x00,
        stackoverflow   = 0x18,
        stackunderflow  = 0x19,
        badRegister     = 0x1A,
        badAddress      = 0x1B,
        badPc           = 0x1C,
        badInstruction  = 0x1D,
        badArithmetics  = 0x1E,
        induced         = 0x1F,

    }
}
