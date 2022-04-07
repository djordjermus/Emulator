using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpuEmulator.p16 {
    using EncDec = EncoderDecoder;
    public partial class Processor {
        public delegate void SetCallback(uint registerIndex);

        public Processor(Memory memory) {
            Memory = memory;
        }
        public Memory Memory { get; set; }
        public event SetCallback OnSet {
            add    => _onSet += value;
            remove => _onSet -= value;
        }

        // - - - - - - - - - - - - - - - - -
        // R E L E V A N T   C O D E- - - -
        // - - - - - - - - - - - - - - - -

        // Fetches next instruction, advances PC
        // !!!Does not handle interrupt!!!
        private Interrupt Fetch(out Instruction instruction) {
            // READ INSTRUCTION
            ushort len = (ushort)EncDec.Decode(Memory, _reg[IX_PC], out instruction);

            // FAILIURE TO READ INSTRUCTION
            if (len == 0)
                return Interrupt.badPcValue; 

            // MOVE PC
            Set(IX_PC, (ushort)(_reg[IX_PC] + len));

            return Interrupt.none;
        }
        // Evaluates single operand
        // !!!Does not handle interrupt!!!
        public Interrupt Evaluate(Mode mode, ushort op, out ushort value) {
            value = 0;

            switch (mode) {
                case Mode.immediate:
                    value = op;

                    return Interrupt.none;

                case Mode.register:
                    if (!ValidRegister(op)) 
                        return Interrupt.badRegister;
                    value = _reg[op];

                    return Interrupt.none;

                case Mode.direct:
                    if (!Memory.CanAccess(op + 1u)) 
                        return Interrupt.badAddress;
                    value = Memory[op];

                    return Interrupt.none;

                case Mode.registerDirect:
                    if (!ValidRegister(op)) 
                        return Interrupt.badRegister;
                    uint addr = _reg[op];

                    if (!Memory.CanAccess(addr + 1u)) 
                        return Interrupt.badAddress;
                    value = Memory[addr];

                    return Interrupt.none;
            }
            return Interrupt.badInstruction;
        }
        // Decomposes instruction and evaluates its operands
        // !!!Does not handle interrupt!!!
        public Interrupt Decompose(
            ref Instruction instruction,
            out OpCode operationCode, out uint opCount,
            out ushort value1, out ushort value2, out ushort value3) {

            //
            // Resolve instruction and operands
            operationCode = EncDec.GetOpCode(ref instruction);
            opCount = EncDec.GetOpCount(ref instruction);

            Interrupt[] i = new Interrupt[3] { Interrupt.none, Interrupt.none, Interrupt.none };

            if(opCount > 0)
                i[0] = Evaluate(
                    EncDec.GetMode1(ref instruction), 
                    (ushort)instruction.Operand1, out value1);
            else value1 = 0;
            if(opCount > 1)
                i[1] = Evaluate(
                    EncDec.GetMode2(ref instruction), 
                    (ushort)instruction.Operand2, out value2);
            else value2 = 0;
            if (opCount > 2)
                i[2] = Evaluate(
                    EncDec.GetMode3(ref instruction),
                    (ushort)instruction.Operand3, out value3);
            else value3 = 0;

            // Validate that operators are properly evaluated
            foreach (Interrupt interrupt in i) {
                if (interrupt != Interrupt.none) 
                    return interrupt;
            }
            return Interrupt.none;
        }
        
        // Executes decomposed instruction
        // !!!Does not handle interrupt!!!
        public Interrupt Execute(
            OpCode opcode, uint opcount,
            ushort v1, ushort v2, ushort v3) {

                switch (opcode) {
                case OpCode.noop:
                    return Interrupt.none;

                // - - - - - - - - - - - - - - - - - -
                // M E M O R Y- - - - - - - - - - - -
                // - - - - - - - - - - - - - - - - -

                // LOAD REG VAL
                case OpCode.load:
                case OpCode.loadsb:
                case OpCode.loadub:
                    Load(opcode, v1, v2);
                    break;

                // LOAD ADR VAL
                case OpCode.store:
                case OpCode.storehb:
                case OpCode.storelb:
                    Store(opcode, v1, v2);
                    break;

                // PUSH VAL
                case OpCode.push:
                case OpCode.pushhb:
                case OpCode.pushlb:
                    Push(opcode, v1);
                    break;

                // POP REG
                case OpCode.pop:
                case OpCode.popub:
                case OpCode.popsb:
                    Pop(opcode, v1);
                    break;

                // - - - - - - - - - - - - - - - - - - -
                // A R I T H M E T I C- - - - - - - - -
                // - - - - - - - - - - - - - - - - - -

                case OpCode.add:
                case OpCode.sub:
                case OpCode.mul:
                case OpCode.div:
                // ___ REG VAL / ___ REG VAL VAL
                    Arithmetic(opcode, v1, v2, v3, (ushort)opcount);
                    
                    break;

                // - - - - - - - - - - - - - 
                // B I T W I S E- - - - - - 
                // - - - - - - - - - - - - 

                case OpCode.band:
                case OpCode.bor:
                case OpCode.bxor:
                case OpCode.lsl:
                case OpCode.lsr:
                case OpCode.binv:
                // ___ REG VAL / REG VAL VAL
                    Bitwise(opcode, v1, v2, v3, (ushort)opcount);
                    break;

                // - - - - - - - - - - - - - 
                // L O G I C A L- - - - - - 
                // - - - - - - - - - - - - 

                case OpCode.and:
                case OpCode.or:
                case OpCode.xor:
                case OpCode.not:
                    Logical(opcode, v1, v2, v3, (ushort)opcount);
                    break;

                // - - - - - - - - - - - - - - - -
                // C O M P A R I S O N- - - - - - 
                // - - - - - - - - - - - - - - -

                case OpCode.eq:
                case OpCode.neq:
                case OpCode.ugt:
                case OpCode.ult:
                case OpCode.sgt:
                case OpCode.slt:
                // ___ REG VAL / ___ REG VAL VAL
                    Comparison(opcode, v1, v2, v3, (ushort)opcount);
                    
                    break;
                case OpCode.jmp:  // ADDR
                case OpCode.rjmp: // ADDR
                case OpCode.jeq:  // ADDR LHS RHS
                case OpCode.jne:  // ADDR LHS RHS
                case OpCode.rjeq: // ADDR LHS RHS
                case OpCode.rjne: // ADDR LHS RHS
                    Jump(opcode, v1, v2, v3, (ushort)opcount);
                    break;

                default:
                    return Interrupt.badInstruction;
            }
            return Interrupt.none;
        }

        // Fetches, Decomposes, then executes instruction
        // !!!Does not handle interrupt!!!
        public Interrupt Execute() {
            Interrupt interrupt = Interrupt.none;


            // - - - - - - - - - - - -
            // F E T C H- - - - - - -
            // - - - - - - - - - - -

            interrupt = Fetch(out Instruction instruction);
            if (interrupt != Interrupt.none) return interrupt;


            // - - - - - - - - - - - - -
            // D E C O M P O S E- - - -
            // - - - - - - - - - - - -

            interrupt = Decompose(
                ref instruction, 
                out OpCode opcode, out uint opcount,
                out ushort v1, out ushort v2, out ushort v3);
            if (interrupt != Interrupt.none) return interrupt;


            // - - - - - - - - - - - -
            // E X E C U T E- - - - -
            // - - - - - - - - - - -

            interrupt = Execute(
                opcode, opcount, 
                v1, v2, v3);
            return interrupt;
        }
        
        // Handles given interrupt if its valid
        // Returns true if interrupt is handled, otherwise false
        public bool HandleInterrupt(Interrupt i) {
            if ((int)i >= IX_IRR0 && (int)i <= IX_IRR7) { 
                Set(IX_PC, _reg[(int)i]);
                return true;
            }
            return false;
        }
        
        public static bool ValidRegister(uint ix) => ix < 32;
        static bool ToBool(ushort val) => val != 0;
        static ushort ToNum(bool val) => val ? (ushort)1 : (ushort)0;
        
        SetCallback _onSet = (x) => { };
    }
}
