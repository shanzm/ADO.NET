namespace _03SqlConnectionStringBuilder
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
            this.btnGetConnString = new System.Windows.Forms.Button();
            this.txtString = new System.Windows.Forms.ListBox();
            this.propGrid4ConnString = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // btnGetConnString
            // 
            this.btnGetConnString.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetConnString.Location = new System.Drawing.Point(303, 292);
            this.btnGetConnString.Name = "btnGetConnString";
            this.btnGetConnString.Size = new System.Drawing.Size(102, 23);
            this.btnGetConnString.TabIndex = 0;
            this.btnGetConnString.Text = "生成连接字符串";
            this.btnGetConnString.UseVisualStyleBackColor = true;
            this.btnGetConnString.Click += new System.EventHandler(this.btnGetConnString_Click);
            // 
            // txtString
            // 
            this.txtString.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtString.FormattingEnabled = true;
            this.txtString.ItemHeight = 12;
            this.txtString.Location = new System.Drawing.Point(256, 26);
            this.txtString.Name = "txtString";
            this.txtString.Size = new System.Drawing.Size(194, 220);
            this.txtString.TabIndex = 1;
            // 
            // propGrid4ConnString
            // 
            this.propGrid4ConnString.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.propGrid4ConnString.Location = new System.Drawing.Point(0, 1);
            this.propGrid4ConnString.Name = "propGrid4ConnString";
            this.propGrid4ConnString.Size = new System.Drawing.Size(238, 362);
            this.propGrid4ConnString.TabIndex = 2;
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 362);
            this.Controls.Add(this.propGrid4ConnString);
            this.Controls.Add(this.txtString);
            this.Controls.Add(this.btnGetConnString);
            this.Name = "MainFrm";
            this.Text = "生成链接字符串";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetConnString;
        private System.Windows.Forms.ListBox txtString;
        private System.Windows.Forms.PropertyGrid propGrid4ConnString;
    }
}

