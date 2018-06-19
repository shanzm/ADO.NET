namespace _09输错三次密码锁死15分钟
{
    partial class LogInFrm
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
            this.btnSignIN = new System.Windows.Forms.Button();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPsw = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPwd = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSignIN
            // 
            this.btnSignIN.Location = new System.Drawing.Point(97, 193);
            this.btnSignIN.Name = "btnSignIN";
            this.btnSignIN.Size = new System.Drawing.Size(75, 23);
            this.btnSignIN.TabIndex = 0;
            this.btnSignIN.Text = "登录";
            this.btnSignIN.UseVisualStyleBackColor = true;
            this.btnSignIN.Click += new System.EventHandler(this.btnSignIN_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(132, 38);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 21);
            this.txtUserName.TabIndex = 1;
            // 
            // txtPsw
            // 
            this.txtPsw.Location = new System.Drawing.Point(132, 90);
            this.txtPsw.Name = "txtPsw";
            this.txtPsw.Size = new System.Drawing.Size(100, 21);
            this.txtPsw.TabIndex = 2;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(58, 46);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(41, 12);
            this.lblUserName.TabIndex = 3;
            this.lblUserName.Text = "用户名";
            // 
            // lblPwd
            // 
            this.lblPwd.AutoSize = true;
            this.lblPwd.Location = new System.Drawing.Point(60, 98);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(29, 12);
            this.lblPwd.TabIndex = 4;
            this.lblPwd.Text = "密码";
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.lblPwd);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.txtPsw);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.btnSignIN);
            this.Name = "MainFrm";
            this.Text = "Form1";
            this.Activated += new System.EventHandler(this.MainFrm_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSignIN;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPsw;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPwd;
    }
}

