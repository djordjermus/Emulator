using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpuEmulator.p16 {
    public partial class Processor {

        public Processor(Memory memory) {
            // Link memory
            Memory        = memory;

            // Enable interrupts
            SetFlag(IX_IF, true);
        }
        public Memory Memory { get; set; }


        // - - - - - - - - - - - - - - - - -
        // R E L E V A N T   C O D E- - - -
        // - - - - - - - - - - - - - - - -

        // Fetches next instruction, advances PC
        // !!!Does not handle interrupt!!!
        public Interrupt Fetch(out Instruction instruction) {
            instruction = new Instruction();

            // READ INSTRUCTION
            ushort len = (ushort)instruction.Decode(Memory, _reg[IX_PC]);

            // FAILIURE TO READ INSTRUCTION
            if (len != (2 + instruction.OpCount * 2))
                return Interrupt.badPc;

            // MOVE PC
            Set(IX_PC, (ushort)(_reg[IX_PC] + len));

            return Interrupt.none;
        }

        // Evaluates single operand
        // !!!Does not handle interrupt!!!
        public Interrupt Evaluate(Mode mode, ushort op, out ushort value, uint opix = 0) {
            value = 0;

            if (mode == Mode.immediate) {
                // BLIT VALUE
                value = op;

                // NO INTERRUPT
                return Interrupt.none;
            }
            if (mode == Mode.register) {
                // VALIDATE REGISTER
                if (!ValidRegister(op)) return Interrupt.badRegister;

                // READ REGISTER
                value = _reg[op];
                
                // NO INTERRUPT
                return Interrupt.none;
            }

            // CALCULATE INDEX
            ushort index = 0;
            if (opix < 4)
                Get(opix + IX_IXR0, out index);

            if (mode == Mode.direct) {
                uint addr = (uint)(op + index);

                // VALIDATE ADDRESS
                if (!Memory.CanAccess(addr, 2)) return Interrupt.badAddress;

                // READ MEMORY
                value = Memory[addr];

                // NO INTERRUPT
                return Interrupt.none;
            }
            if (mode == Mode.registerDirect) {
                // VALIDATE REGISTER
                if (!ValidRegister(op)) return Interrupt.badRegister;

                // READ REGISTER
                uint addr = (uint)(_reg[op] + index);

                // VALIDATE ADDRESS
                if (!Memory.CanAccess(addr, 2)) return Interrupt.badAddress;

                // READ MEMORY
                value = Memory[addr];

                return Interrupt.none;
            }
            return Interrupt.badInstruction;
        }

        // Decomposes instruction and evaluates its operands
        // !!!Does not handle interrupt!!!
        public Interrupt Evaluate(
            ref Instruction instruction,
            out ushort value1, out ushort value2, out ushort value3) {

            Interrupt[] i = new Interrupt[3] { Interrupt.none, Interrupt.none, Interrupt.none };

            if (instruction.OpCount > 0)
                i[0] = Evaluate(
                    instruction.Mode1,
                    instruction.Operand1, out value1, 0);
            else value1 = 0;
            if (instruction.OpCount > 1)
                i[1] = Evaluate(
                    instruction.Mode2,
                    instruction.Operand2, out value2, 1);
            else value2 = 0;
            if (instruction.OpCount > 2)
                i[2] = Evaluate(
                    instruction.Mode3,
                    instruction.Operand3, out value3, 2);
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
            ref Instruction instruction) {

            OpCode opcode = instruction.Operation;
            uint opcount = instruction.OpCount;

            Interrupt interrupt = Evaluate(
                ref instruction,
                out ushort v1, out ushort v2, out ushort v3);
            if (interrupt != Interrupt.none) return interrupt;
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
                    return OpLoad(opcode, v1, v2);

                // LOAD ADR VAL
                case OpCode.store:
                case OpCode.storehb:
                case OpCode.storelb:
                    return OpStore(opcode, v1, v2);

                // PUSH VAL
                case OpCode.push:
                case OpCode.pushhb:
                case OpCode.pushlb:
                    return OpPush(opcode, v1);

                // POP REG
                case OpCode.pop:
                case OpCode.popub:
                case OpCode.popsb:
                    return OpPop(opcode, v1);

                // - - - - - - - - - - - - - - - - - - -
                // A R I T H M E T I C- - - - - - - - -
                // - - - - - - - - - - - - - - - - - -

                case OpCode.add:
                case OpCode.sub:
                case OpCode.mul:
                case OpCode.div:
                    // REG VAL / REG VAL VAL
                    return OpArithmetic(opcode, v1, v2, v3, (ushort)opcount);

                // - - - - - - - - - - - - - 
                // B I T W I S E- - - - - - 
                // - - - - - - - - - - - - 

                case OpCode.band:
                case OpCode.bor:
                case OpCode.bxor:
                case OpCode.lsl:
                case OpCode.lsr:
                case OpCode.binv:
                    // REG VAL / REG VAL VAL
                    return OpBitwise(opcode, v1, v2, v3, (ushort)opcount);

                // - - - - - - - - - - - - - 
                // L O G I C A L- - - - - - 
                // - - - - - - - - - - - - 

                case OpCode.and:
                case OpCode.or:
                case OpCode.xor:
                case OpCode.not:
                    return OpLogical(opcode, v1, v2, v3, (ushort)opcount);

                // - - - - - - - - - - - - - - - -
                // C O M P A R I S O N- - - - - - 
                // - - - - - - - - - - - - - - -

                case OpCode.eq:
                case OpCode.neq:
                case OpCode.ugt:
                case OpCode.ult:
                case OpCode.sgt:
                case OpCode.slt:
                    // REG VAL / REG VAL VAL
                    return OpComparison(opcode, v1, v2, v3, (ushort)opcount);

                    // VAL
                case OpCode.tst:
                    if (opcount != 1) return Interrupt.badInstruction;
                    OpTest(v1);
                    return Interrupt.none;

                case OpCode.jmp:  // ADDR
                case OpCode.jeq:  // ADDR LHS RHS
                case OpCode.jne:  // ADDR LHS RHS
                case OpCode.rjmp: // ADDR
                case OpCode.rjeq: // ADDR LHS RHS
                case OpCode.rjne: // ADDR LHS RHS
                    return OpJump(opcode, v1, v2, v3, (ushort)opcount);

                default:
                    return Interrupt.badInstruction;
            }
        }

        // Fetches, then executes instruction
        // !!!Does not handle interrupt!!!
        public Interrupt Execute() {

            // - - - - - - - - - - - -
            // F E T C H- - - - - - -
            // - - - - - - - - - - -

            Interrupt interrupt = Fetch(out Instruction instruction);
            if (interrupt != Interrupt.none) return interrupt;

            // - - - - - - - - - - - -
            // E X E C U T E- - - - -
            // - - - - - - - - - - -

            interrupt = Execute(ref instruction);
            return interrupt;
        }

        // Fetches, then executes instruction
        // !!!Handles interrupt!!!
        public Interrupt HandledExecute() {
            Interrupt interrupt = Execute();
            HandleInterrupt(interrupt);
            return interrupt;
        }
        
        // Handles given interrupt if its valid
        // Returns true if interrupt is handled, otherwise false
        public bool HandleInterrupt(Interrupt i) {
            
            if ((int)i >= IX_IRR0 && (int)i <= IX_IRR7 && GetFlag(IX_IF)) {
                ushort new_pc = _reg[(int)i];

                if(new_pc != 0)
                    Set(IX_PC, new_pc);

                return true;
            }
            return false;
        }

        public static bool ValidRegister(uint ix) => ix < 32;
        static bool ToBool(ushort val) => val != 0;
        static ushort ToNum(bool val) => val ? (ushort)1 : (ushort)0;
    }
}
