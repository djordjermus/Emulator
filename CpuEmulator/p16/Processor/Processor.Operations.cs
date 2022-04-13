using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpuEmulator.p16 {
    public partial class Processor {
        Interrupt OpLoad(OpCode code, ushort r1, ushort v2) {
            if (!ValidRegister(r1)) return Interrupt.badRegister;
            bool success = false;
            switch (code) {
                case OpCode.load:
                    success = Set(r1, v2);
                    break;

                case OpCode.loadub:
                    success = Set(r1, (ushort)(byte)v2);
                    break;

                case OpCode.loadsb:
                    success = Set(r1, (ushort)(sbyte)v2);
                    break;

                default:
                    return Interrupt.badInstruction;
            }
            if (success) { 
                _onExecute();
                return Interrupt.none;
            } 
            else return Interrupt.badRegister;
        }
        Interrupt OpStore(OpCode code, ushort a1, ushort v2) {
            uint wr = 0;
            switch (code) {
                case OpCode.store:
                    wr = Memory.Write(a1, v2);
                    break;

                case OpCode.storelb:
                    wr = Memory.Write(a1, (byte)(v2 >> 0));
                    break;

                case OpCode.storehb:
                    wr = Memory.Write(a1, (byte)(v2 >> 8));
                    break;

                default:
                    return Interrupt.badInstruction;
            }
            if (wr != 0) {
                _onExecute();
                return Interrupt.none;
            }
            return Interrupt.badAddress;
        }
        Interrupt OpPush(OpCode code, ushort v1) {
            uint add = 0;
            switch (code) {
                case OpCode.push:
                    add = Memory.Write(_reg[IX_SP], v1);
                    break;

                case OpCode.pushhb:
                    add = Memory.Write(_reg[IX_SP], (byte)(v1 >> 8));
                    break;

                case OpCode.pushlb:
                    add = Memory.Write(_reg[IX_SP], (byte)(v1 >> 0));
                    break;

                default:
                    return Interrupt.badInstruction;
            }
            if(add == 0) return Interrupt.badAddress;

            // MOVE STACK POINTER
            Set(IX_SP, (ushort)(_reg[IX_SP] + add));
            if(_reg[IX_SP] > _reg[IX_SB]) return Interrupt.stackoverflow;

            _onExecute();
            return Interrupt.none;
        }
        Interrupt OpPop(OpCode code, ushort r1) {
            if(!ValidRegister(r1)) return Interrupt.badRegister;

            uint   sub  = 0;
            ushort read = 0;

            switch (code) {
                case OpCode.pop: 
                    sub = Memory.Read(this[IX_SP], out read);
                    Set(r1, read);
                    break;

                case OpCode.popub:
                    sub = Memory.Read(this[IX_SP], out read);
                    Set(r1, (ushort)read);
                    
                    break;
                case OpCode.popsb:
                    sub = Memory.Read(this[IX_SP], out read);
                    Set(r1, (ushort)(short)read);
                    break;

                default:
                    return Interrupt.badInstruction;
            }
            if (sub == 0) return Interrupt.badAddress;

            // MOVE STACK POINTER
            Set(IX_SP, (ushort)(_reg[IX_SP] - sub));
            if (_reg[IX_SP] > _reg[IX_SB]) return Interrupt.stackunderflow;

            _onExecute();
            return Interrupt.none;
        }
        Interrupt OpArithmetic(OpCode code, ushort r1, ushort v2, ushort v3, ushort opct) {
            if (!ValidRegister(r1)) return Interrupt.badRegister;

            Convert(opct, ref r1, ref v2, ref v3);

            switch (code) {
                case OpCode.add:
                    if (opct < 2) return Interrupt.badInstruction;
                    Set(r1, (ushort)(v2 + v3));
                    break;

                case OpCode.sub:
                    if (opct < 2) return Interrupt.badInstruction;
                    Set(r1, (ushort)(v2 - v3));
                    break;

                case OpCode.mul:
                    if (opct < 2) return Interrupt.badInstruction;
                    Set(r1, (ushort)(v2 * v3));
                    break;

                case OpCode.div:
                    if (opct < 2) return Interrupt.badInstruction;
                    if (v3 == 0) return Interrupt.badArithmetics; // DIV BY ZERO
                    Set(r1, (ushort)(v2 / v3));
                    break;

                default:
                    return Interrupt.badInstruction;
            }
            _onExecute();
            return Interrupt.none;
        }
        Interrupt OpBitwise(OpCode code, ushort r1, ushort v2, ushort v3, ushort opct) {
            if (!ValidRegister(r1)) return Interrupt.badRegister;

            Convert(opct, ref r1, ref v2, ref v3);

            switch (code) {
                case OpCode.band:
                    if (opct < 2) return Interrupt.badInstruction;
                    Set(r1, (ushort)(v2 & v3));
                    break;
                case OpCode.bor:
                    if (opct < 2) return Interrupt.badInstruction;
                    Set(r1, (ushort)(v2 | v3));
                    break;
                case OpCode.bxor:
                    if (opct < 2) return Interrupt.badInstruction;
                    Set(r1, (ushort)(v2 ^ v3));
                    break;
                case OpCode.lsr:
                    if (opct < 2) return Interrupt.badInstruction;
                    Set(r1, (ushort)(v2 >> v3));
                    break;
                case OpCode.lsl:
                    if (opct < 2) return Interrupt.badInstruction;
                    Set(r1, (ushort)(v2 << v3));
                    break;
                case OpCode.binv:
                    if (opct < 1) return Interrupt.badInstruction;
                    Set(r1, (ushort)~v2);
                    break;
                default:
                    return Interrupt.badInstruction;
            }
            _onExecute();
            return Interrupt.none;
        }
        Interrupt OpLogical(OpCode code, ushort r1, ushort v2, ushort v3, ushort opct) {
            if (!ValidRegister(r1)) return Interrupt.badRegister;

            Convert(opct, ref r1, ref v2, ref v3);

            switch (code) {
                case OpCode.and:
                    if (opct < 2) return Interrupt.badInstruction;
                    Set(r1, ToNum(ToBool(v2) && ToBool(v3)));
                    break;
                case OpCode.or:
                    if (opct < 2) return Interrupt.badInstruction;
                    Set(r1, ToNum(ToBool(v2) || ToBool(v3)));
                    break;
                case OpCode.xor:
                    if (opct < 2) return Interrupt.badInstruction;
                    Set(r1, ToNum(
                         (ToBool(v2) || ToBool(v3)) &&
                        !(ToBool(v2) && ToBool(v3))));
                    break;
                case OpCode.not:
                    if (opct < 1) return Interrupt.badInstruction;
                    Set(r1, ToNum(!ToBool(v2)));
                    break;
                default:
                    return Interrupt.badInstruction;
            }
            _onExecute();
            return Interrupt.none;
        }
        Interrupt OpComparison(OpCode code, ushort r1, ushort v2, ushort v3, ushort opct) {
            if (!ValidRegister(r1)) return Interrupt.badRegister;

            Convert(opct, ref r1, ref v2, ref v3);

            switch (code) {
                case OpCode.eq:
                    if (opct < 2) return Interrupt.badInstruction;
                    Set(r1, ToNum(v2 == v3));
                    break;
                case OpCode.neq:
                    if (opct < 2) return Interrupt.badInstruction;
                    Set(r1, ToNum(v2 != v3));
                    break;
                case OpCode.ugt:
                    if (opct < 2) return Interrupt.badInstruction;
                    Set(r1, ToNum(v2 > v3));
                    break;
                case OpCode.ult:
                    if (opct < 2) return Interrupt.badInstruction;
                    Set(r1, ToNum(v2 < v3));
                    break;
                case OpCode.sgt:
                    if (opct < 2) return Interrupt.badInstruction;
                    Set(r1, ToNum((short)v2 > (short)v3));
                    break;
                case OpCode.slt:
                    if (opct < 2) return Interrupt.badInstruction;
                    Set(r1, ToNum((short)v2 < (short)v3));
                    break;
            }
            _onExecute();
            return Interrupt.none;
        }
        Interrupt OpJump(OpCode code, ushort a1, ushort v2, ushort v3, ushort opct) {
            switch (code) {
                case OpCode.jmp:
                    if (opct < 1) return Interrupt.badInstruction;
                    Set(IX_PC, a1);
                    break;
                case OpCode.jeq:
                    if (opct < 3) return Interrupt.badInstruction;
                    if (v2 == v3)
                        Set(IX_PC, a1);
                    break;
                case OpCode.jne:
                    if (opct < 3) return Interrupt.badInstruction;
                    if (v2 != v3)
                        Set(IX_PC, a1);
                    break;

                case OpCode.rjmp:
                    if (opct < 1) return Interrupt.badInstruction;
                    Set(IX_PC, (ushort)(this[IX_PC] + a1));
                    break;
                case OpCode.rjeq:
                    if (opct < 3) return Interrupt.badInstruction;
                    if (v2 == v3)
                        Set(IX_PC, (ushort)(this[IX_PC] + a1));
                    break;
                case OpCode.rjne:
                    if (opct < 3) return Interrupt.badInstruction;
                    if (v2 != v3)
                        Set(IX_PC, (ushort)(this[IX_PC] + a1));
                    break;
                default:
                    return Interrupt.badInstruction;
            }
            _onExecute();
            return Interrupt.none;
        }
        
        void Convert(ushort opct, ref ushort r1, ref ushort v2, ref ushort v3) { 
            if (opct == 2) { v3 = v2; Get(r1, out v2); }
        }
    }
}
