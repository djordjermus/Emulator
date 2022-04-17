using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpuEmulator.p16 {
    public partial class Processor {
        public ushort this[uint ix] {
            get {
                Get(ix, out ushort ret);
                return ret;
            }
            set { 
                Set(ix, value);
            }
        }
        public bool Set(uint ix, ushort value) {
            if (ix < 32) { 
                _reg[ix] = value;
                return true;
            }
            return false;
        }
        public bool Get(uint ix, out ushort output) {
            if (ix < 32) {
                output = _reg[ix];
                return true;
            }
            output = 0;
            return false;
        }

        public bool CarryFlag     { 
            get => (_reg[IX_ST] & 0b00000001) != 0;
            set {
                if (value) 
                    _reg[IX_ST] = (ushort)(_reg[IX_ST] |  0b00000001);
                else 
                    _reg[IX_ST] = (ushort)(_reg[IX_ST] & ~0b00000001);
            }
        }
        public bool ZeroFlag      { 
            get => (_reg[IX_ST] & 0b00000010) != 0;
            set {
                if (value)
                    _reg[IX_ST] = (ushort)(_reg[IX_ST] |  0b00000010);
                else
                    _reg[IX_ST] = (ushort)(_reg[IX_ST] & ~0b00000010);
            }
        }
        public bool SignFlag      { 
            get => (_reg[IX_ST] & 0b00000100) != 0;
            set {
                if (value)
                    _reg[IX_ST] = (ushort)(_reg[IX_ST] |  0b00000100);
                else
                    _reg[IX_ST] = (ushort)(_reg[IX_ST] & ~0b00000100);
            }
        }
        public bool OverflowFlag  { 
            get => (_reg[IX_ST] & 0b00001000) != 0;
            set {
                if (value)
                    _reg[IX_ST] = (ushort)(_reg[IX_ST] |  0b00001000);
                else
                    _reg[IX_ST] = (ushort)(_reg[IX_ST] & ~0b00001000);
            }
        }
        public bool InterruptFlag { 
            get => (_reg[IX_ST] & 0b00010000) != 0;
            set {
                if (value)
                    _reg[IX_ST] = (ushort)(_reg[IX_ST] |  0b00010000);
                else
                    _reg[IX_ST] = (ushort)(_reg[IX_ST] & ~0b00010000);
            }
        }

        ushort[]    _reg = new ushort[32];
        public const uint IX_GPR0 = 0x00; // GENERAL PURPOSE REGISTER #1
        public const uint IX_GPR1 = 0x01; // GENERAL PURPOSE REGISTER #2
        public const uint IX_GPR2 = 0x02; // GENERAL PURPOSE REGISTER #3
        public const uint IX_GPR3 = 0x03; // GENERAL PURPOSE REGISTER #4
        public const uint IX_GPR4 = 0x04; // GENERAL PURPOSE REGISTER #5
        public const uint IX_GPR5 = 0x05; // GENERAL PURPOSE REGISTER #6
        public const uint IX_GPR6 = 0x06; // GENERAL PURPOSE REGISTER #7
        public const uint IX_GPR7 = 0x07; // GENERAL PURPOSE REGISTER #8
        public const uint IX_GPR8 = 0x08; // GENERAL PURPOSE REGISTER #9
        public const uint IX_GPR9 = 0x09; // GENERAL PURPOSE REGISTER #10
        public const uint IX_GPRA = 0x0A; // GENERAL PURPOSE REGISTER #11
        public const uint IX_GPRB = 0x0B; // GENERAL PURPOSE REGISTER #12
        public const uint IX_GPRC = 0x0C; // GENERAL PURPOSE REGISTER #13
        public const uint IX_GPRD = 0x0D; // GENERAL PURPOSE REGISTER #14
        public const uint IX_GPRE = 0x0E; // GENERAL PURPOSE REGISTER #15
        public const uint IX_GPRF = 0x0F; // GENERAL PURPOSE REGISTER #16

        public const uint IX_IXR0 = 0x10; // INDEX REGISTER #1
        public const uint IX_IXR1 = 0x11; // INDEX REGISTER #2
        public const uint IX_IXR2 = 0x12; // INDEX REGISTER #3
        public const uint IX_IXR3 = 0x13; // INDEX REGISTER #4

        public const uint IX_SP   = 0x14; // STACK POINTER
        public const uint IX_SB   = 0x15; // STACK BOUNDS
        public const uint IX_ST   = 0x16; // STATE
        public const uint IX_PC   = 0x17; // PROGRAM COUNTER

        public const uint IX_IRR0 = 0x18; // Interrupt #1 (STACK OVERFLOW)
        public const uint IX_IRR1 = 0x19; // Interrupt #2 (STACK UNDERFLOW)
        public const uint IX_IRR2 = 0x1A; // Interrupt #3 (BAD REGISTER)
        public const uint IX_IRR3 = 0x1B; // Interrupt #4 (BAD MEMORY ADDRESS)
        public const uint IX_IRR4 = 0x1C; // Interrupt #5 (BAD PC VALUE)
        public const uint IX_IRR5 = 0x1D; // Interrupt #6 (BAD INSTRUCTION)
        public const uint IX_IRR6 = 0x1E; // Interrupt #7 (BAD ARITHMETICS)
        public const uint IX_IRR7 = 0x1F; // Interrupt #8 (INDUCED)
    }
}
