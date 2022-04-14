using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CpuEmulator;
using CpuEmulator.p16;
namespace EmulatorGui {
    public partial class InstructionEditForm : Form {
        Memory      _memory;
        uint        _address;
        Instruction _instruction;
        List<ComboBox> _cbModes;
        List<ComboBox> _cbFormats;
        List<TextBox> _tbOperands;

        public InstructionEditForm(Memory memory, uint address) {
            InitializeComponent();
            _memory = memory;
            _address = address;

            _cbModes = new List<ComboBox>   { cbMode1, cbMode2, cbMode3 };
            _cbFormats = new List<ComboBox> { cbFormat1, cbFormat2, cbFormat3 };
            _tbOperands = new List<TextBox> { tbOperand1, tbOperand2, tbOperand3 };

            //
            // FORMATS
            List<NumberFormat> formats = new List<NumberFormat> { 
                BinaryFormat.Instance16,
                HexadecimalFormat.Instance16,
                DecimalFormat.Instance,
            };
            foreach (ComboBox cbFormat in _cbFormats) {
                cbFormat.DataSource    = new List<NumberFormat>(formats);
                cbFormat.SelectedIndex = 1;
            }

            //
            // MODES
            foreach (ComboBox cbMode in _cbModes) {
                cbMode.DataSource = Enum.GetValues(typeof(Mode));
                cbMode.SelectedIndex = 0;
            }

            //
            // INSTRUCTIONS
            cbInstruction.DataSource = Enum.GetValues(typeof(OpCode));
            cbInstruction.SelectedIndex = 0;
        }
        public Memory Memory { 
            get => _memory;
            set {
                _memory = value;
            }
        }
        public uint Address { 
            get => _address;
            set {
                _address = value;
            }
        }
        public void Set(Memory memory, uint address) {
            _memory  = memory;
            _address = address;
            Decode();
            Present();
        }

        void Decode() =>
            EncoderDecoder.Decode(_memory, _address, out _instruction);
        
        void Present() {
            OpCode code = EncoderDecoder.GetOpCode(ref _instruction);
            uint count  = EncoderDecoder.GetOpCount(ref _instruction);
            cbInstruction.SelectedItem = code;
            numOpCount.Value           = count;

            NumberFormat format1 = cbFormat1.SelectedItem as NumberFormat;
            NumberFormat format2 = cbFormat2.SelectedItem as NumberFormat;
            NumberFormat format3 = cbFormat3.SelectedItem as NumberFormat;

            cbMode1.SelectedItem = EncoderDecoder.GetMode1(ref _instruction);
            tbOperand1.Text = format1.To(_instruction.Operand1);
            cbMode2.SelectedItem = EncoderDecoder.GetMode2(ref _instruction);
            tbOperand2.Text = format2.To(_instruction.Operand2);
            cbMode3.SelectedItem = EncoderDecoder.GetMode3(ref _instruction);
            tbOperand3.Text = format3.To(_instruction.Operand3);
        }

        bool Encode() {
            OpCode code = (OpCode)cbInstruction.SelectedItem;
            uint count = (uint)numOpCount.Value;

            Instruction ins = new Instruction();
            bool success = true;
            ushort op1 = 0, op2 = 0, op3 = 0;

            if (count > 0) success &= GetOperand(0, out op1);
            if (count > 1) success &= GetOperand(1, out op2);
            if (count > 2) success &= GetOperand(2, out op3);

            // Return if unparsable operands given
            if (Assert.IfFalse(success)) return false;

            if (count == 0)
                ins = EncoderDecoder.Custom(code);
            else if (count == 1)
                ins = EncoderDecoder.Custom(
                    code,
                    (Mode)cbMode1.SelectedItem, op1);
            else if (count == 2)
                ins = EncoderDecoder.Custom(
                    code,
                    (Mode)cbMode1.SelectedItem, op1,
                    (Mode)cbMode2.SelectedItem, op2);
            else if (count == 3)
                ins = EncoderDecoder.Custom(
                    code,
                    (Mode)cbMode1.SelectedItem, op1,
                    (Mode)cbMode2.SelectedItem, op2,
                    (Mode)cbMode3.SelectedItem, op3);
            else {
                Assert.IfFalse(false);
                return false;
            }
            EncoderDecoder.Encode(
                _memory,
                _address,
                ref ins);
            return true;
        }
        void PresentOperand(int i, Mode mode, ushort value) {
            if (i < 0 || i > 3) return;
            _cbModes[i].SelectedItem = mode;
        }
        private void numOpCount_ValueChanged(object sender, EventArgs e) {
            NumericUpDown num = (sender as NumericUpDown)!;
            int i = 0;
            for (i = 0; i < num.Value; i++) {
                _cbFormats[i].Enabled = true;
                _cbModes[i].Enabled = true;
                _tbOperands[i].Enabled = true;
            }
            for (; i < 3; i++) {
                _cbFormats[i].Enabled = false;
                _cbModes[i].Enabled = false;
                _tbOperands[i].Enabled = false;
            }
        }

        // - - - - - - - - - - -
        // H E L P E R- - - - -
        // - - - - - - - - - -

        bool GetOperand(int i, out ushort value) {
            value = 0;
            if (i < 0 || i > 3) return false;

            NumberFormat format = (_cbFormats[i].SelectedItem as NumberFormat)!;
            if (format.From(_tbOperands[i].Text, out uint parse)) {
                value = (ushort)parse;
                return true;
            }
            else {
                Assert.IfFalse(false);
                return false;
            }
        }

        private void btnApply_Click(object sender, EventArgs e) {
            if(Encode())
                Hide();
        }
    }
}
