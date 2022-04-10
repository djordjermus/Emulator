namespace EmulatorGui
{
    partial class InstructionViewForm
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
            this.lbInstructions = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lbInstructions
            // 
            this.lbInstructions.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbInstructions.FormattingEnabled = true;
            this.lbInstructions.ItemHeight = 14;
            this.lbInstructions.Location = new System.Drawing.Point(12, 12);
            this.lbInstructions.Name = "lbInstructions";
            this.lbInstructions.Size = new System.Drawing.Size(300, 452);
            this.lbInstructions.TabIndex = 6;
            // 
            // InstructionViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 476);
            this.Controls.Add(this.lbInstructions);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InstructionViewForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Pregled instrukcija";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InstructionViewForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox lbInstructions;
    }
}