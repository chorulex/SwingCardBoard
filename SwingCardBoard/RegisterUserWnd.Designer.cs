namespace SwingCardBoard
{
    partial class RegisterUserWnd
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_userNameTxt = new System.Windows.Forms.TextBox();
            this.m_pwdTxt = new System.Windows.Forms.TextBox();
            this.m_pwdAuthTxt = new System.Windows.Forms.TextBox();
            this.m_okBtn = new System.Windows.Forms.Button();
            this.m_cancelBtn = new System.Windows.Forms.Button();
            this.m_tipLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "密  码：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "确认密码：";
            // 
            // m_userNameTxt
            // 
            this.m_userNameTxt.Location = new System.Drawing.Point(105, 29);
            this.m_userNameTxt.Name = "m_userNameTxt";
            this.m_userNameTxt.Size = new System.Drawing.Size(185, 21);
            this.m_userNameTxt.TabIndex = 3;
            // 
            // m_pwdTxt
            // 
            this.m_pwdTxt.Location = new System.Drawing.Point(105, 63);
            this.m_pwdTxt.Name = "m_pwdTxt";
            this.m_pwdTxt.PasswordChar = '*';
            this.m_pwdTxt.Size = new System.Drawing.Size(185, 21);
            this.m_pwdTxt.TabIndex = 4;
            // 
            // m_pwdAuthTxt
            // 
            this.m_pwdAuthTxt.Location = new System.Drawing.Point(105, 98);
            this.m_pwdAuthTxt.Name = "m_pwdAuthTxt";
            this.m_pwdAuthTxt.PasswordChar = '*';
            this.m_pwdAuthTxt.Size = new System.Drawing.Size(185, 21);
            this.m_pwdAuthTxt.TabIndex = 5;
            // 
            // m_okBtn
            // 
            this.m_okBtn.Location = new System.Drawing.Point(77, 163);
            this.m_okBtn.Name = "m_okBtn";
            this.m_okBtn.Size = new System.Drawing.Size(75, 23);
            this.m_okBtn.TabIndex = 6;
            this.m_okBtn.Text = "确认";
            this.m_okBtn.UseVisualStyleBackColor = true;
            this.m_okBtn.Click += new System.EventHandler(this.m_okBtn_Click);
            // 
            // m_cancelBtn
            // 
            this.m_cancelBtn.Location = new System.Drawing.Point(185, 163);
            this.m_cancelBtn.Name = "m_cancelBtn";
            this.m_cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.m_cancelBtn.TabIndex = 7;
            this.m_cancelBtn.Text = "取消";
            this.m_cancelBtn.UseVisualStyleBackColor = true;
            this.m_cancelBtn.Click += new System.EventHandler(this.m_cancelBtn_Click);
            // 
            // m_tipLbl
            // 
            this.m_tipLbl.AutoSize = true;
            this.m_tipLbl.ForeColor = System.Drawing.Color.Red;
            this.m_tipLbl.Location = new System.Drawing.Point(103, 131);
            this.m_tipLbl.Name = "m_tipLbl";
            this.m_tipLbl.Size = new System.Drawing.Size(29, 12);
            this.m_tipLbl.TabIndex = 8;
            this.m_tipLbl.Text = "提示";
            // 
            // RegisterUserWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 193);
            this.Controls.Add(this.m_tipLbl);
            this.Controls.Add(this.m_cancelBtn);
            this.Controls.Add(this.m_okBtn);
            this.Controls.Add(this.m_pwdAuthTxt);
            this.Controls.Add(this.m_pwdTxt);
            this.Controls.Add(this.m_userNameTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegisterUserWnd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "注册用户";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox m_userNameTxt;
        private System.Windows.Forms.TextBox m_pwdTxt;
        private System.Windows.Forms.TextBox m_pwdAuthTxt;
        private System.Windows.Forms.Button m_okBtn;
        private System.Windows.Forms.Button m_cancelBtn;
        private System.Windows.Forms.Label m_tipLbl;
    }
}