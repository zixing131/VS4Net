namespace VS4Net
{
    partial class MainForm
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
            this.checkedListBoxVersion = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxMsg = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkedListBoxVersion
            // 
            this.checkedListBoxVersion.FormattingEnabled = true;
            this.checkedListBoxVersion.Items.AddRange(new object[] {
            ".Net Framework 4.0",
            ".Net Framework 4.5",
            ".Net Framework 4.5.1",
            ".Net Framework 4.5.2"});
            this.checkedListBoxVersion.Location = new System.Drawing.Point(126, 22);
            this.checkedListBoxVersion.Name = "checkedListBoxVersion";
            this.checkedListBoxVersion.Size = new System.Drawing.Size(248, 84);
            this.checkedListBoxVersion.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Version:";
            // 
            // textBoxMsg
            // 
            this.textBoxMsg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBoxMsg.Location = new System.Drawing.Point(0, 153);
            this.textBoxMsg.Multiline = true;
            this.textBoxMsg.Name = "textBoxMsg";
            this.textBoxMsg.ReadOnly = true;
            this.textBoxMsg.Size = new System.Drawing.Size(454, 254);
            this.textBoxMsg.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Output Info:";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(329, 119);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 3;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 407);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.textBoxMsg);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkedListBoxVersion);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VS4Net";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBoxVersion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxMsg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonStart;
    }
}

