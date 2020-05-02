namespace _05用户注册
{
    partial class SignUPFrm
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
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPsw = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPsw = new System.Windows.Forms.Label();
            this.btnSignIN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(135, 40);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 21);
            this.txtUserName.TabIndex = 0;
            // 
            // txtPsw
            // 
            this.txtPsw.Location = new System.Drawing.Point(135, 90);
            this.txtPsw.Name = "txtPsw";
            this.txtPsw.Size = new System.Drawing.Size(100, 21);
            this.txtPsw.TabIndex = 1;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(74, 43);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(41, 12);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "用户名";
            // 
            // lblPsw
            // 
            this.lblPsw.AutoSize = true;
            this.lblPsw.Location = new System.Drawing.Point(74, 93);
            this.lblPsw.Name = "lblPsw";
            this.lblPsw.Size = new System.Drawing.Size(29, 12);
            this.lblPsw.TabIndex = 3;
            this.lblPsw.Text = "密码";
            // 
            // btnSignIN
            // 
            this.btnSignIN.Location = new System.Drawing.Point(76, 152);
            this.btnSignIN.Name = "btnSignIN";
            this.btnSignIN.Size = new System.Drawing.Size(75, 23);
            this.btnSignIN.TabIndex = 4;
            this.btnSignIN.Text = "注册";
            this.btnSignIN.UseVisualStyleBackColor = true;
            this.btnSignIN.Click += new System.EventHandler(this.btnSignIN_Click);
            // 
            // SignUPFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnSignIN);
            this.Controls.Add(this.lblPsw);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.txtPsw);
            this.Controls.Add(this.txtUserName);
            this.Name = "SignUPFrm";
            this.Text = "用户注册";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPsw;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPsw;
        private System.Windows.Forms.Button btnSignIN;
    }
}

