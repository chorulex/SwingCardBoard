namespace SwingCardBoard
{
    partial class MainWnd
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
            this.takeSwingBtn = new System.Windows.Forms.Button();
            this.cardManageBtn = new System.Windows.Forms.Button();
            this.m_accountStatisticsDgv = new System.Windows.Forms.DataGridView();
            this.account = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.billDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creditAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.avaliableAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.billAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.repayAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.norepayAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.swingAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.swingDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastEventDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dateLab = new System.Windows.Forms.Label();
            this.m_setBillBtn = new System.Windows.Forms.Button();
            this.m_repayBtn = new System.Windows.Forms.Button();
            this.m_showFundChangeEventsBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.m_accountStatisticsDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // takeSwingBtn
            // 
            this.takeSwingBtn.Location = new System.Drawing.Point(544, 12);
            this.takeSwingBtn.Name = "takeSwingBtn";
            this.takeSwingBtn.Size = new System.Drawing.Size(133, 23);
            this.takeSwingBtn.TabIndex = 0;
            this.takeSwingBtn.Text = "记一笔刷卡记录";
            this.takeSwingBtn.UseVisualStyleBackColor = true;
            this.takeSwingBtn.Click += new System.EventHandler(this.takeNoteBtn_Click);
            // 
            // cardManageBtn
            // 
            this.cardManageBtn.Location = new System.Drawing.Point(12, 12);
            this.cardManageBtn.Name = "cardManageBtn";
            this.cardManageBtn.Size = new System.Drawing.Size(153, 23);
            this.cardManageBtn.TabIndex = 2;
            this.cardManageBtn.Text = "卡片/账号管理";
            this.cardManageBtn.UseVisualStyleBackColor = true;
            this.cardManageBtn.Click += new System.EventHandler(this.cardManageBtn_Click);
            // 
            // m_accountStatisticsDgv
            // 
            this.m_accountStatisticsDgv.AllowUserToAddRows = false;
            this.m_accountStatisticsDgv.AllowUserToDeleteRows = false;
            this.m_accountStatisticsDgv.AllowUserToResizeRows = false;
            this.m_accountStatisticsDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_accountStatisticsDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.account,
            this.billDate,
            this.creditAmount,
            this.avaliableAmount,
            this.billAmount,
            this.repayAmount,
            this.norepayAmount,
            this.swingAmount,
            this.swingDetails,
            this.stat,
            this.lastEventDT});
            this.m_accountStatisticsDgv.Location = new System.Drawing.Point(12, 105);
            this.m_accountStatisticsDgv.MultiSelect = false;
            this.m_accountStatisticsDgv.Name = "m_accountStatisticsDgv";
            this.m_accountStatisticsDgv.ReadOnly = true;
            this.m_accountStatisticsDgv.RowHeadersVisible = false;
            this.m_accountStatisticsDgv.RowTemplate.Height = 23;
            this.m_accountStatisticsDgv.Size = new System.Drawing.Size(1055, 406);
            this.m_accountStatisticsDgv.TabIndex = 3;
            // 
            // account
            // 
            this.account.HeaderText = "银行卡/账号";
            this.account.Name = "account";
            this.account.ReadOnly = true;
            this.account.Width = 130;
            // 
            // billDate
            // 
            this.billDate.HeaderText = "账单日期";
            this.billDate.Name = "billDate";
            this.billDate.ReadOnly = true;
            this.billDate.Width = 80;
            // 
            // creditAmount
            // 
            this.creditAmount.HeaderText = "信用额度";
            this.creditAmount.Name = "creditAmount";
            this.creditAmount.ReadOnly = true;
            this.creditAmount.Width = 90;
            // 
            // avaliableAmount
            // 
            this.avaliableAmount.HeaderText = "可用额度";
            this.avaliableAmount.Name = "avaliableAmount";
            this.avaliableAmount.ReadOnly = true;
            this.avaliableAmount.Width = 90;
            // 
            // billAmount
            // 
            this.billAmount.HeaderText = "账单金额";
            this.billAmount.Name = "billAmount";
            this.billAmount.ReadOnly = true;
            this.billAmount.Width = 80;
            // 
            // repayAmount
            // 
            this.repayAmount.HeaderText = "已还金额";
            this.repayAmount.Name = "repayAmount";
            this.repayAmount.ReadOnly = true;
            this.repayAmount.Width = 80;
            // 
            // norepayAmount
            // 
            this.norepayAmount.HeaderText = "未还金额";
            this.norepayAmount.Name = "norepayAmount";
            this.norepayAmount.ReadOnly = true;
            this.norepayAmount.Width = 80;
            // 
            // swingAmount
            // 
            this.swingAmount.HeaderText = "刷卡合计";
            this.swingAmount.Name = "swingAmount";
            this.swingAmount.ReadOnly = true;
            this.swingAmount.Width = 80;
            // 
            // swingDetails
            // 
            this.swingDetails.HeaderText = "刷卡明细";
            this.swingDetails.Name = "swingDetails";
            this.swingDetails.ReadOnly = true;
            this.swingDetails.Width = 80;
            // 
            // stat
            // 
            this.stat.HeaderText = "还款状态";
            this.stat.Name = "stat";
            this.stat.ReadOnly = true;
            this.stat.Width = 120;
            // 
            // lastEventDT
            // 
            this.lastEventDT.HeaderText = "最近操作时间";
            this.lastEventDT.Name = "lastEventDT";
            this.lastEventDT.ReadOnly = true;
            this.lastEventDT.Width = 130;
            // 
            // m_dateLab
            // 
            this.m_dateLab.AutoSize = true;
            this.m_dateLab.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dateLab.ForeColor = System.Drawing.Color.Green;
            this.m_dateLab.Location = new System.Drawing.Point(483, 72);
            this.m_dateLab.Name = "m_dateLab";
            this.m_dateLab.Size = new System.Drawing.Size(113, 16);
            this.m_dateLab.TabIndex = 4;
            this.m_dateLab.Text = "1970年1月1日";
            // 
            // m_setBillBtn
            // 
            this.m_setBillBtn.Location = new System.Drawing.Point(12, 69);
            this.m_setBillBtn.Name = "m_setBillBtn";
            this.m_setBillBtn.Size = new System.Drawing.Size(286, 23);
            this.m_setBillBtn.TabIndex = 5;
            this.m_setBillBtn.Text = "设置当期账单（每期设置一次即可）";
            this.m_setBillBtn.UseVisualStyleBackColor = true;
            this.m_setBillBtn.Click += new System.EventHandler(this.m_setBillBtn_Click);
            // 
            // m_repayBtn
            // 
            this.m_repayBtn.Location = new System.Drawing.Point(703, 12);
            this.m_repayBtn.Name = "m_repayBtn";
            this.m_repayBtn.Size = new System.Drawing.Size(125, 23);
            this.m_repayBtn.TabIndex = 6;
            this.m_repayBtn.Text = "记一笔还款记录";
            this.m_repayBtn.UseVisualStyleBackColor = true;
            this.m_repayBtn.Click += new System.EventHandler(this.m_repayBtn_Click);
            // 
            // m_showFundChangeEventsBtn
            // 
            this.m_showFundChangeEventsBtn.Location = new System.Drawing.Point(171, 12);
            this.m_showFundChangeEventsBtn.Name = "m_showFundChangeEventsBtn";
            this.m_showFundChangeEventsBtn.Size = new System.Drawing.Size(168, 23);
            this.m_showFundChangeEventsBtn.TabIndex = 7;
            this.m_showFundChangeEventsBtn.Text = "查看资金变动历史记录";
            this.m_showFundChangeEventsBtn.UseVisualStyleBackColor = true;
            this.m_showFundChangeEventsBtn.Click += new System.EventHandler(this.m_showFundChangeEventsBtn_Click);
            // 
            // MainWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 522);
            this.Controls.Add(this.m_showFundChangeEventsBtn);
            this.Controls.Add(this.m_repayBtn);
            this.Controls.Add(this.m_setBillBtn);
            this.Controls.Add(this.m_dateLab);
            this.Controls.Add(this.m_accountStatisticsDgv);
            this.Controls.Add(this.cardManageBtn);
            this.Controls.Add(this.takeSwingBtn);
            this.Name = "MainWnd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "养卡记";
            this.Load += new System.EventHandler(this.MainWnd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_accountStatisticsDgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button takeSwingBtn;
        private System.Windows.Forms.Button cardManageBtn;
        private System.Windows.Forms.DataGridView m_accountStatisticsDgv;
        private System.Windows.Forms.Label m_dateLab;
        private System.Windows.Forms.Button m_setBillBtn;
        private System.Windows.Forms.Button m_repayBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn account;
        private System.Windows.Forms.DataGridViewTextBoxColumn billDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn creditAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn avaliableAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn billAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn repayAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn norepayAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn swingAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn swingDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn stat;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastEventDT;
        private System.Windows.Forms.Button m_showFundChangeEventsBtn;
    }
}

