﻿namespace Argus
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
            this.sadfasdfasdf = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // sadfasdfasdf
            // 
            this.sadfasdfasdf.AutoSize = true;
            this.sadfasdfasdf.Location = new System.Drawing.Point(599, 259);
            this.sadfasdfasdf.Name = "sadfasdfasdf";
            this.sadfasdfasdf.Size = new System.Drawing.Size(54, 18);
            this.sadfasdfasdf.TabIndex = 0;
            this.sadfasdfasdf.Text = "label1";
            this.sadfasdfasdf.Click += new System.EventHandler(this.test_Click);
            // 
            // DashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 675);
            this.Controls.Add(this.sadfasdfasdf);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DashBoard";
            this.Text = "Argus";
            this.Load += new System.EventHandler(this.DashBoard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label sadfasdfasdf;
    }
}

