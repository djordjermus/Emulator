namespace EmulatorGui
{
    partial class ValueEditForm
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
            this.tbValue = new System.Windows.Forms.TextBox();
            this.cbBase = new System.Windows.Forms.ComboBox();
            this.btnSet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbValue
            // 
            this.tbValue.Location = new System.Drawing.Point(78, 12);
            this.tbValue.MaxLength = 16;
            this.tbValue.Name = "tbValue";
            this.tbValue.Size = new System.Drawing.Size(120, 22);
            this.tbValue.TabIndex = 0;
            this.tbValue.Text = "0000000000000000";
            // 
            // cbBase
            // 
            this.cbBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBase.FormattingEnabled = true;
            this.cbBase.Items.AddRange(new object[] {
            "bin",
            "hex",
            "dec"});
            this.cbBase.Location = new System.Drawing.Point(12, 12);
            this.cbBase.Name = "cbBase";
            this.cbBase.Size = new System.Drawing.Size(60, 22);
            this.cbBase.TabIndex = 1;
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(204, 12);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(68, 23);
            this.btnSet.TabIndex = 3;
            this.btnSet.Text = "upiši";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // ValueEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 46);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.cbBase);
            this.Controls.Add(this.tbValue);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ValueEditForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Izmeni vrednost";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ViewEditForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox tbValue;
        private ComboBox cbBase;
        private Button btnSet;
    }
}