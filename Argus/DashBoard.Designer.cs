﻿using System.Threading;

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
            this.Infobutton = new System.Windows.Forms.Button();
            this.connectButton = new System.Windows.Forms.Button();
       
            this.cpuChart = new LiveCharts.WinForms.CartesianChart();
            this.memoryChart = new LiveCharts.WinForms.CartesianChart();
            this.diskChart = new LiveCharts.WinForms.CartesianChart();
            this.CpuPannel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();

            this.ModeBtn = new System.Windows.Forms.Button();
            this.AlertCpu = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.AlertMem = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.AlertDisk = new System.Windows.Forms.Button();
            this.CpuPannel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Infobutton
            // 
            this.Infobutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Infobutton.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.Infobutton.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Infobutton.Location = new System.Drawing.Point(215, 21);
            this.Infobutton.Name = "Infobutton";
            this.Infobutton.Size = new System.Drawing.Size(229, 41);
            this.Infobutton.TabIndex = 8;
            this.Infobutton.Text = "Show System Info";
            this.Infobutton.UseVisualStyleBackColor = false;
            this.Infobutton.Click += new System.EventHandler(this.Infobutton_Click);
            // 
            // connectButton
            // 
            this.connectButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.connectButton.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.connectButton.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.connectButton.Location = new System.Drawing.Point(25, 21);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(163, 41);
            this.connectButton.TabIndex = 9;
            this.connectButton.Text = "Connect to Remote PC";
            this.connectButton.UseVisualStyleBackColor = false;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
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
            this.CpuPannel.Location = new System.Drawing.Point(25, 82);
            this.CpuPannel.Controls.Add(this.AlertCpu);
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
            // AlertCpu
            // 
            this.AlertCpu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AlertCpu.BackgroundImage")));
            this.AlertCpu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AlertCpu.Location = new System.Drawing.Point(1352, 0);
            this.AlertCpu.Name = "AlertCpu";
            this.AlertCpu.Size = new System.Drawing.Size(40, 40);
            this.AlertCpu.TabIndex = 7;
            this.AlertCpu.UseVisualStyleBackColor = true;
            this.AlertCpu.Click += new System.EventHandler(this.Button_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.memoryChart);
            this.panel2.Location = new System.Drawing.Point(25, 350);
            this.panel2.Controls.Add(this.AlertMem);
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
            // AlertMem
            // 
            this.AlertMem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AlertMem.BackgroundImage")));
            this.AlertMem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AlertMem.Location = new System.Drawing.Point(1352, 0);
            this.AlertMem.Name = "AlertMem";
            this.AlertMem.Size = new System.Drawing.Size(40, 40);
            this.AlertMem.TabIndex = 8;
            this.AlertMem.UseVisualStyleBackColor = true;
            this.AlertMem.Click += new System.EventHandler(this.Button_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.diskChart);
            this.panel3.Location = new System.Drawing.Point(25, 619);
            this.panel3.Controls.Add(this.AlertDisk);
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
            // ModeBtn
            // 
            this.ModeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ModeBtn.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.ModeBtn.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.ModeBtn.Location = new System.Drawing.Point(470, 21);
            this.ModeBtn.Name = "ModeBtn";
            this.ModeBtn.Size = new System.Drawing.Size(134, 41);
            this.ModeBtn.TabIndex = 10;
            this.ModeBtn.Text = "Mode";
            this.ModeBtn.UseVisualStyleBackColor = false;
            this.ModeBtn.Click += new System.EventHandler(this.ModeBtn_Click);
            //
            // AlertDisk
            // 
            this.AlertDisk.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AlertDisk.BackgroundImage")));
            this.AlertDisk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AlertDisk.Location = new System.Drawing.Point(1352, 0);
            this.AlertDisk.Name = "AlertDisk";
            this.AlertDisk.Size = new System.Drawing.Size(40, 40);
            this.AlertDisk.TabIndex = 9;
            this.AlertDisk.UseVisualStyleBackColor = true;
            this.AlertDisk.Click += new System.EventHandler(this.Button_Click);
            // 
            // DashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(1440, 873);
            this.Controls.Add(this.ModeBtn);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.CpuPannel);
            this.Controls.Add(this.Infobutton);
            this.Controls.Add(this.connectButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DashBoard";
            this.Text = "Argus";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DashBoard_FormClosed);
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
        private System.Windows.Forms.Button Infobutton;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button ModeBtn;
        private System.Windows.Forms.Button AlertCpu;
        private System.Windows.Forms.Button AlertMem;
        private System.Windows.Forms.Button AlertDisk;
    }
}

