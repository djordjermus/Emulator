using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpuEmulator.p16 {
    public partial class Processor {
        Interrupt Load(OpCode code, ushort reg, ushort value) {
            if (!ValidRegister(reg)) return Interrupt.badRegister;
            
            bool successfull;
            switch (code) {
                case OpCode.load:
                    successfull = Set(reg, value);
                    break;

                case OpCode.loadub:
                    successfull = Set(reg, (ushort)(byte)value);
                    break;

                case OpCode.loadsb:
                    successfull = Set(reg, (ushort)(sbyte)value);
                    break;

                default:
                    return Interrupt.badInstruction;
            }
            return successfull ? Interrupt.none : Interrupt.badRegister;
        }
        Interrupt Store(OpCode code, ushort address, ushort value) {
            uint wr = 0;
            switch (code) {
                case OpCode.store:
                    wr = Memory.Write(address, value);
                    break;

                case OpCode.storelb:
                    wr = Memory.Write(address, (byte)(value >> 0));
                    break;

                case OpCode.storehb:
                    wr = Memory.Write(address, (byte)(value >> 8));
                    break;

                default:
                    return Interrupt.badInstruction;
            }
            return (wr != 0) ? Interrupt.none : Interrupt.badAddress;
        }
        Interrupt Push(OpCode code, ushort value) {
            uint add = 0;
            switch (code) {
                case OpCode.push:
                    add = Memory.Write(_reg[IX_SP], value);
                    break;

                case OpCode.pushhb:
                    add = Memory.Write(_reg[IX_SP], (byte)(value >> 8));
                    break;

                case OpCode.pushlb:
                    add = Memory.Write(_reg[IX_SP], (byte)(value >> 0));
                    break;

                default:
                    return Interrupt.badInstruction;
            }
            if(add == 0) return Interrupt.badAddress;

            // MOVE STACK POINTER
            Set(IX_SP, (ushort)(_reg[IX_SP] + add));
            if(_reg[IX_SP] > _reg[IX_SB]) return Interrupt.stackoverflow;

            return Interrupt.none;
        }
        Interrupt Pop(OpCode code, ushort reg) {
            if(!ValidRegister(reg)) return Interrupt.badRegister;

            uint   sub  = 0;
            ushort read = 0;

            switch (code) {
                case OpCode.pop: 
                    sub = Memory.Read(this[IX_SP], out read);
                    Set(reg, read);
                    break;

                case OpCode.popub:
                    sub = Memory.Read(this[IX_SP], out read);
                    Set(reg, (ushort)read);
                    
                    break;
                case OpCode.popsb:
                    sub = Memory.Read(this[IX_SP], out read);
                    Set(reg, (ushort)(short)read);
                    break;

                default:
                    return Interrupt.badInstruction;
            }
            if (sub == 0) return Interrupt.badAddress;

            // MOVE STACK POINTER
            Set(IX_SP, (ushort)(_reg[IX_SP] - sub));
            if (_reg[IX_SP] > _reg[IX_SB]) return Interrupt.stackunderflow;
            return Interrupt.none;
        }
        Interrupt Arithmetic(OpCode code, ushort reg, ushort lhs, ushort rhs, ushort opct) {
            if (!ValidRegister(reg)) return Interrupt.badRegister;
            switch (code) {
                case OpCode.add:
                    Set(reg, (ushort)(lhs + rhs));
                    break;

                case OpCode.sub:
                    Set(reg, (ushort)(lhs - rhs));
                    break;

                case OpCode.mul:
                    Set(reg, (ushort)(lhs * rhs));
                    break;

                case OpCode.div:
                    if (rhs == 0) return Interrupt.badArithmetics; // DIV BY ZERO
                    Set(reg, (ushort)(lhs / rhs));
                    break;

                default:
                    return Interrupt.badInstruction;
            }
            return Interrupt.none;
        }
        Interrupt Bitwise(OpCode code, ushort reg, ushort lhs, ushort rhs, ushort opct) {
            if (!ValidRegister(reg)) return Interrupt.badRegister;

            switch (code) {
                case OpCode.band:
                    Set(reg, (ushort)(lhs & rhs));
                    break;
                case OpCode.bor:
                    Set(reg, (ushort)(lhs | rhs));
                    break;
                case OpCode.bxor:
                    Set(reg, (ushort)(lhs ^ rhs));
                    break;
                case OpCode.lsr:
                    Set(reg, (ushort)(lhs >> rhs));
                    break;
                case OpCode.lsl:
                    Set(reg, (ushort)(lhs << rhs));
                    break;
                case OpCode.binv:
                    Set(reg, (ushort)~lhs);
                    break;
                default:
                    return Interrupt.badInstruction;
            }
            return Interrupt.none;
        }
        Interrupt Logical(OpCode code, ushort reg, ushort lhs, ushort rhs, ushort opct) {
            if (!ValidRegister(reg)) return Interrupt.badRegister;

            switch (code) {
                case OpCode.and:
                    Set(reg, ToNum(ToBool(lhs) && ToBool(rhs)));
                    break;
                case OpCode.or:
                    Set(reg, ToNum(ToBool(lhs) || ToBool(rhs)));
                    break;
                case OpCode.xor:
                    Set(reg, ToNum(
                         (ToBool(lhs) || ToBool(rhs)) &&
                        !(ToBool(lhs) && ToBool(rhs))));
                    break;
                case OpCode.not:
                    Set(reg, ToNum(!ToBool(lhs)));
                    break;
                default:
                    return Interrupt.badInstruction;
            }
            return Interrupt.none;
        }
        Interrupt Comparison(OpCode code, ushort reg, ushort lhs, ushort rhs, ushort opct) {
            if (!ValidRegister(reg)) return Interrupt.badRegister;

            switch (code) {
                case OpCode.eq:
                    Set(reg, ToNum(lhs == rhs));
                    break;
                case OpCode.neq:
                    Set(reg, ToNum(lhs != rhs));
                    break;
                case OpCode.ugt:
                    Set(reg, ToNum(lhs > rhs));
                    break;
                case OpCode.ult:
                    Set(reg, ToNum(lhs < rhs));
                    break;
                case OpCode.sgt:
                    Set(reg, ToNum((short)lhs > (short)rhs));
                    break;
                case OpCode.slt:
                    Set(reg, ToNum((short)lhs < (short)rhs));
                    break;
            }
            return Interrupt.none;
        }
        Interrupt Jump(OpCode code, ushort addr, ushort lhs, ushort rhs, ushort opct) {
            switch (code) {
                case OpCode.jmp:
                    Set(IX_PC, addr);
                    break;
                case OpCode.jeq:
                    if (lhs == rhs)
                        Set(IX_PC, addr);
                    break;
                case OpCode.jne:
                    if (lhs != rhs)
                        Set(IX_PC, addr);
                    break;

                case OpCode.rjmp:
                    Set(IX_PC, (ushort)(this[IX_PC] + addr));
                    break;
                case OpCode.rjeq:
                    if (lhs == rhs)
                        Set(IX_PC, (ushort)(this[IX_PC] + addr));
                    break;
                case OpCode.rjne:
                    if (lhs != rhs)
                        Set(IX_PC, (ushort)(this[IX_PC] + addr));
                    break;
                default:
                    return Interrupt.badInstruction;
            }
            return Interrupt.none;
        }
    }
}
