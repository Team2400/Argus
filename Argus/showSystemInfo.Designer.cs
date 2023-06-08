namespace Argus
{
    partial class showSystemInfo
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
            this.label1 = new System.Windows.Forms.Label();
            this.osLabel = new System.Windows.Forms.Label();
            this.modelLabel = new System.Windows.Forms.Label();
            this.freqLabel = new System.Windows.Forms.Label();
            this.coreLabel = new System.Windows.Forms.Label();
            this.threadLabel = new System.Windows.Forms.Label();
            this.memLabel = new System.Windows.Forms.Label();
            this.diskLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "System Info";
            // 
            // osLabel
            // 
            this.osLabel.AutoSize = true;
            this.osLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.osLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.osLabel.Location = new System.Drawing.Point(14, 39);
            this.osLabel.Name = "osLabel";
            this.osLabel.Size = new System.Drawing.Size(30, 15);
            this.osLabel.TabIndex = 1;
            this.osLabel.Text = "OS: ";
            // 
            // modelLabel
            // 
            this.modelLabel.AutoSize = true;
            this.modelLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.modelLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.modelLabel.Location = new System.Drawing.Point(14, 60);
            this.modelLabel.Name = "modelLabel";
            this.modelLabel.Size = new System.Drawing.Size(75, 15);
            this.modelLabel.TabIndex = 2;
            this.modelLabel.Text = "CPU model: ";
            // 
            // freqLabel
            // 
            this.freqLabel.AutoSize = true;
            this.freqLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.freqLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.freqLabel.Location = new System.Drawing.Point(14, 85);
            this.freqLabel.Name = "freqLabel";
            this.freqLabel.Size = new System.Drawing.Size(94, 15);
            this.freqLabel.TabIndex = 3;
            this.freqLabel.Text = "CPU frequency: ";
            // 
            // coreLabel
            // 
            this.coreLabel.AutoSize = true;
            this.coreLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.coreLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.coreLabel.Location = new System.Drawing.Point(14, 106);
            this.coreLabel.Name = "coreLabel";
            this.coreLabel.Size = new System.Drawing.Size(64, 15);
            this.coreLabel.TabIndex = 4;
            this.coreLabel.Text = "CPU core: ";
            // 
            // threadLabel
            // 
            this.threadLabel.AutoSize = true;
            this.threadLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.threadLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.threadLabel.Location = new System.Drawing.Point(14, 130);
            this.threadLabel.Name = "threadLabel";
            this.threadLabel.Size = new System.Drawing.Size(75, 15);
            this.threadLabel.TabIndex = 5;
            this.threadLabel.Text = "CPU thread: ";
            // 
            // memLabel
            // 
            this.memLabel.AutoSize = true;
            this.memLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.memLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.memLabel.Location = new System.Drawing.Point(14, 151);
            this.memLabel.Name = "memLabel";
            this.memLabel.Size = new System.Drawing.Size(59, 15);
            this.memLabel.TabIndex = 6;
            this.memLabel.Text = "Memory: ";
            // 
            // diskLabel
            // 
            this.diskLabel.AutoSize = true;
            this.diskLabel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.diskLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.diskLabel.Location = new System.Drawing.Point(14, 172);
            this.diskLabel.Name = "diskLabel";
            this.diskLabel.Size = new System.Drawing.Size(37, 15);
            this.diskLabel.TabIndex = 7;
            this.diskLabel.Text = "Disk: ";
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.White;
            this.closeButton.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.closeButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.closeButton.Location = new System.Drawing.Point(328, 198);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 8;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // showSystemInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(415, 233);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.diskLabel);
            this.Controls.Add(this.memLabel);
            this.Controls.Add(this.threadLabel);
            this.Controls.Add(this.coreLabel);
            this.Controls.Add(this.freqLabel);
            this.Controls.Add(this.modelLabel);
            this.Controls.Add(this.osLabel);
            this.Controls.Add(this.label1);
            this.Name = "showSystemInfo";
            this.Text = "System Info";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label osLabel;
        private System.Windows.Forms.Label modelLabel;
        private System.Windows.Forms.Label freqLabel;
        private System.Windows.Forms.Label coreLabel;
        private System.Windows.Forms.Label threadLabel;
        private System.Windows.Forms.Label memLabel;
        private System.Windows.Forms.Label diskLabel;
        private System.Windows.Forms.Button closeButton;
    }
}