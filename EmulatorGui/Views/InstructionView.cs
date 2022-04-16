using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CpuEmulator;
using CpuEmulator.p16;
namespace EmulatorGui {
    class InstructionView {
        public InstructionView(
            Memory memory,
            uint address) {
            _memory = memory;
            _address     = address;
        }
        public static List<InstructionView> CreateViews(
            Memory memory,
            uint address, uint count) {

                // Create view list
                List<InstructionView> ret = new ((int)count);

                // Populate view list
                uint readPtr = address;
                for (int i = 0; i < count; i++) {

                    // Read instruction
                    uint readb = EncoderDecoder.Decode(
                        memory,
                        readPtr,
                        out Instruction instruction);

                    // Create view
                    InstructionView view = new InstructionView(memory, readPtr);
                    ret.Add(view);

                    // Progress memory pointer
                    readPtr += readb;
                }
            return ret;
        }

        public uint Address { 
            get => _address; 
            set => _address = value; 
        }
        public Instruction Instruction {
            get {
                EncoderDecoder.Decode(_memory, _address, out Instruction instr);
                return instr;
            }
            set {
                EncoderDecoder.Encode(_memory, _address, ref value);
            }
        }
        public Memory Memory {
            get => _memory;
            set => _memory = value;
        }
        public override string ToString() {
            EncoderDecoder.Decode(_memory, _address, out Instruction instr);

            StringBuilder builder = new StringBuilder(40);
            OpCode opcode = instr.Operation;
            uint opct     = instr.OpCount;
            
            builder.Append(_address.ToString("X4"));
            builder.Append(' ');
            builder.Append(opcode.ToString().ToUpper().PadRight(7, ' '));

            if (opct > 0) {
                builder.Append(' ');
                Mode mode = instr.Mode1;
                builder.Append(Utility.ModeToShortString(mode));
                builder.Append(' ');
                builder.Append(instr.Operand1.ToString("X4"));
            }
            if (opct > 1) {
                builder.Append("  ");
                Mode mode = instr.Mode2;
                builder.Append(Utility.ModeToShortString(mode));
                builder.Append(' ');
                builder.Append(instr.Operand2.ToString("X4"));
            }
            if (opct > 2) { 
                builder.Append("  ");
                Mode mode = instr.Mode3;
                builder.Append(Utility.ModeToShortString(mode));
                builder.Append(' ');
                builder.Append(instr.Operand3.ToString("X4"));
            }
            return builder.ToString();
        }
        
        Memory _memory;
        uint _address;
    }
}
