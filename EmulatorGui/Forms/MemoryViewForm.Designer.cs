namespace EmulatorGui
{
    partial class MemoryViewForm
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
            this.lbMemory = new System.Windows.Forms.ListBox();
            this.msTools = new System.Windows.Forms.MenuStrip();
            this.fajlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.učitajToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.osvežiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sačuvajKaoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sačuvajToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izmeniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smanjiPovećajMemorijuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vrednostRegistraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.očistiRegistreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pronadjiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pronađiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jedanBajtPoReduToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dvaBajtaPoReduToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbMemory
            // 
            this.lbMemory.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbMemory.FormattingEnabled = true;
            this.lbMemory.ItemHeight = 14;
            this.lbMemory.Location = new System.Drawing.Point(12, 27);
            this.lbMemory.Name = "lbMemory";
            this.lbMemory.Size = new System.Drawing.Size(260, 452);
            this.lbMemory.TabIndex = 4;
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
            this.msTools.TabIndex = 5;
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
            this.smanjiPovećajMemorijuToolStripMenuItem,
            this.vrednostRegistraToolStripMenuItem,
            this.očistiRegistreToolStripMenuItem});
            this.izmeniToolStripMenuItem.Name = "izmeniToolStripMenuItem";
            this.izmeniToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.izmeniToolStripMenuItem.Text = "Izmeni";
            // 
            // smanjiPovećajMemorijuToolStripMenuItem
            // 
            this.smanjiPovećajMemorijuToolStripMenuItem.Name = "smanjiPovećajMemorijuToolStripMenuItem";
            this.smanjiPovećajMemorijuToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.smanjiPovećajMemorijuToolStripMenuItem.Text = "Promeni veličinu";
            // 
            // vrednostRegistraToolStripMenuItem
            // 
            this.vrednostRegistraToolStripMenuItem.Name = "vrednostRegistraToolStripMenuItem";
            this.vrednostRegistraToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.vrednostRegistraToolStripMenuItem.Text = "Upiši vrednost";
            // 
            // očistiRegistreToolStripMenuItem
            // 
            this.očistiRegistreToolStripMenuItem.Name = "očistiRegistreToolStripMenuItem";
            this.očistiRegistreToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.očistiRegistreToolStripMenuItem.Text = "Očisti memoriju";
            // 
            // pronadjiToolStripMenuItem
            // 
            this.pronadjiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pronađiToolStripMenuItem,
            this.formatToolStripMenuItem});
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
            // formatToolStripMenuItem
            // 
            this.formatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jedanBajtPoReduToolStripMenuItem,
            this.dvaBajtaPoReduToolStripMenuItem});
            this.formatToolStripMenuItem.Name = "formatToolStripMenuItem";
            this.formatToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.formatToolStripMenuItem.Text = "Format";
            // 
            // jedanBajtPoReduToolStripMenuItem
            // 
            this.jedanBajtPoReduToolStripMenuItem.Name = "jedanBajtPoReduToolStripMenuItem";
            this.jedanBajtPoReduToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.jedanBajtPoReduToolStripMenuItem.Text = "Jedan bajt po redu";
            // 
            // dvaBajtaPoReduToolStripMenuItem
            // 
            this.dvaBajtaPoReduToolStripMenuItem.Name = "dvaBajtaPoReduToolStripMenuItem";
            this.dvaBajtaPoReduToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.dvaBajtaPoReduToolStripMenuItem.Text = "Dva bajta po redu";
            // 
            // MemoryViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 491);
            this.Controls.Add(this.lbMemory);
            this.Controls.Add(this.msTools);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MemoryViewForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Pregled memorije";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MemoryViewForm_FormClosing);
            this.msTools.ResumeLayout(false);
            this.msTools.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox lbMemory;
        private MenuStrip msTools;
        private ToolStripMenuItem fajlToolStripMenuItem;
        private ToolStripMenuItem učitajToolStripMenuItem;
        private ToolStripMenuItem osvežiToolStripMenuItem;
        private ToolStripMenuItem sačuvajKaoToolStripMenuItem;
        private ToolStripMenuItem sačuvajToolStripMenuItem;
        private ToolStripMenuItem izmeniToolStripMenuItem;
        private ToolStripMenuItem vrednostRegistraToolStripMenuItem;
        private ToolStripMenuItem očistiRegistreToolStripMenuItem;
        private ToolStripMenuItem pronadjiToolStripMenuItem;
        private ToolStripMenuItem pronađiToolStripMenuItem;
        private ToolStripMenuItem formatToolStripMenuItem;
        private ToolStripMenuItem jedanBajtPoReduToolStripMenuItem;
        private ToolStripMenuItem dvaBajtaPoReduToolStripMenuItem;
        private ToolStripMenuItem smanjiPovećajMemorijuToolStripMenuItem;
    }
}