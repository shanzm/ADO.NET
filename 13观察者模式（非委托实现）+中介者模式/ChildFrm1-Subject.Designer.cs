namespace _13观察者模式_非委托实现__中介者模式
{
    partial class ChildFrm1_Subject
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnMessage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMessage
            // 
            this.btnMessage.Location = new System.Drawing.Point(101, 63);
            this.btnMessage.Name = "btnMessage";
            this.btnMessage.Size = new System.Drawing.Size(75, 23);
            this.btnMessage.TabIndex = 0;
            this.btnMessage.Text = "发布消息";
            this.btnMessage.UseVisualStyleBackColor = true;
            this.btnMessage.Click += new System.EventHandler(this.btnMessage_Click);
            // 
            // ChildFrm1_Subject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnMessage);
            this.Name = "ChildFrm1_Subject";
            this.Text = "ChildFrm1_Subject";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMessage;
    }
}