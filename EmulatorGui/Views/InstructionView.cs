using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CpuEmulator.p16;
namespace EmulatorGui {
    class InstructionView {
        public InstructionView(
            uint address,
            CpuEmulator.Instruction instruction) {
            _address     = address;
            _instruction = instruction;
        }
        public static List<InstructionView> CreateViews(
            CpuEmulator.Memory memory,
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
                        out CpuEmulator.Instruction instruction);

                    // Create view
                    InstructionView view = new InstructionView(readPtr, instruction);
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
        public CpuEmulator.Instruction Instruction { 
            get => _instruction; 
            set => _instruction = value;
        }

        public override string ToString() {
            StringBuilder builder = new StringBuilder(40);
            OpCode opcode = EncoderDecoder.GetOpCode(ref _instruction);
            uint opct     = EncoderDecoder.GetOpCount(ref _instruction);
            
            builder.Append(_address.ToString("X4"));
            builder.Append(' ');
            builder.Append(opcode.ToString().ToUpper().PadRight(7, ' '));

            if (opct > 0) {
                builder.Append(' ');
                builder.Append(modePrefix[(int)EncoderDecoder.GetMode1(ref _instruction)]);
                builder.Append(_instruction.Operand1.ToString("X4"));
            }
            if (opct > 1) {
                builder.Append("  ");
                builder.Append(modePrefix[(int)EncoderDecoder.GetMode2(ref _instruction)]);
                builder.Append(_instruction.Operand2.ToString("X4"));
            }
            if (opct > 2) { 
                builder.Append("  ");
                builder.Append(modePrefix[(int)EncoderDecoder.GetMode3(ref _instruction)]);
                builder.Append(_instruction.Operand3.ToString("X4"));
            }
            return builder.ToString();
        }

        uint _address;
        CpuEmulator.Instruction _instruction;

        string[] modePrefix = { 
            "imm/",    // IMMEDIATE
            "reg/",    // REGISTER
            "dir/",    // DIRECT
            "rdr/",    // REGISTER DIRECT
        };
    }
}
