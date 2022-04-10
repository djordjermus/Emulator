using CpuEmulator.p16;
namespace EmulatorGui {
    public partial class MainForm : Form {
        const int memViewCount = 32;
        Processor _processor;
        ViewEditForm _valueEditor;

        public MainForm() {
            DoubleBuffered = true;
            InitializeComponent();
            _valueEditor   = new();
            _processor     = new Processor(new CpuEmulator.Memory(8192));
            EncodeInstructions(_processor.Memory);

            InitializeRegisterView();
            InitializeMemoryView(0, memViewCount);
            InitializeInstructionView();
            RefreshCapacityLabel();
            UpdateStepButton();
        }


        // - - - - - - - - - - - - - - - - - - - -
        // R E G I S T E R   V I E W- - - - - - -
        // - - - - - - - - - - - - - - - - - - -

        private void InitializeRegisterView() {
            List<RegisterView> views = new List<RegisterView>(32);

            for (int i = 0; i < 32; i++)
                views.Add(new RegisterView(_processor, (uint)i));

            lbRegisters.DataSource = views;
        }
        private void lbRegisters_DoubleClick(object sender, EventArgs e) {
            _valueEditor.View = (lbRegisters.SelectedItem as IValueView)!;
            _valueEditor.ShowDialog();
            RefreshListBox(lbRegisters);
        }
        
        // - - - - - - - - - - - - - - - - - - - -
        // M E M O R Y   V I E W- - - - - - - - -
        // - - - - - - - - - - - - - - - - - - -

        private void InitializeMemoryView(int startAddress, int count) {
            List<MemoryView> views = new List<MemoryView>(count);
            for (int i = 0; i < count; i++)
                views.Add(new MemoryView(_processor.Memory, (uint)(startAddress + i * 2)));
            lbMemory.DataSource = views;
        }
        private void RefreshCapacityLabel() {
            lbCapacity.Text = 
                "Kapacitet:\n  " + 
                  _processor.Memory.Capacity.ToString() + " bajtova";
        }
        private static void RefreshListBox(ListBox listBox) {
            
            listBox.BeginUpdate();
            object list = listBox.DataSource;
            listBox.DataSource = null;
            listBox.DataSource = list;
            listBox.EndUpdate();
        }
        private void SearchMemory(int startAddress) {
            List<MemoryView> views = lbMemory.DataSource! as List<MemoryView>;
            for (int i = 0; i < views.Count; i++)
                views[i].Address = (uint)(startAddress + i * 2);
            RefreshListBox(lbMemory);
        }
        private void btnClear_Click(object sender, EventArgs e) {
            if (!Utility.FromHex(tbClearFrom.Text, out ushort from)) {
                System.Media.SystemSounds.Hand.Play();
                return;
            }
            if (!Utility.FromHex(tbClearTo.Text, out ushort to)) {
                System.Media.SystemSounds.Hand.Play();
                return;
            }
            if (!Utility.FromHex(tbClearValue.Text, out ushort value)) {
                System.Media.SystemSounds.Hand.Play();
                return;
            }
            if (!_processor.Memory.CanAccess(from)) {
                System.Media.SystemSounds.Hand.Play();
                return;
            }

            while (from < to)
                if (_processor.Memory.Write(from++, (byte)value) == 0) break;
            MemoryChanged();
        }
        private void btnCopy_Click(object sender, EventArgs e) {
            CpuEmulator.Memory memory = _processor.Memory;

            if (!Utility.FromHex(tbSrcFrom.Text, out ushort from)) {
                System.Media.SystemSounds.Hand.Play();
                return;
            }
            if (!Utility.FromHex(tbSrcTo.Text, out ushort to)) {
                System.Media.SystemSounds.Hand.Play();
                return;
            }
            if (!Utility.FromHex(tbDst.Text, out ushort dst)) {
                System.Media.SystemSounds.Hand.Play();
                return;
            }
            if (!memory.CanAccess(from) || !memory.CanAccess((uint)(to - 1))) {
                System.Media.SystemSounds.Hand.Play();
                return;
            }

            while (from < to) {
                memory.Read(from++, out byte val);
                if (memory.Write(dst++, val) == 0) break;
            }

            MemoryChanged();
        }
        private void btnResize_Click(object sender, EventArgs e) {
            if (!uint.TryParse(tbResize.Text, out uint newSize)) {
                System.Media.SystemSounds.Hand.Play();
                return;
            }
            _processor.Memory.Resize(newSize);

            RefreshCapacityLabel();
            MemoryChanged();
        }
        private void btnSearch_Click(object sender, EventArgs e) {
            if (!Utility.FromHex(tbSearch.Text, out ushort address)) {
                System.Media.SystemSounds.Hand.Play();
                return;
            }
            SearchMemory(address);
        }
        private void lbMemory_DoubleClick(object sender, EventArgs e) {
            _valueEditor.View = (lbMemory.SelectedItem as IValueView)!;
            _valueEditor.ShowDialog();
            MemoryChanged();
        }

