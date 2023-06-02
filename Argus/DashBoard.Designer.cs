namespace Argus
{
    partial class DashBoard
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashBoard));
            this.cpuChart = new LiveCharts.WinForms.CartesianChart();
            this.memoryChart = new LiveCharts.WinForms.CartesianChart();
            this.diskChart = new LiveCharts.WinForms.CartesianChart();
            this.CpuPannel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCPU = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonMEM = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonDISK = new System.Windows.Forms.Button();
            this.CpuPannel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
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
            // CpuPannel
            // 
            this.CpuPannel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.CpuPannel.Controls.Add(this.label1);
            this.CpuPannel.Controls.Add(this.cpuChart);
            this.CpuPannel.Controls.Add(this.buttonCPU);
            this.CpuPannel.Location = new System.Drawing.Point(26, 31);
            this.CpuPannel.Name = "CpuPannel";
            this.CpuPannel.Size = new System.Drawing.Size(1392, 240);
            this.CpuPannel.TabIndex = 7;
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
            // buttonCPU
            // 
            this.buttonCPU.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonCPU.BackgroundImage")));
            this.buttonCPU.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonCPU.Location = new System.Drawing.Point(1352, 0);
            this.buttonCPU.Name = "buttonCPU";
            this.buttonCPU.Size = new System.Drawing.Size(40, 40);
            this.buttonCPU.TabIndex = 7;
            this.buttonCPU.UseVisualStyleBackColor = true;
            this.buttonCPU.Click += new System.EventHandler(this.Button_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.memoryChart);
            this.panel2.Controls.Add(this.buttonMEM);
            this.panel2.Location = new System.Drawing.Point(26, 296);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1392, 240);
            this.panel2.TabIndex = 8;
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
            // buttonMEM
            // 
            this.buttonMEM.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonMEM.BackgroundImage")));
            this.buttonMEM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonMEM.Location = new System.Drawing.Point(1352, 0);
            this.buttonMEM.Name = "buttonMEM";
            this.buttonMEM.Size = new System.Drawing.Size(40, 40);
            this.buttonMEM.TabIndex = 8;
            this.buttonMEM.UseVisualStyleBackColor = true;
            this.buttonMEM.Click += new System.EventHandler(this.Button_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.diskChart);
            this.panel3.Controls.Add(this.buttonDISK);
            this.panel3.Location = new System.Drawing.Point(26, 565);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1392, 240);
            this.panel3.TabIndex = 9;
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
            // buttonDISK
            // 
            this.buttonDISK.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonDISK.BackgroundImage")));
            this.buttonDISK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonDISK.Location = new System.Drawing.Point(1352, 0);
            this.buttonDISK.Name = "buttonDISK";
            this.buttonDISK.Size = new System.Drawing.Size(40, 40);
            this.buttonDISK.TabIndex = 9;
            this.buttonDISK.UseVisualStyleBackColor = true;
            this.buttonDISK.Click += new System.EventHandler(this.Button_Click);
            // 
            // DashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(1440, 829);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.CpuPannel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DashBoard";
            this.Text = "Argus";
            this.Load += new System.EventHandler(this.DashBoard_Load);
            this.CpuPannel.ResumeLayout(false);
            this.CpuPannel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private LiveCharts.WinForms.CartesianChart cpuChart;
        private LiveCharts.WinForms.CartesianChart memoryChart;
        private LiveCharts.WinForms.CartesianChart diskChart;
        private System.Windows.Forms.Panel CpuPannel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonCPU;
        private System.Windows.Forms.Button buttonMEM;
        private System.Windows.Forms.Button buttonDISK;
    }
}

