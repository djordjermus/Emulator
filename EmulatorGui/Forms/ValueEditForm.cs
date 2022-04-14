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
    public partial class ValueEditForm : Form {
        static NumberFormat bin = BinaryFormat.Instance16;
        static NumberFormat hex = HexadecimalFormat.Instance16;
        static NumberFormat dec = DecimalFormat.Instance;

        IValueView? _view;
        public ValueEditForm() {
            InitializeComponent();
            cbBase.DataSource = new List<NumberFormat> { bin, hex, dec };
            cbBase.SelectedIndex = 1;
        }
        public IValueView View {
            get => _view!; 
            set {
                _view = value;
                PresentView();
            }
        }

        private void btnSet_Click(object sender, EventArgs e) {
            NumberFormat? format = cbBase.SelectedItem as NumberFormat;
            if (Assert.IfFalse(format != null)) 
                return;
                        
            if (format!.From(tbValue.Text, out uint value)) {
                _view!.Set((ushort)value);
                Hide();
            }
            else {
                Assert.IfFalse(false);
            }
        }
        void PresentView() {
            NumberFormat? format = cbBase.SelectedItem as NumberFormat;
            if (Assert.IfFalse(format != null))
                return;
            tbValue.Text = format!.To(_view!.Get());
        }
        private void ViewEditForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
