namespace SwingCardBoard
{
    partial class BillHistoryWnd
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
            this.m_billDgv = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.m_showByDTRb = new System.Windows.Forms.RadioButton();
            this.m_showByAccountRB = new System.Windows.Forms.RadioButton();
            this.accountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.billDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creditAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.avaliableAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.billAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.repayAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.norepayAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.swingAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chargeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastEventDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.m_billDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // m_billDgv
            // 
            this.m_billDgv.AllowUserToAddRows = false;
            this.m_billDgv.AllowUserToDeleteRows = false;
            this.m_billDgv.AllowUserToResizeRows = false;
            this.m_billDgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_billDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_billDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.accountColumn,
            this.billDate,
            this.creditAmount,
            this.avaliableAmount,
            this.billAmount,
            this.repayAmount,
            this.norepayAmount,
            this.swingAmount,
            this.chargeColumn,
            this.stat,
            this.lastEventDT});
            this.m_billDgv.Location = new System.Drawing.Point(12, 40);
            this.m_billDgv.MultiSelect = false;
            this.m_billDgv.Name = "m_billDgv";
            this.m_billDgv.ReadOnly = true;
            this.m_billDgv.RowHeadersVisible = false;
            this.m_billDgv.RowTemplate.Height = 23;
            this.m_billDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_billDgv.Size = new System.Drawing.Size(1137, 422);
            this.m_billDgv.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "显示方式：";
            // 
            // m_showByDTRb
            // 
            this.m_showByDTRb.AutoSize = true;
            this.m_showByDTRb.Location = new System.Drawing.Point(92, 15);
            this.m_showByDTRb.Name = "m_showByDTRb";
            this.m_showByDTRb.Size = new System.Drawing.Size(83, 16);
            this.m_showByDTRb.TabIndex = 5;
            this.m_showByDTRb.TabStop = true;
            this.m_showByDTRb.Text = "按日期显示";
            this.m_showByDTRb.UseVisualStyleBackColor = true;
            this.m_showByDTRb.CheckedChanged += new System.EventHandler(this.m_showByDTRb_CheckedChanged);
            // 
            // m_showByAccountRB
            // 
            this.m_showByAccountRB.AutoSize = true;
            this.m_showByAccountRB.Location = new System.Drawing.Point(206, 15);
            this.m_showByAccountRB.Name = "m_showByAccountRB";
            this.m_showByAccountRB.Size = new System.Drawing.Size(83, 16);
            this.m_showByAccountRB.TabIndex = 6;
            this.m_showByAccountRB.TabStop = true;
            this.m_showByAccountRB.Text = "按账户显示";
            this.m_showByAccountRB.UseVisualStyleBackColor = true;
            this.m_showByAccountRB.CheckedChanged += new System.EventHandler(this.m_showByAccountRB_CheckedChanged);
            // 
            // accountColumn
            // 
            this.accountColumn.HeaderText = "银行卡/账号";
            this.accountColumn.Name = "accountColumn";
            this.accountColumn.ReadOnly = true;
            this.accountColumn.Width = 110;
            // 
            // billDate
            // 
            this.billDate.HeaderText = "账单日期";
            this.billDate.Name = "billDate";
            this.billDate.ReadOnly = true;
            this.billDate.Width = 160;
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
            this.billAmount.Width = 90;
            // 
            // repayAmount
            // 
            this.repayAmount.HeaderText = "已还金额";
            this.repayAmount.Name = "repayAmount";
            this.repayAmount.ReadOnly = true;
            this.repayAmount.Width = 90;
            // 
            // norepayAmount
            // 
            this.norepayAmount.HeaderText = "未还金额";
            this.norepayAmount.Name = "norepayAmount";
            this.norepayAmount.ReadOnly = true;
            this.norepayAmount.Width = 90;
            // 
            // swingAmount
            // 
            this.swingAmount.HeaderText = "刷卡合计";
            this.swingAmount.Name = "swingAmount";
            this.swingAmount.ReadOnly = true;
            this.swingAmount.Width = 90;
            // 
            // chargeColumn
            // 
            this.chargeColumn.HeaderText = "手续费合计";
            this.chargeColumn.Name = "chargeColumn";
            this.chargeColumn.ReadOnly = true;
            this.chargeColumn.Width = 85;
            // 
            // stat
            // 
            this.stat.HeaderText = "还款状态";
            this.stat.Name = "stat";
            this.stat.ReadOnly = true;
            // 
            // lastEventDT
            // 
            this.lastEventDT.HeaderText = "最近操作时间";
            this.lastEventDT.Name = "lastEventDT";
            this.lastEventDT.ReadOnly = true;
            this.lastEventDT.Width = 130;
            // 
            // BillHistoryWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 473);
            this.Controls.Add(this.m_showByAccountRB);
            this.Controls.Add(this.m_showByDTRb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_billDgv);
            this.Name = "BillHistoryWnd";
            this.Text = "往期账单";
            this.Load += new System.EventHandler(this.BillHistoryWnd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_billDgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView m_billDgv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton m_showByDTRb;
        private System.Windows.Forms.RadioButton m_showByAccountRB;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn billDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn creditAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn avaliableAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn billAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn repayAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn norepayAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn swingAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn chargeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stat;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastEventDT;
    }
}