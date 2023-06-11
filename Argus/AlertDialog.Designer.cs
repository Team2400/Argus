namespace Argus
{
    partial class AlertDialog
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
            this.label2 = new System.Windows.Forms.Label();
            this.thresholdTxt = new System.Windows.Forms.TextBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.messageTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(76, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Threshold";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(34, 104);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Alert Message";
            // 
            // thresholdTxt
            // 
            this.thresholdTxt.Location = new System.Drawing.Point(200, 30);
            this.thresholdTxt.Margin = new System.Windows.Forms.Padding(4);
            this.thresholdTxt.Multiline = true;
            this.thresholdTxt.Name = "thresholdTxt";
            this.thresholdTxt.Size = new System.Drawing.Size(268, 31);
            this.thresholdTxt.TabIndex = 3;
            this.thresholdTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.thresholdTxt_KeyDown);
            this.thresholdTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.thresholdTxt_KeyPress);
            // 
            // buttonOk
            // 
            this.buttonOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.buttonOk.Location = new System.Drawing.Point(327, 259);
            this.buttonOk.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(141, 38);
            this.buttonOk.TabIndex = 5;
            this.buttonOk.Text = "apply";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // messageTxt
            // 
            this.messageTxt.Location = new System.Drawing.Point(200, 104);
            this.messageTxt.Multiline = true;
            this.messageTxt.Name = "messageTxt";
            this.messageTxt.Size = new System.Drawing.Size(268, 109);
            this.messageTxt.TabIndex = 6;
            // 
            // AlertDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(499, 324);
            this.Controls.Add(this.messageTxt);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.thresholdTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("굴림", 11F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AlertDialog";
            this.Text = "Alert";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox thresholdTxt;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.TextBox messageTxt;
    }
}