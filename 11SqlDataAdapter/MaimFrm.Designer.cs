namespace _11SqlDataAdapter
{
    partial class MaimFrm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvUserInfo1 = new System.Windows.Forms.DataGridView();
            this.dgvUserInfo2 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserPwd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastErrorDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ErrorTimes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvUserInfo3 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserInfo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserInfo2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserInfo3)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUserInfo1
            // 
            this.dgvUserInfo1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserInfo1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.UserName,
            this.UserPwd,
            this.LastErrorDateTime,
            this.ErrorTimes});
            this.dgvUserInfo1.Location = new System.Drawing.Point(12, 28);
            this.dgvUserInfo1.Name = "dgvUserInfo1";
            this.dgvUserInfo1.RowTemplate.Height = 23;
            this.dgvUserInfo1.Size = new System.Drawing.Size(549, 150);
            this.dgvUserInfo1.TabIndex = 0;
            // 
            // dgvUserInfo2
            // 
            this.dgvUserInfo2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserInfo2.Location = new System.Drawing.Point(613, 28);
            this.dgvUserInfo2.Name = "dgvUserInfo2";
            this.dgvUserInfo2.RowTemplate.Height = 23;
            this.dgvUserInfo2.Size = new System.Drawing.Size(549, 150);
            this.dgvUserInfo2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "数据源是DataTable";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(611, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "数据源是List";
            // 
            // ID
            // 
            this.ID.DataPropertyName = "Id";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "UserName";
            this.UserName.HeaderText = "用户名";
            this.UserName.Name = "UserName";
            // 
            // UserPwd
            // 
            this.UserPwd.DataPropertyName = "UserPwd";
            this.UserPwd.HeaderText = "密码";
            this.UserPwd.Name = "UserPwd";
            // 
            // LastErrorDateTime
            // 
            this.LastErrorDateTime.DataPropertyName = "LastErrorDateTime";
            this.LastErrorDateTime.HeaderText = "最后错误时间";
            this.LastErrorDateTime.Name = "LastErrorDateTime";
            // 
            // ErrorTimes
            // 
            this.ErrorTimes.DataPropertyName = "ErrorTimes";
            this.ErrorTimes.HeaderText = "错误次数";
            this.ErrorTimes.Name = "ErrorTimes";
            // 
            // dgvUserInfo3
            // 
            this.dgvUserInfo3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserInfo3.Location = new System.Drawing.Point(12, 263);
            this.dgvUserInfo3.Name = "dgvUserInfo3";
            this.dgvUserInfo3.RowTemplate.Height = 23;
            this.dgvUserInfo3.Size = new System.Drawing.Size(549, 150);
            this.dgvUserInfo3.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "数据源是DataSet中的Table1\r\n";
            // 
            // MaimFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 451);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvUserInfo3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvUserInfo2);
            this.Controls.Add(this.dgvUserInfo1);
            this.Name = "MaimFrm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserInfo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserInfo2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserInfo3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUserInfo1;
        private System.Windows.Forms.DataGridView dgvUserInfo2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserPwd;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastErrorDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ErrorTimes;
        private System.Windows.Forms.DataGridView dgvUserInfo3;
        private System.Windows.Forms.Label label3;
    }
}

