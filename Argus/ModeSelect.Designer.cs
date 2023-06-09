namespace Argus
{
    partial class ModeSelect
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
            this.rdoSec = new System.Windows.Forms.RadioButton();
            this.ModeGrb = new System.Windows.Forms.GroupBox();
            this.rdoMin = new System.Windows.Forms.RadioButton();
            this.rdoHour = new System.Windows.Forms.RadioButton();
            this.connectButton = new System.Windows.Forms.Button();
            this.ModeGrb.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdoSec
            // 
            this.rdoSec.AutoSize = true;
            this.rdoSec.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.rdoSec.Location = new System.Drawing.Point(20, 42);
            this.rdoSec.Name = "rdoSec";
            this.rdoSec.Size = new System.Drawing.Size(105, 22);
            this.rdoSec.TabIndex = 0;
            this.rdoSec.TabStop = true;
            this.rdoSec.Text = "Seconds";
            this.rdoSec.UseVisualStyleBackColor = true;
            // 
            // ModeGrb
            // 
            this.ModeGrb.Controls.Add(this.rdoHour);
            this.ModeGrb.Controls.Add(this.rdoMin);
            this.ModeGrb.Controls.Add(this.rdoSec);
            this.ModeGrb.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ModeGrb.Location = new System.Drawing.Point(12, 21);
            this.ModeGrb.Name = "ModeGrb";
            this.ModeGrb.Size = new System.Drawing.Size(340, 172);
            this.ModeGrb.TabIndex = 1;
            this.ModeGrb.TabStop = false;
            this.ModeGrb.Text = "Modes";
            // 
            // rdoMin
            // 
            this.rdoMin.AutoSize = true;
            this.rdoMin.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.rdoMin.Location = new System.Drawing.Point(20, 81);
            this.rdoMin.Name = "rdoMin";
            this.rdoMin.Size = new System.Drawing.Size(96, 22);
            this.rdoMin.TabIndex = 1;
            this.rdoMin.TabStop = true;
            this.rdoMin.Text = "Minutes";
            this.rdoMin.UseVisualStyleBackColor = true;
            // 
            // rdoHour
            // 
            this.rdoHour.AutoSize = true;
            this.rdoHour.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.rdoHour.Location = new System.Drawing.Point(20, 118);
            this.rdoHour.Name = "rdoHour";
            this.rdoHour.Size = new System.Drawing.Size(81, 22);
            this.rdoHour.TabIndex = 2;
            this.rdoHour.TabStop = true;
            this.rdoHour.Text = "Hours";
            this.rdoHour.UseVisualStyleBackColor = true;
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(245, 222);
            this.connectButton.Margin = new System.Windows.Forms.Padding(4);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(107, 34);
            this.connectButton.TabIndex = 4;
            this.connectButton.Text = "Apply";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // ModeSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(366, 269);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.ModeGrb);
            this.Name = "ModeSelect";
            this.Text = "ModeSelect";
            this.ModeGrb.ResumeLayout(false);
            this.ModeGrb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoSec;
        private System.Windows.Forms.GroupBox ModeGrb;
        private System.Windows.Forms.RadioButton rdoHour;
        private System.Windows.Forms.RadioButton rdoMin;
        private System.Windows.Forms.Button connectButton;
    }
}