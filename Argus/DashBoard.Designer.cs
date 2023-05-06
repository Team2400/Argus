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
            this.label1 = new System.Windows.Forms.Label();
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.cartesianChart2 = new LiveCharts.WinForms.CartesianChart();
            this.cartesianChart3 = new LiveCharts.WinForms.CartesianChart();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(26, 27);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(955, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "CPU USAGE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.BackColor = System.Drawing.Color.Black;
            this.cartesianChart1.ForeColor = System.Drawing.Color.Chocolate;
            this.cartesianChart1.Location = new System.Drawing.Point(23, 55);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(960, 120);
            this.cartesianChart1.TabIndex = 1;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // cartesianChart2
            // 
            this.cartesianChart2.BackColor = System.Drawing.Color.Black;
            this.cartesianChart2.ForeColor = System.Drawing.Color.Chocolate;
            this.cartesianChart2.Location = new System.Drawing.Point(21, 225);
            this.cartesianChart2.Name = "cartesianChart2";
            this.cartesianChart2.Size = new System.Drawing.Size(960, 120);
            this.cartesianChart2.TabIndex = 2;
            this.cartesianChart2.Text = "cartesianChart2";
            // 
            // cartesianChart3
            // 
            this.cartesianChart3.BackColor = System.Drawing.Color.Black;
            this.cartesianChart3.ForeColor = System.Drawing.Color.Chocolate;
            this.cartesianChart3.Location = new System.Drawing.Point(21, 406);
            this.cartesianChart3.Name = "cartesianChart3";
            this.cartesianChart3.Size = new System.Drawing.Size(960, 120);
            this.cartesianChart3.TabIndex = 3;
            this.cartesianChart3.Text = "cartesianChart3";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(23, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(960, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "MEM USAGE";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(21, 380);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(960, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "DISK USAGE";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1015, 610);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cartesianChart3);
            this.Controls.Add(this.cartesianChart2);
            this.Controls.Add(this.cartesianChart1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DashBoard";
            this.Text = "Argus";
            this.Load += new System.EventHandler(this.DashBoard_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private LiveCharts.WinForms.CartesianChart cartesianChart2;
        private LiveCharts.WinForms.CartesianChart cartesianChart3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

