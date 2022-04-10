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
    public partial class ViewEditForm : Form {
        IValueView? _view;
        public ViewEditForm() {
            InitializeComponent();
            cbBase.SelectedIndex = 2;
        }
        public IValueView View {
            get => _view!; 
            set {
                _view = value;
                switch (cbBase.SelectedIndex) {
                    case 0:
                        tbValue.Text = Utility.ToBin(_view.Get());
                        break;
                    case 1:
                        tbValue.Text = _view.Get().ToString("X4");
                        break;
                    case 2:
                        tbValue.Text = _view.Get().ToString();
                        break;
                }
            }
        }

        private void btnSet_Click(object sender, EventArgs e) {
            ushort value = 0;
            switch (cbBase.SelectedIndex) {
                case 0:
                    if(Utility.FromBin(tbValue.Text, out value)) { 
                        _view!.Set(value);
                        Hide();
                    }
                    else
                        System.Media.SystemSounds.Hand.Play();
                    break;
                case 1:
                    if (Utility.FromHex(tbValue.Text, out value)) { 
                        _view!.Set(value);
                        Hide();
                    }
                    else
                        System.Media.SystemSounds.Hand.Play();
                    break;
                case 2:
                    if (ushort.TryParse(tbValue.Text, out value)) { 
                        _view!.Set(value);
                        Hide();
                    }
                    else
                        System.Media.SystemSounds.Hand.Play();
                    break;
            }
        }

        private void ViewEditForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
