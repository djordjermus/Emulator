using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CpuEmulator.p16;
namespace EmulatorGui {
    public partial class InstructionViewForm : Form {
        Processor         _processor;

        public InstructionViewForm(Processor processor) {
            _processor = processor;
            InitializeComponent();
            RefreshValues();
        }
        public void RefreshValues() {
            _processor.Get(Processor.IX_PC, out ushort addr);
            lbInstructions.DataSource = 
                InstructionView.CreateViews(_processor.Memory, addr, 32);
        }

        private void InstructionViewForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
