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
            this.cpuLabel = new System.Windows.Forms.Label();
            this.cpuChart = new LiveCharts.WinForms.CartesianChart();
            this.memoryChart = new LiveCharts.WinForms.CartesianChart();
            this.diskChart = new LiveCharts.WinForms.CartesianChart();
            this.memoryLabel = new System.Windows.Forms.Label();
            this.diskLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cpuLabel
            // 
            this.cpuLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(30)))));
            this.cpuLabel.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cpuLabel.ForeColor = System.Drawing.Color.White;
            this.cpuLabel.Location = new System.Drawing.Point(0, 0);
            this.cpuLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.cpuLabel.Name = "cpuLabel";
            this.cpuLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cpuLabel.Size = new System.Drawing.Size(1000, 20);
            this.cpuLabel.TabIndex = 4;
            this.cpuLabel.Text = "CPU USAGE";
            this.cpuLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cpuChart
            // 
            this.cpuChart.BackColor = System.Drawing.Color.Black;
            this.cpuChart.ForeColor = System.Drawing.Color.Chocolate;
            this.cpuChart.Location = new System.Drawing.Point(0, 21);
            this.cpuChart.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.cpuChart.Name = "cpuChart";
            this.cpuChart.Size = new System.Drawing.Size(1000, 100);
            this.cpuChart.TabIndex = 1;
            this.cpuChart.Text = "cpuChart";
            this.cpuChart.ChildChanged += new System.EventHandler<System.Windows.Forms.Integration.ChildChangedEventArgs>(this.cpuChart_ChildChanged);
            // 
            // memoryChart
            // 
            this.memoryChart.BackColor = System.Drawing.Color.Black;
            this.memoryChart.ForeColor = System.Drawing.Color.Chocolate;
            this.memoryChart.Location = new System.Drawing.Point(0, 143);
            this.memoryChart.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.memoryChart.Name = "memoryChart";
            this.memoryChart.Size = new System.Drawing.Size(1000, 100);
            this.memoryChart.TabIndex = 2;
            this.memoryChart.Text = "memoryChart";
            // 
            // diskChart
            // 
            this.diskChart.BackColor = System.Drawing.Color.Black;
            this.diskChart.ForeColor = System.Drawing.Color.Chocolate;
            this.diskChart.Location = new System.Drawing.Point(0, 265);
            this.diskChart.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.diskChart.Name = "diskChart";
            this.diskChart.Size = new System.Drawing.Size(1000, 100);
            this.diskChart.TabIndex = 3;
            this.diskChart.Text = "diskChart";
            // 
            // memoryLabel
            // 
            this.memoryLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(30)))));
            this.memoryLabel.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.memoryLabel.ForeColor = System.Drawing.Color.White;
            this.memoryLabel.Location = new System.Drawing.Point(0, 122);
            this.memoryLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.memoryLabel.Name = "memoryLabel";
            this.memoryLabel.Size = new System.Drawing.Size(1000, 20);
            this.memoryLabel.TabIndex = 5;
            this.memoryLabel.Text = "MEM USAGE";
            this.memoryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // diskLabel
            // 
            this.diskLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(30)))));
            this.diskLabel.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.diskLabel.ForeColor = System.Drawing.Color.White;
            this.diskLabel.Location = new System.Drawing.Point(0, 244);
            this.diskLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.diskLabel.Name = "diskLabel";
            this.diskLabel.Size = new System.Drawing.Size(1000, 20);
            this.diskLabel.TabIndex = 6;
            this.diskLabel.Text = "DISK USAGE";
            this.diskLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1001, 366);
            this.Controls.Add(this.cpuLabel);
            this.Controls.Add(this.diskLabel);
            this.Controls.Add(this.memoryLabel);
            this.Controls.Add(this.diskChart);
            this.Controls.Add(this.memoryChart);
            this.Controls.Add(this.cpuChart);
            this.Name = "DashBoard";
            this.Text = "Argus";
            this.Load += new System.EventHandler(this.DashBoard_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private LiveCharts.WinForms.CartesianChart cpuChart;
        private LiveCharts.WinForms.CartesianChart memoryChart;
        private LiveCharts.WinForms.CartesianChart diskChart;
        private System.Windows.Forms.Label cpuLabel;
        private System.Windows.Forms.Label memoryLabel;
        private System.Windows.Forms.Label diskLabel;
    }
}

