namespace SwingCardBoard
{
    partial class AccountManageWnd
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
            this.m_accountListDGV = new System.Windows.Forms.DataGridView();
            this.account = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.billExpired = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.billStartDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creditAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_addAccountBtn = new System.Windows.Forms.Button();
            this.m_applyBtn = new System.Windows.Forms.Button();
            this.m_cancelBtn = new System.Windows.Forms.Button();
            this.m_cleanBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.m_accountListDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // m_accountListDGV
            // 
            this.m_accountListDGV.AllowUserToAddRows = false;
            this.m_accountListDGV.AllowUserToDeleteRows = false;
            this.m_accountListDGV.AllowUserToResizeRows = false;
            this.m_accountListDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_accountListDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.account,
            this.number,
            this.billExpired,
            this.billStartDay,
            this.creditAmount});
            this.m_accountListDGV.Location = new System.Drawing.Point(13, 12);
            this.m_accountListDGV.Name = "m_accountListDGV";
            this.m_accountListDGV.RowHeadersVisible = false;
            this.m_accountListDGV.RowTemplate.Height = 23;
            this.m_accountListDGV.Size = new System.Drawing.Size(624, 294);
            this.m_accountListDGV.TabIndex = 0;
            // 
            // account
            // 
            this.account.HeaderText = "银行卡/账号";
            this.account.Name = "account";
            this.account.ReadOnly = true;
            this.account.Width = 150;
            // 
            // number
            // 
            this.number.HeaderText = "卡号/账号";
            this.number.Name = "number";
            this.number.ReadOnly = true;
            this.number.Width = 140;
            // 
            // billExpired
            // 
            this.billExpired.HeaderText = "账单到期日";
            this.billExpired.Name = "billExpired";
            this.billExpired.ReadOnly = true;
            // 
            // billStartDay
            // 
            this.billStartDay.HeaderText = "账单出账日";
            this.billStartDay.Name = "billStartDay";
            this.billStartDay.ReadOnly = true;
            // 
            // creditAmount
            // 
            this.creditAmount.HeaderText = "信用额度（元）";
            this.creditAmount.Name = "creditAmount";
            this.creditAmount.ReadOnly = true;
            this.creditAmount.Width = 120;
            // 
            // m_addAccountBtn
            // 
            this.m_addAccountBtn.Location = new System.Drawing.Point(13, 312);
            this.m_addAccountBtn.Name = "m_addAccountBtn";
            this.m_addAccountBtn.Size = new System.Drawing.Size(139, 23);
            this.m_addAccountBtn.TabIndex = 1;
            this.m_addAccountBtn.Text = "添加银行卡/账号";
            this.m_addAccountBtn.UseVisualStyleBackColor = true;
            this.m_addAccountBtn.Click += new System.EventHandler(this.m_addAccountBtn_Click);
            // 
            // m_applyBtn
            // 
            this.m_applyBtn.Location = new System.Drawing.Point(481, 312);
            this.m_applyBtn.Name = "m_applyBtn";
            this.m_applyBtn.Size = new System.Drawing.Size(75, 23);
            this.m_applyBtn.TabIndex = 2;
            this.m_applyBtn.Text = "确认";
            this.m_applyBtn.UseVisualStyleBackColor = true;
            this.m_applyBtn.Click += new System.EventHandler(this.m_applyBtn_Click);
            // 
            // m_cancelBtn
            // 
            this.m_cancelBtn.Location = new System.Drawing.Point(562, 312);
            this.m_cancelBtn.Name = "m_cancelBtn";
            this.m_cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.m_cancelBtn.TabIndex = 3;
            this.m_cancelBtn.Text = "取消";
            this.m_cancelBtn.UseVisualStyleBackColor = true;
            // 
            // m_cleanBtn
            // 
            this.m_cleanBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_cleanBtn.Location = new System.Drawing.Point(158, 312);
            this.m_cleanBtn.Name = "m_cleanBtn";
            this.m_cleanBtn.Size = new System.Drawing.Size(85, 23);
            this.m_cleanBtn.TabIndex = 4;
            this.m_cleanBtn.Text = "一键清空";
            this.m_cleanBtn.UseVisualStyleBackColor = true;
            this.m_cleanBtn.Click += new System.EventHandler(this.m_cleanBtn_Click);
            // 
            // AccountManageWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 348);
            this.Controls.Add(this.m_cleanBtn);
            this.Controls.Add(this.m_cancelBtn);
            this.Controls.Add(this.m_applyBtn);
            this.Controls.Add(this.m_addAccountBtn);
            this.Controls.Add(this.m_accountListDGV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AccountManageWnd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "银行卡/账号管理";
            ((System.ComponentModel.ISupportInitialize)(this.m_accountListDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView m_accountListDGV;
        private System.Windows.Forms.Button m_addAccountBtn;
        private System.Windows.Forms.Button m_applyBtn;
        private System.Windows.Forms.Button m_cancelBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn account;
        private System.Windows.Forms.DataGridViewTextBoxColumn number;
        private System.Windows.Forms.DataGridViewTextBoxColumn billExpired;
        private System.Windows.Forms.DataGridViewTextBoxColumn billStartDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn creditAmount;
        private System.Windows.Forms.Button m_cleanBtn;
    }
}