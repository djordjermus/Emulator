namespace EmulatorGui
{
    partial class RegisterViewForm
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
            this.lbRegisters = new System.Windows.Forms.ListBox();
            this.msTools = new System.Windows.Forms.MenuStrip();
            this.fajlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.učitajToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.osvežiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sačuvajKaoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sačuvajToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izmeniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.očistiRegistreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vrednostRegistraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbRegisters
            // 
            this.lbRegisters.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbRegisters.FormattingEnabled = true;
            this.lbRegisters.ItemHeight = 14;
            this.lbRegisters.Location = new System.Drawing.Point(12, 27);
            this.lbRegisters.Name = "lbRegisters";
            this.lbRegisters.Size = new System.Drawing.Size(260, 452);
            this.lbRegisters.TabIndex = 0;
            // 
            // msTools
            // 
            this.msTools.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.msTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fajlToolStripMenuItem,
            this.izmeniToolStripMenuItem});
            this.msTools.Location = new System.Drawing.Point(0, 0);
            this.msTools.Name = "msTools";
            this.msTools.Size = new System.Drawing.Size(284, 24);
            this.msTools.TabIndex = 3;
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
            this.očistiRegistreToolStripMenuItem,
            this.vrednostRegistraToolStripMenuItem});
            this.izmeniToolStripMenuItem.Name = "izmeniToolStripMenuItem";
            this.izmeniToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.izmeniToolStripMenuItem.Text = "Izmeni";
            // 
            // očistiRegistreToolStripMenuItem
            // 
            this.očistiRegistreToolStripMenuItem.Name = "očistiRegistreToolStripMenuItem";
            this.očistiRegistreToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.očistiRegistreToolStripMenuItem.Text = "Očisti registre";
            // 
            // vrednostRegistraToolStripMenuItem
            // 
            this.vrednostRegistraToolStripMenuItem.Enabled = false;
            this.vrednostRegistraToolStripMenuItem.Name = "vrednostRegistraToolStripMenuItem";
            this.vrednostRegistraToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.vrednostRegistraToolStripMenuItem.Text = "Vrednost registra";
            // 
            // RegisterViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 492);
            this.Controls.Add(this.lbRegisters);
            this.Controls.Add(this.msTools);
            this.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "RegisterViewForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Pregled registara";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RegisterViewForm_FormClosing);
            this.msTools.ResumeLayout(false);
            this.msTools.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ListBox lbRegisters;
        private MenuStrip msTools;
        private ToolStripMenuItem fajlToolStripMenuItem;
        private ToolStripMenuItem učitajToolStripMenuItem;
        private ToolStripMenuItem osvežiToolStripMenuItem;
        private ToolStripMenuItem sačuvajToolStripMenuItem;
        private ToolStripMenuItem sačuvajKaoToolStripMenuItem;
        private ToolStripMenuItem izmeniToolStripMenuItem;
        private ToolStripMenuItem vrednostRegistraToolStripMenuItem;
        private ToolStripMenuItem očistiRegistreToolStripMenuItem;
    }
}