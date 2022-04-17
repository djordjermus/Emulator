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
            this.msLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.msReload = new System.Windows.Forms.ToolStripMenuItem();
            this.msSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.msSave = new System.Windows.Forms.ToolStripMenuItem();
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
            this.lbInterrupt = new System.Windows.Forms.Label();
            this.btnStopExec = new System.Windows.Forms.Button();
            this.btnExecuteUntil = new System.Windows.Forms.Button();
            this.lbExecuteUntil = new System.Windows.Forms.Label();
            this.tbExecuteUntil = new System.Windows.Forms.TextBox();
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
            this.msTools.Size = new System.Drawing.Size(1094, 24);
            this.msTools.TabIndex = 0;
            this.msTools.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msLoad,
            this.msReload,
            this.msSaveAs,
            this.msSave});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(47, 22);
            this.fileToolStripMenuItem.Text = "Fajl";
            // 
            // msLoad
            // 
            this.msLoad.Name = "msLoad";
            this.msLoad.Size = new System.Drawing.Size(179, 22);
            this.msLoad.Text = "Učitaj iz fajla";
            this.msLoad.Click += new System.EventHandler(this.btnLoadClick);
            // 
            // msReload
            // 
            this.msReload.Enabled = false;
            this.msReload.Name = "msReload";
            this.msReload.Size = new System.Drawing.Size(179, 22);
            this.msReload.Text = "Osveži";
            this.msReload.Click += new System.EventHandler(this.msReload_Click);
            // 
            // msSaveAs
            // 
            this.msSaveAs.Name = "msSaveAs";
            this.msSaveAs.Size = new System.Drawing.Size(179, 22);
            this.msSaveAs.Text = "Sačuvaj kao";
            this.msSaveAs.Click += new System.EventHandler(this.btnSaveAsClick);
            // 
            // msSave
            // 
            this.msSave.Enabled = false;
            this.msSave.Name = "msSave";
            this.msSave.Size = new System.Drawing.Size(179, 22);
            this.msSave.Text = "Sačuvaj";
            this.msSave.Click += new System.EventHandler(this.msSave_Click);
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
            this.đorđeRmušRT1419ToolStripMenuItem.Name = "đorđeRmušRT1419ToolStripMenuItem";
            this.đorđeRmušRT1419ToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.đorđeRmušRT1419ToolStripMenuItem.Text = "Đorđe Rmuš RT-14/19";
            // 
            // btnStep
            // 
            this.btnStep.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnStep.Location = new System.Drawing.Point(6, 356);
            this.btnStep.Name = "btnStep";
            this.btnStep.Size = new System.Drawing.Size(188, 22);
            this.btnStep.TabIndex = 1;
            this.btnStep.TabStop = false;
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
            this.lbRegisters.Size = new System.Drawing.Size(260, 450);
            this.lbRegisters.TabIndex = 2;
            this.lbRegisters.TabStop = false;
            this.lbRegisters.DoubleClick += new System.EventHandler(this.lbRegisters_DoubleClick);
            // 
            // lbSearch
            // 
            this.lbSearch.AutoSize = true;
            this.lbSearch.Location = new System.Drawing.Point(128, 227);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(70, 14);
            this.lbSearch.TabIndex = 30;
            this.lbSearch.Text = "Pretraga:";
            // 
            // tbResize
            // 
            this.tbResize.Location = new System.Drawing.Point(6, 244);
            this.tbResize.MaxLength = 16;
            this.tbResize.Name = "tbResize";
            this.tbResize.PlaceholderText = "DEC";
            this.tbResize.Size = new System.Drawing.Size(74, 22);
            this.tbResize.TabIndex = 29;
            this.tbResize.TabStop = false;
            // 
            // lbCapacity
            // 
            this.lbCapacity.AutoSize = true;
            this.lbCapacity.ForeColor = System.Drawing.Color.Gray;
            this.lbCapacity.Location = new System.Drawing.Point(10, 269);
            this.lbCapacity.Name = "lbCapacity";
            this.lbCapacity.Size = new System.Drawing.Size(63, 14);
            this.lbCapacity.TabIndex = 8;
            this.lbCapacity.Text = "(65535B)\r\n";
            // 
            // btnResize
            // 
            this.btnResize.Location = new System.Drawing.Point(80, 243);
            this.btnResize.Name = "btnResize";
            this.btnResize.Size = new System.Drawing.Size(30, 23);
            this.btnResize.TabIndex = 28;
            this.btnResize.TabStop = false;
            this.btnResize.Text = ">>";
            this.btnResize.UseVisualStyleBackColor = true;
            this.btnResize.Click += new System.EventHandler(this.btnResize_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(164, 244);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(30, 22);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.TabStop = false;
            this.btnSearch.Text = ">>";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(124, 244);
            this.tbSearch.MaxLength = 4;
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.PlaceholderText = "HEX";
            this.tbSearch.Size = new System.Drawing.Size(40, 22);
            this.tbSearch.TabIndex = 6;
            this.tbSearch.TabStop = false;
            // 
            // lbResize
            // 
            this.lbResize.AutoSize = true;
            this.lbResize.Location = new System.Drawing.Point(10, 227);
            this.lbResize.Name = "lbResize";
            this.lbResize.Size = new System.Drawing.Size(70, 14);
            this.lbResize.TabIndex = 27;
            this.lbResize.Text = "Veličinu:";
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(6, 193);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(188, 23);
            this.btnCopy.TabIndex = 26;
            this.btnCopy.TabStop = false;
            this.btnCopy.Text = "Kopiraj memoriju";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // lbDst
            // 
            this.lbDst.AutoSize = true;
            this.lbDst.Location = new System.Drawing.Point(106, 148);
            this.lbDst.Name = "lbDst";
            this.lbDst.Size = new System.Drawing.Size(91, 14);
            this.lbDst.TabIndex = 25;
            this.lbDst.Text = "Destinacija:";
            // 
            // tbDst
            // 
            this.tbDst.Location = new System.Drawing.Point(154, 165);
            this.tbDst.MaxLength = 4;
            this.tbDst.Name = "tbDst";
            this.tbDst.PlaceholderText = "HEX";
            this.tbDst.Size = new System.Drawing.Size(40, 22);
            this.tbDst.TabIndex = 24;
            this.tbDst.TabStop = false;
            // 
            // lbSrcTo
            // 
            this.lbSrcTo.AutoSize = true;
            this.lbSrcTo.Location = new System.Drawing.Point(52, 148);
            this.lbSrcTo.Name = "lbSrcTo";
            this.lbSrcTo.Size = new System.Drawing.Size(28, 14);
            this.lbSrcTo.TabIndex = 23;
            this.lbSrcTo.Text = "Do:";
            // 
            // lbSrcFrom
            // 
            this.lbSrcFrom.AutoSize = true;
            this.lbSrcFrom.Location = new System.Drawing.Point(6, 148);
            this.lbSrcFrom.Name = "lbSrcFrom";
            this.lbSrcFrom.Size = new System.Drawing.Size(28, 14);
            this.lbSrcFrom.TabIndex = 22;
            this.lbSrcFrom.Text = "Od:";
            // 
            // tbSrcTo
            // 
            this.tbSrcTo.Location = new System.Drawing.Point(52, 165);
            this.tbSrcTo.MaxLength = 4;
            this.tbSrcTo.Name = "tbSrcTo";
            this.tbSrcTo.PlaceholderText = "HEX";
            this.tbSrcTo.Size = new System.Drawing.Size(40, 22);
            this.tbSrcTo.TabIndex = 21;
            this.tbSrcTo.TabStop = false;
            // 
            // tbSrcFrom
            // 
            this.tbSrcFrom.Location = new System.Drawing.Point(6, 165);
            this.tbSrcFrom.MaxLength = 4;
            this.tbSrcFrom.Name = "tbSrcFrom";
            this.tbSrcFrom.PlaceholderText = "HEX";
            this.tbSrcFrom.Size = new System.Drawing.Size(40, 22);
            this.tbSrcFrom.TabIndex = 20;
            this.tbSrcFrom.TabStop = false;
            // 
            // lbCopy
            // 
            this.lbCopy.AutoSize = true;
            this.lbCopy.Location = new System.Drawing.Point(10, 130);
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
            this.btnClear.TabStop = false;
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
            this.tbClearValue.PlaceholderText = "HEX";
            this.tbClearValue.Size = new System.Drawing.Size(40, 22);
            this.tbClearValue.TabIndex = 15;
            this.tbClearValue.TabStop = false;
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
            this.tbClearTo.PlaceholderText = "HEX";
            this.tbClearTo.Size = new System.Drawing.Size(40, 22);
            this.tbClearTo.TabIndex = 12;
            this.tbClearTo.TabStop = false;
            // 
            // lbClearMemory
            // 
            this.lbClearMemory.AutoSize = true;
            this.lbClearMemory.Location = new System.Drawing.Point(10, 34);
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
            this.tbClearFrom.PlaceholderText = "HEX";
            this.tbClearFrom.Size = new System.Drawing.Size(40, 22);
            this.tbClearFrom.TabIndex = 10;
            this.tbClearFrom.TabStop = false;
            // 
            // groupOptions
            // 
            this.groupOptions.Controls.Add(this.lbInterrupt);
            this.groupOptions.Controls.Add(this.btnStopExec);
            this.groupOptions.Controls.Add(this.btnExecuteUntil);
            this.groupOptions.Controls.Add(this.lbExecuteUntil);
            this.groupOptions.Controls.Add(this.tbExecuteUntil);
            this.groupOptions.Controls.Add(this.lbSearch);
            this.groupOptions.Controls.Add(this.tbResize);
            this.groupOptions.Controls.Add(this.lbCapacity);
            this.groupOptions.Controls.Add(this.btnResize);
            this.groupOptions.Controls.Add(this.btnStep);
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
            this.groupOptions.Location = new System.Drawing.Point(890, 27);
            this.groupOptions.Name = "groupOptions";
            this.groupOptions.Size = new System.Drawing.Size(200, 452);
            this.groupOptions.TabIndex = 11;
            this.groupOptions.TabStop = false;
            this.groupOptions.Text = "Opcije";
            // 
            // lbInterrupt
            // 
            this.lbInterrupt.AutoSize = true;
            this.lbInterrupt.ForeColor = System.Drawing.Color.Gray;
            this.lbInterrupt.Location = new System.Drawing.Point(6, 381);
            this.lbInterrupt.Name = "lbInterrupt";
            this.lbInterrupt.Size = new System.Drawing.Size(91, 14);
            this.lbInterrupt.TabIndex = 38;
            this.lbInterrupt.Text = "Prekid: none";
            // 
            // btnStopExec
            // 
            this.btnStopExec.Enabled = false;
            this.btnStopExec.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnStopExec.ForeColor = System.Drawing.Color.Red;
            this.btnStopExec.Location = new System.Drawing.Point(82, 423);
            this.btnStopExec.Name = "btnStopExec";
            this.btnStopExec.Size = new System.Drawing.Size(112, 23);
            this.btnStopExec.TabIndex = 37;
            this.btnStopExec.TabStop = false;
            this.btnStopExec.Text = "ZAUSTAVI";
            this.btnStopExec.UseVisualStyleBackColor = true;
            this.btnStopExec.Click += new System.EventHandler(this.btnStopExec_Click);
            // 
            // btnExecuteUntil
            // 
            this.btnExecuteUntil.Location = new System.Drawing.Point(46, 424);
            this.btnExecuteUntil.Name = "btnExecuteUntil";
            this.btnExecuteUntil.Size = new System.Drawing.Size(30, 22);
            this.btnExecuteUntil.TabIndex = 36;
            this.btnExecuteUntil.TabStop = false;
            this.btnExecuteUntil.Text = ">>";
            this.btnExecuteUntil.UseVisualStyleBackColor = true;
            this.btnExecuteUntil.Click += new System.EventHandler(this.btnExecuteUntil_Click);
            // 
            // lbExecuteUntil
            // 
            this.lbExecuteUntil.AutoSize = true;
            this.lbExecuteUntil.Location = new System.Drawing.Point(6, 407);
            this.lbExecuteUntil.Name = "lbExecuteUntil";
            this.lbExecuteUntil.Size = new System.Drawing.Size(98, 14);
            this.lbExecuteUntil.TabIndex = 34;
            this.lbExecuteUntil.Text = "Izvršavaj do:";
            // 
            // tbExecuteUntil
            // 
            this.tbExecuteUntil.Location = new System.Drawing.Point(6, 424);
            this.tbExecuteUntil.MaxLength = 4;
            this.tbExecuteUntil.Name = "tbExecuteUntil";
            this.tbExecuteUntil.PlaceholderText = "HEX";
            this.tbExecuteUntil.Size = new System.Drawing.Size(40, 22);
            this.tbExecuteUntil.TabIndex = 33;
            this.tbExecuteUntil.TabStop = false;
            // 
            // lbMemory
            // 
            this.lbMemory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbMemory.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbMemory.FormattingEnabled = true;
            this.lbMemory.ItemHeight = 14;
            this.lbMemory.Location = new System.Drawing.Point(584, 27);
            this.lbMemory.Name = "lbMemory";
            this.lbMemory.Size = new System.Drawing.Size(300, 450);
            this.lbMemory.TabIndex = 10;
            this.lbMemory.TabStop = false;
            this.lbMemory.DoubleClick += new System.EventHandler(this.lbMemory_DoubleClick);
            // 
            // lbInstructions
            // 
            this.lbInstructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbInstructions.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbInstructions.FormattingEnabled = true;
            this.lbInstructions.ItemHeight = 14;
            this.lbInstructions.Location = new System.Drawing.Point(278, 27);
            this.lbInstructions.Name = "lbInstructions";
            this.lbInstructions.Size = new System.Drawing.Size(300, 450);
            this.lbInstructions.TabIndex = 31;
            this.lbInstructions.TabStop = false;
            this.lbInstructions.DoubleClick += new System.EventHandler(this.lbInstructions_DoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 481);
            this.Controls.Add(this.lbInstructions);
            this.Controls.Add(this.groupOptions);
            this.Controls.Add(this.lbMemory);
            this.Controls.Add(this.lbRegisters);
            this.Controls.Add(this.msTools);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.msTools;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Emulator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
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
        private ToolStripMenuItem msLoad;
        private ToolStripMenuItem msReload;
        private ToolStripMenuItem msSave;
        private ToolStripMenuItem msSaveAs;
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
        private Label lbExecuteUntil;
        private TextBox tbExecuteUntil;
        private Button btnExecuteUntil;
        private Button btnStopExec;
        private Label lbInterrupt;
    }
}