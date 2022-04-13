namespace EmulatorGui
{
    partial class InstructionEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbInstruction = new System.Windows.Forms.ComboBox();
            this.numOpCount = new System.Windows.Forms.NumericUpDown();
            this.lbInstruction = new System.Windows.Forms.Label();
            this.cbFormat1 = new System.Windows.Forms.ComboBox();
            this.lbOperand1 = new System.Windows.Forms.Label();
            this.tbOperand1 = new System.Windows.Forms.TextBox();
            this.cbMode1 = new System.Windows.Forms.ComboBox();
            this.cbMode2 = new System.Windows.Forms.ComboBox();
            this.tbOperand2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFormat2 = new System.Windows.Forms.ComboBox();
            this.cbMode3 = new System.Windows.Forms.ComboBox();
            this.tbOperand3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFormat3 = new System.Windows.Forms.ComboBox();
            this.btnApply = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numOpCount)).BeginInit();
            this.SuspendLayout();
            // 
            // cbInstruction
            // 
            this.cbInstruction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInstruction.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbInstruction.FormattingEnabled = true;
            this.cbInstruction.Location = new System.Drawing.Point(12, 27);
            this.cbInstruction.Name = "cbInstruction";
            this.cbInstruction.Size = new System.Drawing.Size(140, 22);
            this.cbInstruction.TabIndex = 0;
            // 
            // numOpCount
            // 
            this.numOpCount.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numOpCount.Location = new System.Drawing.Point(154, 28);
            this.numOpCount.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numOpCount.Name = "numOpCount";
            this.numOpCount.Size = new System.Drawing.Size(28, 22);
            this.numOpCount.TabIndex = 1;
            this.numOpCount.ValueChanged += new System.EventHandler(this.numOpCount_ValueChanged);
            // 
            // lbInstruction
            // 
            this.lbInstruction.AutoSize = true;
            this.lbInstruction.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbInstruction.Location = new System.Drawing.Point(12, 9);
            this.lbInstruction.Name = "lbInstruction";
            this.lbInstruction.Size = new System.Drawing.Size(168, 14);
            this.lbInstruction.TabIndex = 2;
            this.lbInstruction.Text = "Instrukcija, #operanada";
            // 
            // cbFormat1
            // 
            this.cbFormat1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFormat1.Enabled = false;
            this.cbFormat1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbFormat1.FormattingEnabled = true;
            this.cbFormat1.Items.AddRange(new object[] {
            "bin",
            "hex",
            "dec"});
            this.cbFormat1.Location = new System.Drawing.Point(12, 108);
            this.cbFormat1.Name = "cbFormat1";
            this.cbFormat1.Size = new System.Drawing.Size(46, 22);
            this.cbFormat1.TabIndex = 3;
            // 
            // lbOperand1
            // 
            this.lbOperand1.AutoSize = true;
            this.lbOperand1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbOperand1.Location = new System.Drawing.Point(12, 61);
            this.lbOperand1.Name = "lbOperand1";
            this.lbOperand1.Size = new System.Drawing.Size(91, 14);
            this.lbOperand1.TabIndex = 4;
            this.lbOperand1.Text = "Prvi operand";
            // 
            // tbOperand1
            // 
            this.tbOperand1.Enabled = false;
            this.tbOperand1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbOperand1.Location = new System.Drawing.Point(64, 108);
            this.tbOperand1.MaxLength = 16;
            this.tbOperand1.Name = "tbOperand1";
            this.tbOperand1.Size = new System.Drawing.Size(118, 22);
            this.tbOperand1.TabIndex = 5;
            this.tbOperand1.Text = "0000000000000000";
            // 
            // cbMode1
            // 
            this.cbMode1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMode1.Enabled = false;
            this.cbMode1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbMode1.FormattingEnabled = true;
            this.cbMode1.Items.AddRange(new object[] {
            "Način adresiranja:",
            "Immediate",
            "Register",
            "Direct",
            "Register direct"});
            this.cbMode1.Location = new System.Drawing.Point(12, 79);
            this.cbMode1.Name = "cbMode1";
            this.cbMode1.Size = new System.Drawing.Size(170, 22);
            this.cbMode1.TabIndex = 7;
            // 
            // cbMode2
            // 
            this.cbMode2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMode2.Enabled = false;
            this.cbMode2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbMode2.FormattingEnabled = true;
            this.cbMode2.Items.AddRange(new object[] {
            "Način adresiranja:",
            "Immediate",
            "Register",
            "Direct",
            "Register direct"});
            this.cbMode2.Location = new System.Drawing.Point(12, 160);
            this.cbMode2.Name = "cbMode2";
            this.cbMode2.Size = new System.Drawing.Size(170, 22);
            this.cbMode2.TabIndex = 11;
            // 
            // tbOperand2
            // 
            this.tbOperand2.Enabled = false;
            this.tbOperand2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbOperand2.Location = new System.Drawing.Point(64, 189);
            this.tbOperand2.MaxLength = 16;
            this.tbOperand2.Name = "tbOperand2";
            this.tbOperand2.Size = new System.Drawing.Size(118, 22);
            this.tbOperand2.TabIndex = 10;
            this.tbOperand2.Text = "0000000000000000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 14);
            this.label1.TabIndex = 9;
            this.label1.Text = "Drugi operand";
            // 
            // cbFormat2
            // 
            this.cbFormat2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFormat2.Enabled = false;
            this.cbFormat2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbFormat2.FormattingEnabled = true;
            this.cbFormat2.Items.AddRange(new object[] {
            "bin",
            "hex",
            "dec"});
            this.cbFormat2.Location = new System.Drawing.Point(12, 189);
            this.cbFormat2.Name = "cbFormat2";
            this.cbFormat2.Size = new System.Drawing.Size(46, 22);
            this.cbFormat2.TabIndex = 8;
            // 
            // cbMode3
            // 
            this.cbMode3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMode3.Enabled = false;
            this.cbMode3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbMode3.FormattingEnabled = true;
            this.cbMode3.Items.AddRange(new object[] {
            "Način adresiranja:",
            "Immediate",
            "Register",
            "Direct",
            "Register direct"});
            this.cbMode3.Location = new System.Drawing.Point(12, 241);
            this.cbMode3.Name = "cbMode3";
            this.cbMode3.Size = new System.Drawing.Size(170, 22);
            this.cbMode3.TabIndex = 15;
            // 
            // tbOperand3
            // 
            this.tbOperand3.Enabled = false;
            this.tbOperand3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbOperand3.Location = new System.Drawing.Point(64, 270);
            this.tbOperand3.MaxLength = 16;
            this.tbOperand3.Name = "tbOperand3";
            this.tbOperand3.Size = new System.Drawing.Size(118, 22);
            this.tbOperand3.TabIndex = 14;
            this.tbOperand3.Text = "0000000000000000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 14);
            this.label2.TabIndex = 13;
            this.label2.Text = "Treći operand";
            // 
            // cbFormat3
            // 
            this.cbFormat3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFormat3.Enabled = false;
            this.cbFormat3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbFormat3.FormattingEnabled = true;
            this.cbFormat3.Items.AddRange(new object[] {
            "bin",
            "hex",
            "dec"});
            this.cbFormat3.Location = new System.Drawing.Point(12, 270);
            this.cbFormat3.Name = "cbFormat3";
            this.cbFormat3.Size = new System.Drawing.Size(46, 22);
            this.cbFormat3.TabIndex = 12;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(12, 326);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(170, 23);
            this.btnApply.TabIndex = 16;
            this.btnApply.Text = "Upiši";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // InstructionEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(194, 361);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.cbMode3);
            this.Controls.Add(this.tbOperand3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbFormat3);
            this.Controls.Add(this.cbMode2);
            this.Controls.Add(this.tbOperand2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbFormat2);
            this.Controls.Add(this.cbMode1);
            this.Controls.Add(this.tbOperand1);
            this.Controls.Add(this.lbOperand1);
            this.Controls.Add(this.cbFormat1);
            this.Controls.Add(this.lbInstruction);
            this.Controls.Add(this.numOpCount);
            this.Controls.Add(this.cbInstruction);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InstructionEditForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Izmeni instrukciju";
            ((System.ComponentModel.ISupportInitialize)(this.numOpCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox cbInstruction;
        private NumericUpDown numOpCount;
        private Label lbInstruction;
        private ComboBox cbFormat1;
        private Label lbOperand1;
        private TextBox tbOperand1;
        private ComboBox cbMode1;
        private ComboBox cbMode2;
        private TextBox tbOperand2;
        private Label label1;
        private ComboBox cbFormat2;
        private ComboBox cbMode3;
        private TextBox tbOperand3;
        private Label label2;
        private ComboBox cbFormat3;
        private Button btnApply;
    }
}