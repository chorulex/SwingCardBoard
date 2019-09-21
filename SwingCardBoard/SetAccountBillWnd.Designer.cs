namespace SwingCardBoard
{
    partial class SetAccountBillWnd
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
            this.m_accountComb = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_billAmountTxt = new System.Windows.Forms.TextBox();
            this.m_applyBtn = new System.Windows.Forms.Button();
            this.m_cancelBtn = new System.Windows.Forms.Button();
            this.m_initLab = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_cardNumberTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_avaliableAmountTxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.m_billDructionLB = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "信用卡/账号：";
            // 
            // m_accountComb
            // 
            this.m_accountComb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_accountComb.FormattingEnabled = true;
            this.m_accountComb.Location = new System.Drawing.Point(101, 22);
            this.m_accountComb.Name = "m_accountComb";
            this.m_accountComb.Size = new System.Drawing.Size(169, 20);
            this.m_accountComb.TabIndex = 1;
            this.m_accountComb.SelectedIndexChanged += new System.EventHandler(this.m_accountComb_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "账单金额：";
            // 
            // m_billAmountTxt
            // 
            this.m_billAmountTxt.Location = new System.Drawing.Point(101, 152);
            this.m_billAmountTxt.Name = "m_billAmountTxt";
            this.m_billAmountTxt.Size = new System.Drawing.Size(122, 21);
            this.m_billAmountTxt.TabIndex = 3;
            this.m_billAmountTxt.TextChanged += new System.EventHandler(this.m_billAmountTxt_TextChanged);
            this.m_billAmountTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_billAmountTxt_KeyPress);
            // 
            // m_applyBtn
            // 
            this.m_applyBtn.Location = new System.Drawing.Point(168, 194);
            this.m_applyBtn.Name = "m_applyBtn";
            this.m_applyBtn.Size = new System.Drawing.Size(75, 23);
            this.m_applyBtn.TabIndex = 4;
            this.m_applyBtn.Text = "确定";
            this.m_applyBtn.UseVisualStyleBackColor = true;
            this.m_applyBtn.Click += new System.EventHandler(this.m_applyBtn_Click);
            // 
            // m_cancelBtn
            // 
            this.m_cancelBtn.Location = new System.Drawing.Point(262, 194);
            this.m_cancelBtn.Name = "m_cancelBtn";
            this.m_cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.m_cancelBtn.TabIndex = 5;
            this.m_cancelBtn.Text = "取消";
            this.m_cancelBtn.UseVisualStyleBackColor = true;
            // 
            // m_initLab
            // 
            this.m_initLab.AutoSize = true;
            this.m_initLab.Location = new System.Drawing.Point(285, 25);
            this.m_initLab.Name = "m_initLab";
            this.m_initLab.Size = new System.Drawing.Size(185, 12);
            this.m_initLab.TabIndex = 6;
            this.m_initLab.Text = "（还没有该账号？点击这里添加）";
            this.m_initLab.Click += new System.EventHandler(this.m_initLab_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(229, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "（元）";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "信用卡号：";
            // 
            // m_cardNumberTxt
            // 
            this.m_cardNumberTxt.Location = new System.Drawing.Point(101, 60);
            this.m_cardNumberTxt.Name = "m_cardNumberTxt";
            this.m_cardNumberTxt.ReadOnly = true;
            this.m_cardNumberTxt.Size = new System.Drawing.Size(169, 21);
            this.m_cardNumberTxt.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "可用额度：";
            // 
            // m_avaliableAmountTxt
            // 
            this.m_avaliableAmountTxt.Location = new System.Drawing.Point(101, 124);
            this.m_avaliableAmountTxt.Name = "m_avaliableAmountTxt";
            this.m_avaliableAmountTxt.Size = new System.Drawing.Size(122, 21);
            this.m_avaliableAmountTxt.TabIndex = 3;
            this.m_avaliableAmountTxt.TextChanged += new System.EventHandler(this.m_avaliableAmountTxt_TextChanged);
            this.m_avaliableAmountTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_avaliableAmountTxt_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(229, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "（元）";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "账单时间：";
            // 
            // m_billDructionLB
            // 
            this.m_billDructionLB.AutoSize = true;
            this.m_billDructionLB.ForeColor = System.Drawing.Color.Red;
            this.m_billDructionLB.Location = new System.Drawing.Point(101, 96);
            this.m_billDructionLB.Name = "m_billDructionLB";
            this.m_billDructionLB.Size = new System.Drawing.Size(125, 12);
            this.m_billDructionLB.TabIndex = 11;
            this.m_billDructionLB.Text = "这是上一期的账单时间";
            // 
            // SetAccountBillWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 232);
            this.Controls.Add(this.m_billDructionLB);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.m_cardNumberTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_initLab);
            this.Controls.Add(this.m_cancelBtn);
            this.Controls.Add(this.m_applyBtn);
            this.Controls.Add(this.m_avaliableAmountTxt);
            this.Controls.Add(this.m_billAmountTxt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_accountComb);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetAccountBillWnd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设置信用卡/账号账单金额";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox m_accountComb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox m_billAmountTxt;
        private System.Windows.Forms.Button m_applyBtn;
        private System.Windows.Forms.Button m_cancelBtn;
        private System.Windows.Forms.Label m_initLab;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox m_cardNumberTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox m_avaliableAmountTxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label m_billDructionLB;
    }
}