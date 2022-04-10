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
            this.učitajToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.osvežiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sačuvajKaoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sačuvajToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zaslugeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đorđeRmušRT1419ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStep = new System.Windows.Forms.Button();
            this.lbRegisters = new System.Windows.Forms.ListBox();
            this.lbSearch = new System.Windows.Forms.Label();
            this.tbResize = new System.Windows.Forms.TextBox();
            this.lbCapacity = new System.Windows.Forms.Label();
            this.btnResize = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.lbResize = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.Button();
            this.lbDst = new System.Windows.Forms.Label();
            this.tbDst = new System.Windows.Forms.TextBox();
            this.lbSrcTo = new System.Windows.Forms.Label();
            this.lbSrcFrom = new System.Windows.Forms.Label();
            this.tbSrcTo = new System.Windows.Forms.TextBox();
            this.tbSrcFrom = new System.Windows.Forms.TextBox();
            this.lbCopy = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.lbClearValue = new System.Windows.Forms.Label();
            this.tbClearValue = new System.Windows.Forms.TextBox();
            this.lbClearTo = new System.Windows.Forms.Label();
            this.lbClearFrom = new System.Windows.Forms.Label();
            this.tbClearTo = new System.Windows.Forms.TextBox();
            this.lbClearMemory = new System.Windows.Forms.Label();
            this.tbClearFrom = new System.Windows.Forms.TextBox();
            this.groupOptions = new System.Windows.Forms.GroupBox();
            this.lbMemory = new System.Windows.Forms.ListBox();
            this.lbInstructions = new System.Windows.Forms.ListBox();
            this.msTools.SuspendLayout();
            this.groupOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // msTools
            // 
            this.msTools.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.msTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.zaslugeToolStripMenuItem});
            this.msTools.Location = new System.Drawing.Point(0, 0);
            this.msTools.Name = "msTools";
            this.msTools.Padding = new System.Windows.Forms.Padding(5, 1, 0, 1);
            this.msTools.Size = new System.Drawing.Size(1184, 24);
            this.msTools.TabIndex = 0;
            this.msTools.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.učitajToolStripMenuItem,
            this.osvežiToolStripMenuItem,
            this.sačuvajKaoToolStripMenuItem,
            this.sačuvajToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(47, 22);
            this.fileToolStripMenuItem.Text = "Fajl";
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
            // btnStep
            // 
            this.btnStep.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnStep.Location = new System.Drawing.Point(318, 483);
            this.btnStep.Name = "btnStep";
            this.btnStep.Size = new System.Drawing.Size(100, 24);
            this.btnStep.TabIndex = 1;
            this.btnStep.UseVisualStyleBackColor = true;
            this.btnStep.Click += new System.EventHandler(this.btnStep_Click);
            // 
            // lbRegisters
            // 
            this.lbRegisters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbRegisters.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbRegisters.FormattingEnabled = true;
            this.lbRegisters.ItemHeight = 14;
            this.lbRegisters.Location = new System.Drawing.Point(12, 27);
            this.lbRegisters.Name = "lbRegisters";
            this.lbRegisters.Size = new System.Drawing.Size(300, 450);
            this.lbRegisters.TabIndex = 2;
            this.lbRegisters.DoubleClick += new System.EventHandler(this.lbRegisters_DoubleClick);
            // 
            // lbSearch
            // 
            this.lbSearch.AutoSize = true;
            this.lbSearch.Location = new System.Drawing.Point(14, 343);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(70, 14);
            this.lbSearch.TabIndex = 30;
            this.lbSearch.Text = "Pretraga:";
            // 
            // tbResize
            // 
            this.tbResize.Location = new System.Drawing.Point(6, 265);
            this.tbResize.MaxLength = 16;
            this.tbResize.Name = "tbResize";
            this.tbResize.Size = new System.Drawing.Size(188, 22);
            this.tbResize.TabIndex = 29;
            this.tbResize.Text = "0000";
            // 
            // lbCapacity
            // 
            this.lbCapacity.AutoSize = true;
            this.lbCapacity.Location = new System.Drawing.Point(6, 421);
            this.lbCapacity.Name = "lbCapacity";
            this.lbCapacity.Size = new System.Drawing.Size(105, 28);
            this.lbCapacity.TabIndex = 8;
            this.lbCapacity.Text = "kapacitet:\r\n  8192 bajtova\r\n";
            // 
            // btnResize
            // 
            this.btnResize.Location = new System.Drawing.Point(6, 293);
            this.btnResize.Name = "btnResize";
            this.btnResize.Size = new System.Drawing.Size(188, 23);
            this.btnResize.TabIndex = 28;
            this.btnResize.Text = "Promeni veličinu";
            this.btnResize.UseVisualStyleBackColor = true;
            this.btnResize.Click += new System.EventHandler(this.btnResize_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(52, 360);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(30, 23);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = ">>";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(6, 360);
            this.tbSearch.MaxLength = 4;
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(40, 22);
            this.tbSearch.TabIndex = 6;
            this.tbSearch.Text = "0000";
            // 
            // lbResize
            // 
            this.lbResize.AutoSize = true;
            this.lbResize.Location = new System.Drawing.Point(14, 244);
            this.lbResize.Name = "lbResize";
            this.lbResize.Size = new System.Drawing.Size(126, 14);
            this.lbResize.TabIndex = 27;
            this.lbResize.Text = "Promeni veličinu:";
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(6, 202);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(188, 23);
            this.btnCopy.TabIndex = 26;
            this.btnCopy.Text = "Kopiraj memoriju";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // lbDst
            // 
            this.lbDst.AutoSize = true;
            this.lbDst.Location = new System.Drawing.Point(106, 157);
            this.lbDst.Name = "lbDst";
            this.lbDst.Size = new System.Drawing.Size(91, 14);
            this.lbDst.TabIndex = 25;
            this.lbDst.Text = "Destinacija:";
            // 
            // tbDst
            // 
            this.tbDst.Location = new System.Drawing.Point(154, 174);
            this.tbDst.MaxLength = 4;
            this.tbDst.Name = "tbDst";
            this.tbDst.Size = new System.Drawing.Size(40, 22);
            this.tbDst.TabIndex = 24;
            this.tbDst.Text = "0000";
            // 
            // lbSrcTo
            // 
            this.lbSrcTo.AutoSize = true;
            this.lbSrcTo.Location = new System.Drawing.Point(52, 157);
            this.lbSrcTo.Name = "lbSrcTo";
            this.lbSrcTo.Size = new System.Drawing.Size(28, 14);
            this.lbSrcTo.TabIndex = 23;
            this.lbSrcTo.Text = "Do:";
            // 
            // lbSrcFrom
            // 
            this.lbSrcFrom.AutoSize = true;
            this.lbSrcFrom.Location = new System.Drawing.Point(6, 157);
            this.lbSrcFrom.Name = "lbSrcFrom";
            this.lbSrcFrom.Size = new System.Drawing.Size(28, 14);
            this.lbSrcFrom.TabIndex = 22;
            this.lbSrcFrom.Text = "Od:";
            // 
            // tbSrcTo
            // 
            this.tbSrcTo.Location = new System.Drawing.Point(52, 174);
            this.tbSrcTo.MaxLength = 4;
            this.tbSrcTo.Name = "tbSrcTo";
            this.tbSrcTo.Size = new System.Drawing.Size(40, 22);
            this.tbSrcTo.TabIndex = 21;
            this.tbSrcTo.Text = "0000";
            // 
            // tbSrcFrom
            // 
            this.tbSrcFrom.Location = new System.Drawing.Point(6, 174);
            this.tbSrcFrom.MaxLength = 4;
            this.tbSrcFrom.Name = "tbSrcFrom";
            this.tbSrcFrom.Size = new System.Drawing.Size(40, 22);
            this.tbSrcFrom.TabIndex = 20;
            this.tbSrcFrom.Text = "0000";
            // 
            // lbCopy
            // 
            this.lbCopy.AutoSize = true;
            this.lbCopy.Location = new System.Drawing.Point(14, 139);
            this.lbCopy.Name = "lbCopy";
            this.lbCopy.Size = new System.Drawing.Size(126, 14);
            this.lbCopy.TabIndex = 19;
            this.lbCopy.Text = "Kopiraj memoriju:";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(6, 97);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(188, 23);
            this.btnClear.TabIndex = 17;
            this.btnClear.Text = "Očisti memoriju";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lbClearValue
            // 
            this.lbClearValue.AutoSize = true;
            this.lbClearValue.Location = new System.Drawing.Point(124, 52);
            this.lbClearValue.Name = "lbClearValue";
            this.lbClearValue.Size = new System.Drawing.Size(70, 14);
            this.lbClearValue.TabIndex = 16;
            this.lbClearValue.Text = "Vrednost:";
            // 
            // tbClearValue
            // 
            this.tbClearValue.Location = new System.Drawing.Point(154, 69);
            this.tbClearValue.MaxLength = 2;
            this.tbClearValue.Name = "tbClearValue";
            this.tbClearValue.Size = new System.Drawing.Size(40, 22);
            this.tbClearValue.TabIndex = 15;
            this.tbClearValue.Text = "00";
            // 
            // lbClearTo
            // 
            this.lbClearTo.AutoSize = true;
            this.lbClearTo.Location = new System.Drawing.Point(52, 52);
            this.lbClearTo.Name = "lbClearTo";
            this.lbClearTo.Size = new System.Drawing.Size(28, 14);
            this.lbClearTo.TabIndex = 14;
            this.lbClearTo.Text = "Do:";
            // 
            // lbClearFrom
            // 
            this.lbClearFrom.AutoSize = true;
            this.lbClearFrom.Location = new System.Drawing.Point(6, 52);
            this.lbClearFrom.Name = "lbClearFrom";
            this.lbClearFrom.Size = new System.Drawing.Size(28, 14);
            this.lbClearFrom.TabIndex = 13;
            this.lbClearFrom.Text = "Od:";
            // 
            // tbClearTo
            // 
            this.tbClearTo.Location = new System.Drawing.Point(52, 69);
            this.tbClearTo.MaxLength = 4;
            this.tbClearTo.Name = "tbClearTo";
            this.tbClearTo.Size = new System.Drawing.Size(40, 22);
            this.tbClearTo.TabIndex = 12;
            this.tbClearTo.Text = "FFFF";
            // 
            // lbClearMemory
            // 
            this.lbClearMemory.AutoSize = true;
            this.lbClearMemory.Location = new System.Drawing.Point(14, 34);
            this.lbClearMemory.Name = "lbClearMemory";
            this.lbClearMemory.Size = new System.Drawing.Size(119, 14);
            this.lbClearMemory.TabIndex = 11;
            this.lbClearMemory.Text = "Očisti memoriju:";
            // 
            // tbClearFrom
            // 
            this.tbClearFrom.Location = new System.Drawing.Point(6, 69);
            this.tbClearFrom.MaxLength = 4;
            this.tbClearFrom.Name = "tbClearFrom";
            this.tbClearFrom.Size = new System.Drawing.Size(40, 22);
            this.tbClearFrom.TabIndex = 10;
            this.tbClearFrom.Text = "0000";
            // 
            // groupOptions
            // 
            this.groupOptions.Controls.Add(this.lbSearch);
            this.groupOptions.Controls.Add(this.tbResize);
            this.groupOptions.Controls.Add(this.lbCapacity);
            this.groupOptions.Controls.Add(this.btnResize);
            this.groupOptions.Controls.Add(this.btnSearch);
            this.groupOptions.Controls.Add(this.tbSearch);
            this.groupOptions.Controls.Add(this.lbResize);
            this.groupOptions.Controls.Add(this.btnCopy);
            this.groupOptions.Controls.Add(this.lbDst);
            this.groupOptions.Controls.Add(this.tbDst);
            this.groupOptions.Controls.Add(this.lbSrcTo);
            this.groupOptions.Controls.Add(this.lbSrcFrom);
            this.groupOptions.Controls.Add(this.tbSrcTo);
            this.groupOptions.Controls.Add(this.tbSrcFrom);
            this.groupOptions.Controls.Add(this.lbCopy);
            this.groupOptions.Controls.Add(this.btnClear);
            this.groupOptions.Controls.Add(this.lbClearValue);
            this.groupOptions.Controls.Add(this.tbClearValue);
            this.groupOptions.Controls.Add(this.lbClearTo);
            this.groupOptions.Controls.Add(this.lbClearFrom);
            this.groupOptions.Controls.Add(this.tbClearTo);
            this.groupOptions.Controls.Add(this.lbClearMemory);
            this.groupOptions.Controls.Add(this.tbClearFrom);
            this.groupOptions.Location = new System.Drawing.Point(980, 27);
            this.groupOptions.Name = "groupOptions";
            this.groupOptions.Size = new System.Drawing.Size(200, 452);
            this.groupOptions.TabIndex = 11;
            this.groupOptions.TabStop = false;
            this.groupOptions.Text = "Opcije";
            // 
            // lbMemory
            // 
            this.lbMemory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbMemory.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbMemory.FormattingEnabled = true;
            this.lbMemory.ItemHeight = 14;
            this.lbMemory.Location = new System.Drawing.Point(624, 27);
            this.lbMemory.Name = "lbMemory";
            this.lbMemory.Size = new System.Drawing.Size(350, 450);
            this.lbMemory.TabIndex = 10;
            this.lbMemory.DoubleClick += new System.EventHandler(this.lbMemory_DoubleClick);
            // 
            // lbInstructions
            // 
            this.lbInstructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbInstructions.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbInstructions.FormattingEnabled = true;
            this.lbInstructions.ItemHeight = 14;
            this.lbInstructions.Location = new System.Drawing.Point(318, 27);
            this.lbInstructions.Name = "lbInstructions";
            this.lbInstructions.Size = new System.Drawing.Size(300, 450);
            this.lbInstructions.TabIndex = 31;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 511);
            this.Controls.Add(this.lbInstructions);
            this.Controls.Add(this.groupOptions);
            this.Controls.Add(this.lbMemory);
            this.Controls.Add(this.lbRegisters);
            this.Controls.Add(this.btnStep);
            this.Controls.Add(this.msTools);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.msTools;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Emulator";
            this.msTools.ResumeLayout(false);
            this.msTools.PerformLayout();
            this.groupOptions.ResumeLayout(false);
            this.groupOptions.PerformLayout();
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
        private ToolStripMenuItem zaslugeToolStripMenuItem;
        private ToolStripMenuItem đorđeRmušRT1419ToolStripMenuItem;
        private Button btnStep;
        private ListBox lbRegisters;
        private Label lbSearch;
        private TextBox tbResize;
        private Label lbCapacity;
        private Button btnResize;
        private Button btnSearch;
        private TextBox tbSearch;
        private Label lbResize;
        private Button btnCopy;
        private Label lbDst;
        private TextBox tbDst;
        private Label lbSrcTo;
        private Label lbSrcFrom;
        private TextBox tbSrcTo;
        private TextBox tbSrcFrom;
        private Label lbCopy;
        private Button btnClear;
        private Label lbClearValue;
        private TextBox tbClearValue;
        private Label lbClearTo;
        private Label lbClearFrom;
        private TextBox tbClearTo;
        private Label lbClearMemory;
        private TextBox tbClearFrom;
        private GroupBox groupOptions;
        private ListBox lbMemory;
        private ListBox lbInstructions;
    }
}