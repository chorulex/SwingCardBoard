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
            this.m_accountStatisticsDgv = new System.Windows.Forms.DataGridView();
            this.account = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.billDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creditAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.avaliableAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.billAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.repayAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.norepayAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.swingAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastEventDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_repayBtn = new System.Windows.Forms.Button();
            this.m_menuStrip = new System.Windows.Forms.MenuStrip();
            this.账号管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.账号管理ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.设置当期账单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.资金变动历史ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.资金变动历史ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.m_accountStatisticsDgv)).BeginInit();
            this.m_menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // takeSwingBtn
            // 
            this.takeSwingBtn.Location = new System.Drawing.Point(12, 28);
            this.takeSwingBtn.Name = "takeSwingBtn";
            this.takeSwingBtn.Size = new System.Drawing.Size(133, 23);
            this.takeSwingBtn.TabIndex = 0;
            this.takeSwingBtn.Text = "记一笔刷卡记录";
            this.takeSwingBtn.UseVisualStyleBackColor = true;
            this.takeSwingBtn.Click += new System.EventHandler(this.takeNoteBtn_Click);
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
            this.stat,
            this.lastEventDT});
            this.m_accountStatisticsDgv.Location = new System.Drawing.Point(12, 57);
            this.m_accountStatisticsDgv.MultiSelect = false;
            this.m_accountStatisticsDgv.Name = "m_accountStatisticsDgv";
            this.m_accountStatisticsDgv.ReadOnly = true;
            this.m_accountStatisticsDgv.RowHeadersVisible = false;
            this.m_accountStatisticsDgv.RowTemplate.Height = 23;
            this.m_accountStatisticsDgv.Size = new System.Drawing.Size(1085, 406);
            this.m_accountStatisticsDgv.TabIndex = 3;
            this.m_accountStatisticsDgv.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_accountStatisticsDgv_CellMouseEnter);
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
            // 
            // avaliableAmount
            // 
            this.avaliableAmount.HeaderText = "可用额度";
            this.avaliableAmount.Name = "avaliableAmount";
            this.avaliableAmount.ReadOnly = true;
            // 
            // billAmount
            // 
            this.billAmount.HeaderText = "账单金额";
            this.billAmount.Name = "billAmount";
            this.billAmount.ReadOnly = true;
            // 
            // repayAmount
            // 
            this.repayAmount.HeaderText = "已还金额";
            this.repayAmount.Name = "repayAmount";
            this.repayAmount.ReadOnly = true;
            // 
            // norepayAmount
            // 
            this.norepayAmount.HeaderText = "未还金额";
            this.norepayAmount.Name = "norepayAmount";
            this.norepayAmount.ReadOnly = true;
            // 
            // swingAmount
            // 
            this.swingAmount.HeaderText = "刷卡合计";
            this.swingAmount.Name = "swingAmount";
            this.swingAmount.ReadOnly = true;
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
            // m_repayBtn
            // 
            this.m_repayBtn.Location = new System.Drawing.Point(151, 28);
            this.m_repayBtn.Name = "m_repayBtn";
            this.m_repayBtn.Size = new System.Drawing.Size(125, 23);
            this.m_repayBtn.TabIndex = 6;
            this.m_repayBtn.Text = "记一笔还款记录";
            this.m_repayBtn.UseVisualStyleBackColor = true;
            this.m_repayBtn.Click += new System.EventHandler(this.m_repayBtn_Click);
            // 
            // m_menuStrip
            // 
            this.m_menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.账号管理ToolStripMenuItem,
            this.资金变动历史ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.m_menuStrip.Location = new System.Drawing.Point(0, 0);
            this.m_menuStrip.Name = "m_menuStrip";
            this.m_menuStrip.Size = new System.Drawing.Size(1109, 25);
            this.m_menuStrip.TabIndex = 8;
            this.m_menuStrip.Text = "menuStrip1";
            // 
            // 账号管理ToolStripMenuItem
            // 
            this.账号管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.账号管理ToolStripMenuItem1,
            this.设置当期账单ToolStripMenuItem});
            this.账号管理ToolStripMenuItem.Name = "账号管理ToolStripMenuItem";
            this.账号管理ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.账号管理ToolStripMenuItem.Text = "管理";
            // 
            // 账号管理ToolStripMenuItem1
            // 
            this.账号管理ToolStripMenuItem1.Name = "账号管理ToolStripMenuItem1";
            this.账号管理ToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.账号管理ToolStripMenuItem1.Text = "账号管理";
            this.账号管理ToolStripMenuItem1.Click += new System.EventHandler(this.账号管理ToolStripMenuItem1_Click);
            // 
            // 设置当期账单ToolStripMenuItem
            // 
            this.设置当期账单ToolStripMenuItem.Name = "设置当期账单ToolStripMenuItem";
            this.设置当期账单ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.设置当期账单ToolStripMenuItem.Text = "设置当期账单";
            this.设置当期账单ToolStripMenuItem.Click += new System.EventHandler(this.设置当期账单ToolStripMenuItem_Click);
            // 
            // 资金变动历史ToolStripMenuItem
            // 
            this.资金变动历史ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.资金变动历史ToolStripMenuItem1});
            this.资金变动历史ToolStripMenuItem.Name = "资金变动历史ToolStripMenuItem";
            this.资金变动历史ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.资金变动历史ToolStripMenuItem.Text = "查看";
            // 
            // 资金变动历史ToolStripMenuItem1
            // 
            this.资金变动历史ToolStripMenuItem1.Name = "资金变动历史ToolStripMenuItem1";
            this.资金变动历史ToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.资金变动历史ToolStripMenuItem1.Text = "资金变动历史";
            this.资金变动历史ToolStripMenuItem1.Click += new System.EventHandler(this.资金变动历史ToolStripMenuItem1_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.帮助ToolStripMenuItem});
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.关于ToolStripMenuItem.Text = "帮助";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.帮助ToolStripMenuItem.Text = "关于";
            this.帮助ToolStripMenuItem.Click += new System.EventHandler(this.帮助ToolStripMenuItem_Click);
            // 
            // MainWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 476);
            this.Controls.Add(this.m_repayBtn);
            this.Controls.Add(this.m_accountStatisticsDgv);
            this.Controls.Add(this.takeSwingBtn);
            this.Controls.Add(this.m_menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.m_menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainWnd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "养卡记";
            this.Load += new System.EventHandler(this.MainWnd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_accountStatisticsDgv)).EndInit();
            this.m_menuStrip.ResumeLayout(false);
            this.m_menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button takeSwingBtn;
        private System.Windows.Forms.DataGridView m_accountStatisticsDgv;
        private System.Windows.Forms.Button m_repayBtn;
        private System.Windows.Forms.MenuStrip m_menuStrip;
        private System.Windows.Forms.ToolStripMenuItem 账号管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 资金变动历史ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 账号管理ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 设置当期账单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 资金变动历史ToolStripMenuItem1;
        private System.Windows.Forms.DataGridViewTextBoxColumn account;
        private System.Windows.Forms.DataGridViewTextBoxColumn billDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn creditAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn avaliableAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn billAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn repayAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn norepayAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn swingAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn stat;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastEventDT;
    }
}

