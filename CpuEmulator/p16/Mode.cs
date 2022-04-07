using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpuEmulator.p16 {
    public enum Mode : ushort {
        immediate      = 0b00,
        register       = 0b01,
        direct         = 0b10,
        registerDirect = 0b11
    }
}
