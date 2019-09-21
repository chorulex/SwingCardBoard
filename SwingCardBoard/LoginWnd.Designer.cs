namespace SwingCardBoard
{
    partial class LoginWnd
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
            this.m_usrNameTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_usrPwdTxt = new System.Windows.Forms.TextBox();
            this.m_loginBtn = new System.Windows.Forms.Button();
            this.m_cancelBtn = new System.Windows.Forms.Button();
            this.m_registerBtn = new System.Windows.Forms.Button();
            this.m_tipLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名：";
            // 
            // m_usrNameTxt
            // 
            this.m_usrNameTxt.Location = new System.Drawing.Point(98, 28);
            this.m_usrNameTxt.Name = "m_usrNameTxt";
            this.m_usrNameTxt.Size = new System.Drawing.Size(191, 21);
            this.m_usrNameTxt.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "密  码：";
            // 
            // m_usrPwdTxt
            // 
            this.m_usrPwdTxt.Location = new System.Drawing.Point(98, 67);
            this.m_usrPwdTxt.Name = "m_usrPwdTxt";
            this.m_usrPwdTxt.PasswordChar = '*';
            this.m_usrPwdTxt.Size = new System.Drawing.Size(191, 21);
            this.m_usrPwdTxt.TabIndex = 3;
            // 
            // m_loginBtn
            // 
            this.m_loginBtn.Location = new System.Drawing.Point(48, 133);
            this.m_loginBtn.Name = "m_loginBtn";
            this.m_loginBtn.Size = new System.Drawing.Size(75, 23);
            this.m_loginBtn.TabIndex = 4;
            this.m_loginBtn.Text = "登录";
            this.m_loginBtn.UseVisualStyleBackColor = true;
            this.m_loginBtn.Click += new System.EventHandler(this.m_loginBtn_Click);
            // 
            // m_cancelBtn
            // 
            this.m_cancelBtn.Location = new System.Drawing.Point(222, 133);
            this.m_cancelBtn.Name = "m_cancelBtn";
            this.m_cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.m_cancelBtn.TabIndex = 5;
            this.m_cancelBtn.Text = "取消";
            this.m_cancelBtn.UseVisualStyleBackColor = true;
            this.m_cancelBtn.Click += new System.EventHandler(this.m_cancelBtn_Click);
            // 
            // m_registerBtn
            // 
            this.m_registerBtn.Location = new System.Drawing.Point(141, 133);
            this.m_registerBtn.Name = "m_registerBtn";
            this.m_registerBtn.Size = new System.Drawing.Size(75, 23);
            this.m_registerBtn.TabIndex = 6;
            this.m_registerBtn.Text = "注册";
            this.m_registerBtn.UseVisualStyleBackColor = true;
            this.m_registerBtn.Click += new System.EventHandler(this.m_registerBtn_Click);
            // 
            // m_tipLbl
            // 
            this.m_tipLbl.AutoSize = true;
            this.m_tipLbl.ForeColor = System.Drawing.Color.Red;
            this.m_tipLbl.Location = new System.Drawing.Point(94, 104);
            this.m_tipLbl.Name = "m_tipLbl";
            this.m_tipLbl.Size = new System.Drawing.Size(29, 12);
            this.m_tipLbl.TabIndex = 7;
            this.m_tipLbl.Text = "提示";
            // 
            // LoginWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 171);
            this.Controls.Add(this.m_tipLbl);
            this.Controls.Add(this.m_registerBtn);
            this.Controls.Add(this.m_cancelBtn);
            this.Controls.Add(this.m_loginBtn);
            this.Controls.Add(this.m_usrPwdTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_usrNameTxt);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginWnd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "养卡记 - ";
            this.Load += new System.EventHandler(this.LoginWnd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox m_usrNameTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox m_usrPwdTxt;
        private System.Windows.Forms.Button m_loginBtn;
        private System.Windows.Forms.Button m_cancelBtn;
        private System.Windows.Forms.Button m_registerBtn;
        private System.Windows.Forms.Label m_tipLbl;
    }
}