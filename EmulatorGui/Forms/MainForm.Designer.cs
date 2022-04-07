namespace EmulatorGui
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.msTools = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noviProjekatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.učitajToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.osvežiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sačuvajKaoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sačuvajToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prozoriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.memorijaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instrukcijeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zaslugeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đorđeRmušRT1419ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // msTools
            // 
            this.msTools.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.msTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.prozoriToolStripMenuItem,
            this.zaslugeToolStripMenuItem});
            this.msTools.Location = new System.Drawing.Point(0, 0);
            this.msTools.Name = "msTools";
            this.msTools.Padding = new System.Windows.Forms.Padding(5, 1, 0, 1);
            this.msTools.Size = new System.Drawing.Size(234, 24);
            this.msTools.TabIndex = 0;
            this.msTools.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noviProjekatToolStripMenuItem,
            this.učitajToolStripMenuItem,
            this.osvežiToolStripMenuItem,
            this.sačuvajKaoToolStripMenuItem,
            this.sačuvajToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(47, 22);
            this.fileToolStripMenuItem.Text = "Fajl";
            // 
            // noviProjekatToolStripMenuItem
            // 
            this.noviProjekatToolStripMenuItem.Name = "noviProjekatToolStripMenuItem";
            this.noviProjekatToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.noviProjekatToolStripMenuItem.Text = "Novi projekat";
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
            // prozoriToolStripMenuItem
            // 
            this.prozoriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registriToolStripMenuItem,
            this.memorijaToolStripMenuItem,
            this.instrukcijeToolStripMenuItem});
            this.prozoriToolStripMenuItem.Name = "prozoriToolStripMenuItem";
            this.prozoriToolStripMenuItem.Size = new System.Drawing.Size(68, 22);
            this.prozoriToolStripMenuItem.Text = "Prozori";
            // 
            // registriToolStripMenuItem
            // 
            this.registriToolStripMenuItem.Name = "registriToolStripMenuItem";
            this.registriToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.registriToolStripMenuItem.Text = "Registri";
            this.registriToolStripMenuItem.Click += new System.EventHandler(this.registriToolStripMenuItem_Click);
            // 
            // memorijaToolStripMenuItem
            // 
            this.memorijaToolStripMenuItem.Name = "memorijaToolStripMenuItem";
            this.memorijaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.memorijaToolStripMenuItem.Text = "Memorija";
            this.memorijaToolStripMenuItem.Click += new System.EventHandler(this.memorijaToolStripMenuItem_Click);
            // 
            // instrukcijeToolStripMenuItem
            // 
            this.instrukcijeToolStripMenuItem.Name = "instrukcijeToolStripMenuItem";
            this.instrukcijeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.instrukcijeToolStripMenuItem.Text = "Instrukcije";
            this.instrukcijeToolStripMenuItem.Click += new System.EventHandler(this.instrukcijeToolStripMenuItem_Click);
            // 
            // zaslugeToolStripMenuItem
            // 
            this.zaslugeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đorđeRmušRT1419ToolStripMenuItem});
            this.zaslugeToolStripMenuItem.Name = "zaslugeToolStripMenuItem";
            this.zaslugeToolStripMenuItem.Size = new System.Drawing.Size(68, 22);
            this.zaslugeToolStripMenuItem.Text = "Zasluge";
            // 
            // đorđeRmušRT1419ToolStripMenuItem
            // 
            this.đorđeRmušRT1419ToolStripMenuItem.Enabled = false;
            this.đorđeRmušRT1419ToolStripMenuItem.Name = "đorđeRmušRT1419ToolStripMenuItem";
            this.đorđeRmušRT1419ToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.đorđeRmušRT1419ToolStripMenuItem.Text = "Đorđe Rmuš RT-14/19";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 26);
            this.Controls.Add(this.msTools);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.msTools;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Emulator";
            this.msTools.ResumeLayout(false);
            this.msTools.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip msTools;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem učitajToolStripMenuItem;
        private ToolStripMenuItem osvežiToolStripMenuItem;
        private ToolStripMenuItem sačuvajToolStripMenuItem;
        private ToolStripMenuItem sačuvajKaoToolStripMenuItem;
        private ToolStripMenuItem prozoriToolStripMenuItem;
        private ToolStripMenuItem registriToolStripMenuItem;
        private ToolStripMenuItem memorijaToolStripMenuItem;
        private ToolStripMenuItem instrukcijeToolStripMenuItem;
        private ToolStripMenuItem zaslugeToolStripMenuItem;
        private ToolStripMenuItem đorđeRmušRT1419ToolStripMenuItem;
        private ToolStripMenuItem noviProjekatToolStripMenuItem;
    }
}