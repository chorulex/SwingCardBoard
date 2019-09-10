namespace SwingCardBoard
{
    partial class AccountFundEventWnd
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
            this.m_applyBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.m_cardNumTxt = new System.Windows.Forms.TextBox();
            this.m_cardComb = new System.Windows.Forms.ComboBox();
            this.m_cancelBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_amoutTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.addCardLab = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_noRepayAmountTxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_applyBtn
            // 
            this.m_applyBtn.Location = new System.Drawing.Point(189, 163);
            this.m_applyBtn.Name = "m_applyBtn";
            this.m_applyBtn.Size = new System.Drawing.Size(75, 23);
            this.m_applyBtn.TabIndex = 0;
            this.m_applyBtn.Text = "确定";
            this.m_applyBtn.UseVisualStyleBackColor = true;
            this.m_applyBtn.Click += new System.EventHandler(this.applyBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "银行卡/账号：";
            // 
            // m_cardNumTxt
            // 
            this.m_cardNumTxt.Location = new System.Drawing.Point(111, 61);
            this.m_cardNumTxt.Name = "m_cardNumTxt";
            this.m_cardNumTxt.ReadOnly = true;
            this.m_cardNumTxt.Size = new System.Drawing.Size(186, 21);
            this.m_cardNumTxt.TabIndex = 2;
            // 
            // m_cardComb
            // 
            this.m_cardComb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cardComb.FormattingEnabled = true;
            this.m_cardComb.Location = new System.Drawing.Point(111, 26);
            this.m_cardComb.Name = "m_cardComb";
            this.m_cardComb.Size = new System.Drawing.Size(186, 20);
            this.m_cardComb.TabIndex = 3;
            this.m_cardComb.SelectedIndexChanged += new System.EventHandler(this.m_cardComb_SelectedIndexChanged);
            // 
            // m_cancelBtn
            // 
            this.m_cancelBtn.Location = new System.Drawing.Point(289, 163);
            this.m_cancelBtn.Name = "m_cancelBtn";
            this.m_cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.m_cancelBtn.TabIndex = 4;
            this.m_cancelBtn.Text = "取消";
            this.m_cancelBtn.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "信用卡号/账号：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "金额：";
            // 
            // m_amoutTxt
            // 
            this.m_amoutTxt.Location = new System.Drawing.Point(111, 131);
            this.m_amoutTxt.Name = "m_amoutTxt";
            this.m_amoutTxt.Size = new System.Drawing.Size(103, 21);
            this.m_amoutTxt.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(223, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "（元）";
            // 
            // addCardLab
            // 
            this.addCardLab.AutoSize = true;
            this.addCardLab.Location = new System.Drawing.Point(303, 30);
            this.addCardLab.Name = "addCardLab";
            this.addCardLab.Size = new System.Drawing.Size(215, 12);
            this.addCardLab.TabIndex = 9;
            this.addCardLab.Text = "（没有该银行卡/账号？点击这里添加）";
            this.addCardLab.Click += new System.EventHandler(this.addCardLab_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "未还额度：";
            // 
            // m_noRepayAmountTxt
            // 
            this.m_noRepayAmountTxt.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_noRepayAmountTxt.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_noRepayAmountTxt.Location = new System.Drawing.Point(111, 97);
            this.m_noRepayAmountTxt.Name = "m_noRepayAmountTxt";
            this.m_noRepayAmountTxt.ReadOnly = true;
            this.m_noRepayAmountTxt.Size = new System.Drawing.Size(103, 26);
            this.m_noRepayAmountTxt.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(223, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "（元）";
            // 
            // AccountFundEventWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 198);
            this.Controls.Add(this.m_noRepayAmountTxt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.addCardLab);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.m_amoutTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_cancelBtn);
            this.Controls.Add(this.m_cardComb);
            this.Controls.Add(this.m_cardNumTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_applyBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AccountFundEventWnd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "资金变动记录 - ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_applyBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox m_cardNumTxt;
        private System.Windows.Forms.ComboBox m_cardComb;
        private System.Windows.Forms.Button m_cancelBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox m_amoutTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label addCardLab;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox m_noRepayAmountTxt;
        private System.Windows.Forms.Label label6;
    }
}