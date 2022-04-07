namespace EmulatorGui
{
    public partial class MainForm : Form {
        RegisterViewForm regForm;
        MemoryViewForm   memForm;
        InstructionViewForm insForm;
        public MainForm() {
            InitializeComponent();
            regForm = new RegisterViewForm();
            memForm = new MemoryViewForm();
            insForm = new InstructionViewForm();
        }

        private void registriToolStripMenuItem_Click(object sender, EventArgs e) {
            ToggleRegisterForm();
        }
        private void memorijaToolStripMenuItem_Click(object sender, EventArgs e) {
            ToggleMemoryForm();
        }
        private void instrukcijeToolStripMenuItem_Click(object sender, EventArgs e) {
            ToggleInstructionForm();
        }



        private void ToggleRegisterForm() =>
            regForm.Visible = !regForm.Visible;
        private void ToggleMemoryForm() =>
            memForm.Visible = !memForm.Visible;
        private void ToggleInstructionForm() =>
            insForm.Visible = !insForm.Visible;
    }
}