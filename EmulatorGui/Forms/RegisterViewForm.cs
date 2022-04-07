using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmulatorGui {
    public partial class RegisterViewForm : Form {
        public RegisterViewForm() {
            InitializeComponent();
            for (int i = 0; i < 32; i++) 
                lbRegisters.Items.Add("GPR0 b00000000 h00; b00000000 h00");
        }

        private void RegisterViewForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
