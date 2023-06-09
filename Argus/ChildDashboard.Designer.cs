namespace Argus
{
    partial class ChildDashboard
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.diskChart = new LiveCharts.WinForms.CartesianChart();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.memoryChart = new LiveCharts.WinForms.CartesianChart();
            this.CpuPannel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cpuChart = new LiveCharts.WinForms.CartesianChart();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.CpuPannel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.diskChart);
            this.panel3.Location = new System.Drawing.Point(22, 559);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1392, 240);
            this.panel3.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("한컴 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(8, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 31);
            this.label3.TabIndex = 4;
            this.label3.Text = "DISK";
            // 
            // diskChart
            // 
            this.diskChart.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.diskChart.BackColorTransparent = true;
            this.diskChart.ForeColor = System.Drawing.Color.Chocolate;
            this.diskChart.Location = new System.Drawing.Point(14, 61);
            this.diskChart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.diskChart.Name = "diskChart";
            this.diskChart.Size = new System.Drawing.Size(1349, 162);
            this.diskChart.TabIndex = 3;
            this.diskChart.Text = "diskChart";
            this.diskChart.UseWaitCursor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.memoryChart);
            this.panel2.Location = new System.Drawing.Point(22, 290);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1392, 240);
            this.panel2.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("한컴 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(8, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "MEM";
            // 
            // memoryChart
            // 
            this.memoryChart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.memoryChart.BackColorTransparent = true;
            this.memoryChart.ForeColor = System.Drawing.Color.Chocolate;
            this.memoryChart.Location = new System.Drawing.Point(14, 62);
            this.memoryChart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.memoryChart.Name = "memoryChart";
            this.memoryChart.Size = new System.Drawing.Size(1349, 162);
            this.memoryChart.TabIndex = 2;
            this.memoryChart.Text = "memoryChart";
            // 
            // CpuPannel
            // 
            this.CpuPannel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.CpuPannel.Controls.Add(this.label1);
            this.CpuPannel.Controls.Add(this.cpuChart);
            this.CpuPannel.Location = new System.Drawing.Point(22, 22);
            this.CpuPannel.Name = "CpuPannel";
            this.CpuPannel.Size = new System.Drawing.Size(1392, 240);
            this.CpuPannel.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("한컴 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(8, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "CPU";
            // 
            // cpuChart
            // 
            this.cpuChart.BackColor = System.Drawing.Color.Black;
            this.cpuChart.BackColorTransparent = true;
            this.cpuChart.ForeColor = System.Drawing.Color.Chocolate;
            this.cpuChart.Location = new System.Drawing.Point(14, 62);
            this.cpuChart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cpuChart.Name = "cpuChart";
            this.cpuChart.Size = new System.Drawing.Size(1349, 162);
            this.cpuChart.TabIndex = 1;
            this.cpuChart.Text = "cpuChart";
            // 
            // ChildDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(1439, 820);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.CpuPannel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ChildDashboard";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChildDashboard_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ChildDashboard_FormClosed);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.CpuPannel.ResumeLayout(false);
            this.CpuPannel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private LiveCharts.WinForms.CartesianChart diskChart;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private LiveCharts.WinForms.CartesianChart memoryChart;
        private System.Windows.Forms.Panel CpuPannel;
        private System.Windows.Forms.Label label1;
        private LiveCharts.WinForms.CartesianChart cpuChart;
    }
}