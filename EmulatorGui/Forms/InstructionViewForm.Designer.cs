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
            this.msTools = new System.Windows.Forms.MenuStrip();
            this.fajlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.učitajToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.osvežiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sačuvajKaoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sačuvajToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izmeniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vrednostRegistraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pronadjiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pronađiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbLockToPc = new System.Windows.Forms.CheckBox();
            this.msTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbInstructions
            // 
            this.lbInstructions.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbInstructions.FormattingEnabled = true;
            this.lbInstructions.ItemHeight = 14;
            this.lbInstructions.Location = new System.Drawing.Point(12, 33);
            this.lbInstructions.Name = "lbInstructions";
            this.lbInstructions.Size = new System.Drawing.Size(260, 452);
            this.lbInstructions.TabIndex = 6;
            // 
            // msTools
            // 
            this.msTools.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.msTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fajlToolStripMenuItem,
            this.izmeniToolStripMenuItem,
            this.pronadjiToolStripMenuItem});
            this.msTools.Location = new System.Drawing.Point(0, 0);
            this.msTools.Name = "msTools";
            this.msTools.Size = new System.Drawing.Size(284, 24);
            this.msTools.TabIndex = 7;
            this.msTools.Text = "msTools";
            // 
            // fajlToolStripMenuItem
            // 
            this.fajlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.učitajToolStripMenuItem,
            this.osvežiToolStripMenuItem,
            this.sačuvajKaoToolStripMenuItem,
            this.sačuvajToolStripMenuItem});
            this.fajlToolStripMenuItem.Name = "fajlToolStripMenuItem";
            this.fajlToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.fajlToolStripMenuItem.Text = "Fajl";
            // 
            // učitajToolStripMenuItem
            // 
            this.učitajToolStripMenuItem.Name = "učitajToolStripMenuItem";
            this.učitajToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.učitajToolStripMenuItem.Text = "Učitaj iz fajla";
            // 
            // osvežiToolStripMenuItem
            // 
            this.osvežiToolStripMenuItem.Enabled = false;
            this.osvežiToolStripMenuItem.Name = "osvežiToolStripMenuItem";
            this.osvežiToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.osvežiToolStripMenuItem.Text = "Osveži";
            // 
            // sačuvajKaoToolStripMenuItem
            // 
            this.sačuvajKaoToolStripMenuItem.Name = "sačuvajKaoToolStripMenuItem";
            this.sačuvajKaoToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.sačuvajKaoToolStripMenuItem.Text = "Sačuvaj kao";
            // 
            // sačuvajToolStripMenuItem
            // 
            this.sačuvajToolStripMenuItem.Enabled = false;
            this.sačuvajToolStripMenuItem.Name = "sačuvajToolStripMenuItem";
            this.sačuvajToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.sačuvajToolStripMenuItem.Text = "Sačuvaj";
            // 
            // izmeniToolStripMenuItem
            // 
            this.izmeniToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vrednostRegistraToolStripMenuItem});
            this.izmeniToolStripMenuItem.Name = "izmeniToolStripMenuItem";
            this.izmeniToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.izmeniToolStripMenuItem.Text = "Izmeni";
            // 
            // vrednostRegistraToolStripMenuItem
            // 
            this.vrednostRegistraToolStripMenuItem.Name = "vrednostRegistraToolStripMenuItem";
            this.vrednostRegistraToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.vrednostRegistraToolStripMenuItem.Text = "Upiši instrukciju";
            // 
            // pronadjiToolStripMenuItem
            // 
            this.pronadjiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pronađiToolStripMenuItem});
            this.pronadjiToolStripMenuItem.Name = "pronadjiToolStripMenuItem";
            this.pronadjiToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.pronadjiToolStripMenuItem.Text = "Pregled";
            // 
            // pronađiToolStripMenuItem
            // 
            this.pronađiToolStripMenuItem.Name = "pronađiToolStripMenuItem";
            this.pronađiToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.pronađiToolStripMenuItem.Text = "Pronađi";
            // 
            // cbLockToPc
            // 
            this.cbLockToPc.AutoSize = true;
            this.cbLockToPc.Checked = true;
            this.cbLockToPc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbLockToPc.Location = new System.Drawing.Point(12, 491);
            this.cbLockToPc.Name = "cbLockToPc";
            this.cbLockToPc.Size = new System.Drawing.Size(173, 18);
            this.cbLockToPc.TabIndex = 8;
            this.cbLockToPc.Text = "Prati program counter";
            this.cbLockToPc.UseVisualStyleBackColor = true;
            // 
            // InstructionViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 519);
            this.Controls.Add(this.cbLockToPc);
            this.Controls.Add(this.lbInstructions);
            this.Controls.Add(this.msTools);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "InstructionViewForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "InstructionViewForm";
            this.msTools.ResumeLayout(false);
            this.msTools.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox lbInstructions;
        private MenuStrip msTools;
        private ToolStripMenuItem fajlToolStripMenuItem;
        private ToolStripMenuItem učitajToolStripMenuItem;
        private ToolStripMenuItem osvežiToolStripMenuItem;
        private ToolStripMenuItem sačuvajKaoToolStripMenuItem;
        private ToolStripMenuItem sačuvajToolStripMenuItem;
        private ToolStripMenuItem izmeniToolStripMenuItem;
        private ToolStripMenuItem vrednostRegistraToolStripMenuItem;
        private ToolStripMenuItem pronadjiToolStripMenuItem;
        private ToolStripMenuItem pronađiToolStripMenuItem;
        private CheckBox cbLockToPc;
    }
}