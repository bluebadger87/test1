namespace _31_Linq
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
            this.dgEnemyTable = new System.Windows.Forms.DataGridView();
            this.btnLevel = new System.Windows.Forms.Button();
            this.btnName = new System.Windows.Forms.Button();
            this.btnAttribute = new System.Windows.Forms.Button();
            this.cboxAttribute = new System.Windows.Forms.ComboBox();
            this.nLevelMin = new System.Windows.Forms.NumericUpDown();
            this.nLevelMax = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgEnemyTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nLevelMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nLevelMax)).BeginInit();
            this.SuspendLayout();
            // 
            // dgEnemyTable
            // 
            this.dgEnemyTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEnemyTable.Location = new System.Drawing.Point(14, 13);
            this.dgEnemyTable.Name = "dgEnemyTable";
            this.dgEnemyTable.RowTemplate.Height = 23;
            this.dgEnemyTable.Size = new System.Drawing.Size(406, 284);
            this.dgEnemyTable.TabIndex = 0;
            // 
            // btnLevel
            // 
            this.btnLevel.Location = new System.Drawing.Point(426, 13);
            this.btnLevel.Name = "btnLevel";
            this.btnLevel.Size = new System.Drawing.Size(157, 28);
            this.btnLevel.TabIndex = 1;
            this.btnLevel.Text = "Level 순으로";
            this.btnLevel.UseVisualStyleBackColor = true;
            this.btnLevel.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // btnName
            // 
            this.btnName.Location = new System.Drawing.Point(426, 48);
            this.btnName.Name = "btnName";
            this.btnName.Size = new System.Drawing.Size(157, 28);
            this.btnName.TabIndex = 2;
            this.btnName.Text = "Name 순으로";
            this.btnName.UseVisualStyleBackColor = true;
            this.btnName.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // btnAttribute
            // 
            this.btnAttribute.Location = new System.Drawing.Point(426, 82);
            this.btnAttribute.Name = "btnAttribute";
            this.btnAttribute.Size = new System.Drawing.Size(157, 28);
            this.btnAttribute.TabIndex = 3;
            this.btnAttribute.Text = "속성 순으로";
            this.btnAttribute.UseVisualStyleBackColor = true;
            this.btnAttribute.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // cboxAttribute
            // 
            this.cboxAttribute.FormattingEnabled = true;
            this.cboxAttribute.Location = new System.Drawing.Point(426, 157);
            this.cboxAttribute.Name = "cboxAttribute";
            this.cboxAttribute.Size = new System.Drawing.Size(156, 21);
            this.cboxAttribute.TabIndex = 4;
            // 
            // nLevelMin
            // 
            this.nLevelMin.Location = new System.Drawing.Point(426, 194);
            this.nLevelMin.Name = "nLevelMin";
            this.nLevelMin.Size = new System.Drawing.Size(56, 22);
            this.nLevelMin.TabIndex = 5;
            this.nLevelMin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nLevelMax
            // 
            this.nLevelMax.Location = new System.Drawing.Point(527, 194);
            this.nLevelMax.Name = "nLevelMax";
            this.nLevelMax.Size = new System.Drawing.Size(56, 22);
            this.nLevelMax.TabIndex = 6;
            this.nLevelMax.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(497, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "~";
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(426, 234);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(157, 28);
            this.btnFilter.TabIndex = 8;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(426, 269);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(157, 28);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 308);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nLevelMax);
            this.Controls.Add(this.nLevelMin);
            this.Controls.Add(this.cboxAttribute);
            this.Controls.Add(this.btnAttribute);
            this.Controls.Add(this.btnName);
            this.Controls.Add(this.btnLevel);
            this.Controls.Add(this.dgEnemyTable);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgEnemyTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nLevelMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nLevelMax)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgEnemyTable;
        private System.Windows.Forms.Button btnLevel;
        private System.Windows.Forms.Button btnName;
        private System.Windows.Forms.Button btnAttribute;
        private System.Windows.Forms.ComboBox cboxAttribute;
        private System.Windows.Forms.NumericUpDown nLevelMin;
        private System.Windows.Forms.NumericUpDown nLevelMax;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnCancel;
    }
}

