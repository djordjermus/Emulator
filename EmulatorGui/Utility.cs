using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmulatorGui {
    public static class Utility {
        public static string ModeToShortString(CpuEmulator.p16.Mode mode) {
            switch (mode) {
                case CpuEmulator.p16.Mode.immediate:
                    return "imm";
                case CpuEmulator.p16.Mode.register:
                    return "reg";
                case CpuEmulator.p16.Mode.direct:
                    return "dir";
                case CpuEmulator.p16.Mode.registerDirect:
                    return "rdr";
                default:
                    return "n/a";
            }
        }
    }
}
