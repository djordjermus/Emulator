using CpuEmulator.p16;
namespace EmulatorGui {
    public partial class MainForm : Form {
        const int           _memViewCount = 32;
        bool                _executing    = false;
        bool                _requestStop  = false;
        Processor           _processor;
        ValueEditForm       _valueEditor;
        InstructionEditForm _instructionEditor;
        Thread              _executionThread;
        OpenFileDialog      _load = new OpenFileDialog();
        SaveFileDialog      _save = new SaveFileDialog();
        public MainForm() {
            DoubleBuffered = true;
            InitializeComponent();
            _processor         = new Processor(new CpuEmulator.Memory(8192));
            _valueEditor       = new();
            _instructionEditor = new(_processor.Memory, 0u);
            _executionThread   = new Thread(ExecuteUntilThreadFunct);
            
            // Initialize views
            InitializeRegisterView();
            InitializeMemoryView(0, _memViewCount);
            InitializeInstructionView();
            RefreshCapacityLabel();

            // Subscribe to processor
            _processor.OnExecute += RefreshDisplay;

            UpdateStepButton();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (_executionThread != null && _executionThread.ThreadState == ThreadState.Running) { 
                _requestStop = true;
                _executionThread.Join();
            }
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
            if (Assert.IfFalse(!_executing, _reasonExecuting)) return;

            _valueEditor.View = (lbRegisters.SelectedItem as IValueView)!;
            _valueEditor.ShowDialog();
            RefreshListBox(lbRegisters);
            UpdateStepButton();
            SelectPCInstruction();
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
            NumberFormat format       = HexadecimalFormat.Instance16;
            CpuEmulator.Memory memory = _processor.Memory;
            if (Assert.IfFalse(
                !_executing,
                _reasonExecuting)) return;

            if (Assert.IfFalse(
                format.From(tbClearFrom.Text, out uint from),
                _reasonAddrNotValid))
                return;

            if (Assert.IfFalse(
                format.From(tbClearTo.Text, out uint to),
                _reasonAddrNotValid))
                return;

            if (Assert.IfFalse(
                format.From(tbClearValue.Text, out uint value),
                _reasonClearValueNotValid))
                return;

            if (Assert.IfFalse(
                memory.CanAccess(from) && (from < to),
                _reasonAddrRangeNotValid))
                return;

            while (from < to)
                if (memory.Write(from++, (byte)value) == 0) break;

            MemoryChanged();
        }
        private void btnCopy_Click(object sender, EventArgs e) {
            NumberFormat format = HexadecimalFormat.Instance32;
            CpuEmulator.Memory memory = _processor.Memory;

            if (Assert.IfFalse(
                !_executing, 
                _reasonExecuting)) return;

            if (Assert.IfFalse(
                format.From(tbSrcFrom.Text, out uint from),
                _reasonAddrNotValid))
                return;
            
            if (Assert.IfFalse(
                format.From(tbSrcTo.Text, out uint to),
                _reasonAddrNotValid))
                return;
            
            if (Assert.IfFalse(
                format.From(tbDst.Text, out uint dst),
                _reasonAddrNotValid))
                return;
            
            if (Assert.IfFalse(
                memory.CanAccess(from) && memory.CanAccess(to - 1) && (from < to),
                _reasonAddrRangeNotValid))
                return;

            while (from < to) {
                memory.Read(from++, out byte val);
                if (memory.Write(dst++, val) == 0) break;
            }

            MemoryChanged();
        }
        private void btnResize_Click(object sender, EventArgs e) {
            if (Assert.IfFalse(
                !_executing, 
                _reasonExecuting)) return;
            if (Assert.IfFalse(
                uint.TryParse(tbResize.Text, out uint newSize),
                _reasonResizeNotValid)) return;

            _processor.Memory.Resize(newSize);
            RefreshCapacityLabel();
            MemoryChanged();
        }
        private void btnSearch_Click(object sender, EventArgs e) {
            NumberFormat format = HexadecimalFormat.Instance32;
            CpuEmulator.Memory memory = _processor.Memory;

            if (Assert.IfFalse(
                !_executing, 
                _reasonExecuting)) 
                return;
            if (Assert.IfFalse(
                format.From(tbSearch.Text, out uint address),
                _reasonAddrNotValid))
                return;

            SearchMemory((int)address);
        }
        private void lbMemory_DoubleClick(object sender, EventArgs e) {
            if (Assert.IfFalse(!_executing, _reasonExecuting)) return;
            _valueEditor.View = (lbMemory.SelectedItem as IValueView)!;
            _valueEditor.ShowDialog();
            MemoryChanged();
        }

