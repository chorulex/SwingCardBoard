namespace SwingCardBoard
{
    partial class FundChangeHistoryWnd
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
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.m_fundChangeLV = new System.Windows.Forms.ListView();
            this.m_accountTreeView = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.m_eventTypeComb = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_tipLB = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "银行卡/账号";
            this.columnHeader1.Width = 140;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "资金变动类型";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "资金变动金额";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "操作日期时间";
            this.columnHeader4.Width = 180;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "序号";
            this.columnHeader5.Width = 50;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "刷卡手续费";
            this.columnHeader6.Width = 100;
            // 
            // m_fundChangeLV
            // 
            this.m_fundChangeLV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_fundChangeLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader6,
            this.columnHeader4});
            this.m_fundChangeLV.FullRowSelect = true;
            this.m_fundChangeLV.Location = new System.Drawing.Point(249, 31);
            this.m_fundChangeLV.Name = "m_fundChangeLV";
            this.m_fundChangeLV.Size = new System.Drawing.Size(687, 435);
            this.m_fundChangeLV.TabIndex = 7;
            this.m_fundChangeLV.UseCompatibleStateImageBehavior = false;
            this.m_fundChangeLV.View = System.Windows.Forms.View.Details;
            // 
            // m_accountTreeView
            // 
            this.m_accountTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.m_accountTreeView.Location = new System.Drawing.Point(12, 31);
            this.m_accountTreeView.Name = "m_accountTreeView";
            this.m_accountTreeView.Size = new System.Drawing.Size(225, 435);
            this.m_accountTreeView.TabIndex = 0;
            this.m_accountTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_accountTreeView_AfterSelect);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "选择账号和日期";
            // 
            // m_eventTypeComb
            // 
            this.m_eventTypeComb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_eventTypeComb.FormattingEnabled = true;
            this.m_eventTypeComb.Location = new System.Drawing.Point(342, 5);
            this.m_eventTypeComb.Name = "m_eventTypeComb";
            this.m_eventTypeComb.Size = new System.Drawing.Size(146, 20);
            this.m_eventTypeComb.TabIndex = 9;
            this.m_eventTypeComb.SelectedIndexChanged += new System.EventHandler(this.m_eventTypeComb_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(247, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "选择事件类型：";
            // 
            // m_tipLB
            // 
            this.m_tipLB.AutoSize = true;
            this.m_tipLB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.m_tipLB.Location = new System.Drawing.Point(494, 9);
            this.m_tipLB.Name = "m_tipLB";
            this.m_tipLB.Size = new System.Drawing.Size(83, 12);
            this.m_tipLB.TabIndex = 11;
            this.m_tipLB.Text = "共有 0 条记录";
            // 
            // FundChangeHistoryWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 478);
            this.Controls.Add(this.m_tipLB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_eventTypeComb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_accountTreeView);
            this.Controls.Add(this.m_fundChangeLV);
            this.Name = "FundChangeHistoryWnd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "资金变动历史记录";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FundChangeHistoryWnd_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ListView m_fundChangeLV;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.TreeView m_accountTreeView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox m_eventTypeComb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label m_tipLB;
    }
}