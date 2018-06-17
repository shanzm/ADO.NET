namespace _07实现下拉列表选取省市
{
    partial class MainFrm
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
            this.cbxProvince = new System.Windows.Forms.ComboBox();
            this.cbxCity = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxProvince
            // 
            this.cbxProvince.FormattingEnabled = true;
            this.cbxProvince.Location = new System.Drawing.Point(94, 35);
            this.cbxProvince.Name = "cbxProvince";
            this.cbxProvince.Size = new System.Drawing.Size(121, 20);
            this.cbxProvince.TabIndex = 0;
            this.cbxProvince.SelectedIndexChanged += new System.EventHandler(this.cbxProvince_SelectedIndexChanged);
            // 
            // cbxCity
            // 
            this.cbxCity.FormattingEnabled = true;
            this.cbxCity.Location = new System.Drawing.Point(341, 35);
            this.cbxCity.Name = "cbxCity";
            this.cbxCity.Size = new System.Drawing.Size(121, 20);
            this.cbxCity.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbxProvince);
            this.groupBox1.Controls.Add(this.cbxCity);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(606, 88);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选取省市";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(309, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "市";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "省";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(222, 166);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "导出数据";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "从数据库选择数据保存到本地";
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 262);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainFrm";
            this.Text = "选择省市";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxProvince;
        private System.Windows.Forms.ComboBox cbxCity;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label label3;
    }
}