        // - - - - - - - - - - - - - - - - - - - -
        // I N S T R U C T I O N   V I E W- - - -
        // - - - - - - - - - - - - - - - - - - -

        private void InitializeInstructionView() {
            List<InstructionView> views = new List<InstructionView>(32);
            _processor.Get(Processor.IX_PC, out ushort addr);
            for (int i = 0; i < 32; i++) {
                uint width = EncoderDecoder.Decode(
                    _processor.Memory, 
                    addr, 
                    out CpuEmulator.Instruction ins);
            
                views.Add(new InstructionView(_processor.Memory, addr));

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
            btnStep.Text = "[ " + pc.ToString("X4") + " ]";
        }
        private void ExecuteUntilThreadFunct() {
            NumberFormat format = HexadecimalFormat.Instance32;
            // Fetch end address, fail if invalid
            if (Assert.IfFalse(
                format.From(tbExecuteUntil.Text, out uint endAddr),
                _reasonAddrNotValid))
                return;

            // Fetch current program counter
            _processor.Get(Processor.IX_PC, out ushort pc);

            _requestStop = false;
            _executing   = true;

            // If pc is already at end address, do a single step forward
            if (pc == endAddr) 
                _processor.HandleInterrupt(_processor.Execute()); 
            
            // Enable Stop button + execute until end address is hit
            BeginInvoke(() => { LockOptions(); });
            while (!_requestStop) { 
                _processor.Get(Processor.IX_PC, out pc);
                if (pc == endAddr) break;

                _processor.HandleInterrupt(_processor.Execute());
            }

            // Mark end of execution
            _requestStop = false;
            _executing   = false;
            BeginInvoke(() => { UnlockOptions(); });
        }
        private void MemoryChanged() {
            RefreshListBox(lbMemory);
            RebuildInstructionView();
            RefreshListBox(lbInstructions);
            SelectPCInstruction();
        }
        private void RefreshDisplay() {
            if (_executing) return;

            UpdateStepButton();
            RefreshListBox(lbRegisters);
            RefreshListBox(lbMemory);
            RefreshListBox(lbInstructions);
            SelectPCInstruction();
        }
        private void lbInstructions_DoubleClick(object sender, EventArgs e) {
            if (Assert.IfFalse(!_executing, _reasonExecuting)) return;
            InstructionView view = (lbInstructions.SelectedItem as InstructionView)!;
            _instructionEditor.Set(view.Memory, view.Address);
            _instructionEditor.ShowDialog();
            MemoryChanged();
        }

        // - - - - - - - - - - - -
        // F I L E S- - - - - - -
        // - - - - - - - - - - -

        void SaveToFile() {
            string path = _save.FileName;
            try {
                using (FileStream file = File.OpenWrite(path)) {
                    using (BinaryWriter bw = new BinaryWriter(file)) {
                        bw.Write(_processor.Memory.Data);
                    }
                }
            }
            catch (Exception e) {
                Assert.IfFalse(false);
                MessageBox.Show(e.Message, "Greška");
                return;
            }
            MemoryChanged();
        }
        void LoadFromFile() {
            string path = _load.FileName;

            try {
                using (FileStream file = File.OpenRead(path)) {
                    using (BinaryReader br = new BinaryReader(file)) { 
                        if (_processor.Memory.Capacity < file.Length)
                            _processor.Memory.Resize((uint)file.Length);

                        uint i = 0;
                        while (file.Position < file.Length)
                            _processor.Memory.Write(i++, br.ReadByte());
                    }
                }
            }
            catch (Exception e) {
                Assert.IfFalse(false);
                MessageBox.Show(e.Message, "Greška");
                return;
            }
            MemoryChanged();
        }

        private void btnLoadClick(object sender, EventArgs e) {
            if (Assert.IfFalse(!_executing, _reasonExecuting)) return;

            _load.Filter = "Binarni fajlovi|*.bin";
            if (_load.ShowDialog() != DialogResult.OK)     return;
            if (Assert.IfFalse(_load.CheckFileExists)) return;

            msReload.Enabled = true;
            msSave.Enabled   = true;

            _save.FileName = _load.FileName;
            Text           = _load.FileName;

            LoadFromFile();
        }
        private void btnSaveAsClick(object sender, EventArgs e) {
            if (Assert.IfFalse(!_executing, _reasonExecuting)) return;

            _save.Filter = "Binarni fajlovi|*.bin";
            if (_save.ShowDialog() != DialogResult.OK)     return;

            msReload.Enabled = true;
            msSave.Enabled   = true;
            
            _load.FileName = _save.FileName;
            Text           = _save.FileName;

            SaveToFile();
        }
        private void msSave_Click(object sender, EventArgs e) {
            if (Assert.IfFalse(!_executing, _reasonExecuting)) return;

            SaveToFile();
        }
        private void msReload_Click(object sender, EventArgs e) {
            if (Assert.IfFalse(!_executing, _reasonExecuting)) return;

            LoadFromFile();
        }

        // - - - - - - - - - - - - - - - - - - - -
        // C O N T R O L S- - - - - - - - - - - -
        // - - - - - - - - - - - - - - - - - - -

        private void LockOptions() {
            btnClear.Enabled        = false;
            btnCopy.Enabled         = false;
            btnResize.Enabled       = false;
            btnSearch.Enabled       = false;
            btnStep.Enabled         = false;
            btnExecuteUntil.Enabled = false;

            msLoad.Enabled          = false;
            msReload.Enabled        = false;
            msSaveAs.Enabled        = false;
            msSave.Enabled          = false;

            btnStopExec.Enabled     = true;
        }
        private void UnlockOptions() { 
            btnClear.Enabled        = true;
            btnCopy.Enabled         = true;
            btnResize.Enabled       = true;
            btnSearch.Enabled       = true;
            btnStep.Enabled         = true;
            btnExecuteUntil.Enabled = true;

            msLoad.Enabled          = true;
            msReload.Enabled        = _load.FileName != "";
            msSaveAs.Enabled          = true;
            msSave.Enabled        = _save.FileName != "";

            btnStopExec.Enabled     = false;
            RefreshDisplay();
        }
        
        private void btnStep_Click(object sender, EventArgs e) {
            if (Assert.IfFalse(!_executing)) return;
            _processor.HandleInterrupt(_processor.Execute());
            UpdateStepButton();
            RefreshListBox(lbRegisters);
            RefreshListBox(lbMemory);
            RefreshListBox(lbInstructions);
            SelectPCInstruction();
        }
        private void btnExecuteUntil_Click(object sender, EventArgs e) {
            if (Assert.IfFalse(!_executing)) return;
            
            _executionThread = new Thread(ExecuteUntilThreadFunct);
            _executionThread.Start();
        }
        private void btnStopExec_Click(object sender, EventArgs e) {  _requestStop = true; }

        Assert.Reason _reasonExecuting = new(
            "Greška", 
            "Operaciju nemoguće izvršiti dok se kod izvršava.");
        Assert.Reason _reasonAddrNotValid = new(
            "Greška",
            "Operaciju nemoguće izvršiti - Uneta adresa nije validna.");
        Assert.Reason _reasonResizeNotValid = new(
            "Greška",
            "Operaciju nemoguće izvršiti - Uneta veličina nije validna.");
        Assert.Reason _reasonAddrRangeNotValid = new(
            "Greška",
            "Operaciju nemoguće izvršiti - Unet opseg adresa nije validan.");
        Assert.Reason _reasonClearValueNotValid = new(
            "Greška",
            "Operaciju nemoguće izvršiti - Uneta vrednost nije validna.");
    }
}