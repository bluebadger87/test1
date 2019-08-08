namespace _35_Coding
{
    partial class Form1
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
            this.tboxBefore = new System.Windows.Forms.TextBox();
            this.tboxAfter = new System.Windows.Forms.TextBox();
            this.btnChange = new System.Windows.Forms.Button();
            this.dgChangedate = new System.Windows.Forms.DataGridView();
            this.cBefore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cAfter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgChangedate)).BeginInit();
            this.SuspendLayout();
            // 
            // tboxBefore
            // 
            this.tboxBefore.Location = new System.Drawing.Point(12, 62);
            this.tboxBefore.Multiline = true;
            this.tboxBefore.Name = "tboxBefore";
            this.tboxBefore.Size = new System.Drawing.Size(210, 164);
            this.tboxBefore.TabIndex = 0;
            this.tboxBefore.Text = "1. 개똥도 약에 쓸려면 없다\r\n2. 닭 쫓던 개 지붕 쳐다본다\r\n3. 꿩 대신 닭\r\n4. 고양이 한테 생선을 맡긴다\r\n5. 꿩 먹고 알 먹기";
            // 
            // tboxAfter
            // 
            this.tboxAfter.Location = new System.Drawing.Point(474, 62);
            this.tboxAfter.Multiline = true;
            this.tboxAfter.Name = "tboxAfter";
            this.tboxAfter.Size = new System.Drawing.Size(210, 164);
            this.tboxAfter.TabIndex = 1;
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(306, 12);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(90, 41);
            this.btnChange.TabIndex = 2;
            this.btnChange.Text = "변환";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // dgChangedate
            // 
            this.dgChangedate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgChangedate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cBefore,
            this.cAfter});
            this.dgChangedate.Location = new System.Drawing.Point(246, 62);
            this.dgChangedate.Name = "dgChangedate";
            this.dgChangedate.RowTemplate.Height = 23;
            this.dgChangedate.Size = new System.Drawing.Size(206, 163);
            this.dgChangedate.TabIndex = 3;
            // 
            // cBefore
            // 
            this.cBefore.HeaderText = "Before";
            this.cBefore.Name = "cBefore";
            this.cBefore.Width = 80;
            // 
            // cAfter
            // 
            this.cAfter.HeaderText = "After";
            this.cAfter.Name = "cAfter";
            this.cAfter.Width = 80;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 241);
            this.Controls.Add(this.dgChangedate);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.tboxAfter);
            this.Controls.Add(this.tboxBefore);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgChangedate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tboxBefore;
        private System.Windows.Forms.TextBox tboxAfter;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.DataGridView dgChangedate;
        private System.Windows.Forms.DataGridViewTextBoxColumn cBefore;
        private System.Windows.Forms.DataGridViewTextBoxColumn cAfter;
    }
}

