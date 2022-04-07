using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmulatorGui
{
    public partial class InstructionViewForm : Form
    {
        public InstructionViewForm() {
            InitializeComponent();
            for (int i = 0; i < 256; i++) 
                lbInstructions.Items.Add("0000: STORELB h0000 h0000 h0000");
        }
    }
}