        // - - - - - - - - - - - - - - - - - - - -
        // I N S T R U C T I O N   V I E V- - - -
        // - - - - - - - - - - - - - - - - - - -

        private void InitializeInstructionView() {
            List<InstructionView> views = new List<InstructionView>(32);
            _processor.Get(Processor.IX_PC, out ushort addr);
            for (int i = 0; i < 32; i++) {
                uint width = EncoderDecoder.Decode(
                    _processor.Memory, 
                    addr, 
                    out CpuEmulator.Instruction ins);
            
                views.Add(new InstructionView(addr, ins));

                addr += (ushort)width;
            }
            lbInstructions.DataSource = views;
        }
        private void RebuildInstructionView(ushort startAddr) {
            List<InstructionView> views =
                (lbInstructions.DataSource! as List<InstructionView>)!;

            ushort addr = startAddr;
            for (int i = 0; i < views.Count; i++) {
                uint width = EncoderDecoder.Decode(
                    _processor.Memory,
                    addr,
                    out CpuEmulator.Instruction ins);

                views[i].Address     = addr;
                views[i].Instruction = ins;

                addr += (ushort)width;
            }
            RefreshListBox(lbInstructions);
        }
        private void RebuildInstructionView() {
            _processor.Get(Processor.IX_PC, out ushort pc);
            RebuildInstructionView(pc);
        }
        private void SelectPCInstruction() {
            _processor.Get(Processor.IX_PC, out ushort pc);
            List<InstructionView> views = 
                (lbInstructions.DataSource! as List<InstructionView>)!;

            // Find next instruction
            for (int i = 0; i < views.Count; i++) {
                if (views[i].Address == pc) {
                    lbInstructions.SelectedIndex = i;
                    return;
                }
            }

            // If not found, rebuild view
            RebuildInstructionView();
            lbInstructions.SelectedIndex = 0;
        }
        private void UpdateStepButton() {
            _processor.Get(Processor.IX_PC, out ushort pc);
            btnStep.Text = "> " + pc.ToString("X4") + " <";
        }
        private void btnStep_Click(object sender, EventArgs e) {
            _processor.HandleInterrupt(_processor.Execute());
            UpdateStepButton();
            RefreshListBox(lbRegisters);
            RefreshListBox(lbMemory);
            RefreshListBox(lbInstructions);
            SelectPCInstruction();
        }


        private void MemoryChanged() {
            RefreshListBox(lbMemory);
            RebuildInstructionView();
            RefreshListBox(lbInstructions);
            SelectPCInstruction();
        }

        static void EncodeInstructions(CpuEmulator.Memory memory) {
            CpuEmulator.Instruction[] instructions 
                = new CpuEmulator.Instruction[64];
            ushort a = 12;
            ushort b = 5;

            instructions[0] = EncoderDecoder.Load(
                Mode.immediate, 0,
                Mode.immediate, a);
            instructions[1] = EncoderDecoder.Load(
                Mode.immediate, 1,
                Mode.immediate, b);

            instructions[2] = EncoderDecoder.Add(
                Mode.immediate, 2,
                Mode.register, 0,
                Mode.register, 1);
            instructions[3] = EncoderDecoder.Subtract(
                Mode.immediate, 3,
                Mode.register, 0,
                Mode.register, 1);
            instructions[4] = EncoderDecoder.Multiply(
                Mode.immediate, 4,
                Mode.register, 0,
                Mode.register, 1);
            instructions[5] = EncoderDecoder.Divide(
                Mode.immediate, 5,
                Mode.register, 0,
                Mode.register, 1);

            instructions[6] = EncoderDecoder.BitwiseAnd(
                Mode.immediate, 6,
                Mode.register, 0,
                Mode.register, 1);
            instructions[7] = EncoderDecoder.BitwiseOr(
                Mode.immediate, 7,
                Mode.register, 0,
                Mode.register, 1);
            instructions[8] = EncoderDecoder.BitwiseXor(
                Mode.immediate, 8,
                Mode.register, 0,
                Mode.register, 1);
            instructions[9] = EncoderDecoder.Invert(
                Mode.immediate, 9,
                Mode.register, 0);

            for (int i = 0; i < 8; i++)
                instructions[10 + i] = EncoderDecoder.Store(
                    Mode.immediate, (ushort)(1024 + 2 * i),
                    Mode.register, (ushort)(2 + i));

            instructions[18] = EncoderDecoder.Jump(
                Mode.immediate, 0);

            // Enocode instructions 
            uint encAddr = 0;
            for (int i = 0; i < instructions.Length; i++)
                encAddr += EncoderDecoder.Encode(memory, encAddr, ref instructions[i]);
        }
    }
}