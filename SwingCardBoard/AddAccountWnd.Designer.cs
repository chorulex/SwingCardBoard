namespace SwingCardBoard
{
    partial class AddAccountWnd
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
            this.m_accountNameTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.creditAmountTxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.applyBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.numberTxt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.expiredDT = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.billExpiredNUD = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.billStartDayNUD = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_rateTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.billExpiredNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.billStartDayNUD)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(71, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "名称：";
            // 
            // m_accountNameTxt
            // 
            this.m_accountNameTxt.Location = new System.Drawing.Point(121, 33);
            this.m_accountNameTxt.Name = "m_accountNameTxt";
            this.m_accountNameTxt.Size = new System.Drawing.Size(141, 21);
            this.m_accountNameTxt.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "信用额度：";
            // 
            // creditAmountTxt
            // 
            this.creditAmountTxt.Location = new System.Drawing.Point(102, 34);
            this.creditAmountTxt.Name = "creditAmountTxt";
            this.creditAmountTxt.Size = new System.Drawing.Size(146, 21);
            this.creditAmountTxt.TabIndex = 4;
            this.creditAmountTxt.TextChanged += new System.EventHandler(this.creditAmountTxt_TextChanged);
            this.creditAmountTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.creditAmountTxt_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(249, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(197, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "（元，如果是信用卡，此项必填！）";
            // 
            // applyBtn
            // 
            this.applyBtn.Location = new System.Drawing.Point(149, 395);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(75, 23);
            this.applyBtn.TabIndex = 6;
            this.applyBtn.Text = "确定";
            this.applyBtn.UseVisualStyleBackColor = true;
            this.applyBtn.Click += new System.EventHandler(this.applyBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(246, 395);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 7;
            this.cancelBtn.Text = "取消";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(74, 106);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 11;
            this.label8.Text = "卡号：";
            // 
            // numberTxt
            // 
            this.numberTxt.Location = new System.Drawing.Point(121, 102);
            this.numberTxt.Name = "numberTxt";
            this.numberTxt.Size = new System.Drawing.Size(188, 21);
            this.numberTxt.TabIndex = 2;
            this.numberTxt.TextChanged += new System.EventHandler(this.numberTxt_TextChanged);
            this.numberTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberTxt_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(26, 140);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 12);
            this.label9.TabIndex = 12;
            this.label9.Text = "信用卡到期日：";
            // 
            // expiredDT
            // 
            this.expiredDT.Location = new System.Drawing.Point(121, 135);
            this.expiredDT.Name = "expiredDT";
            this.expiredDT.Size = new System.Drawing.Size(141, 21);
            this.expiredDT.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(38, 206);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 12);
            this.label10.TabIndex = 14;
            this.label10.Text = "最后还款日：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(231, 208);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 12);
            this.label11.TabIndex = 16;
            this.label11.Text = "（例如：每月23日）";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(125, 206);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 17;
            this.label12.Text = "每月";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(210, 207);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 12);
            this.label13.TabIndex = 18;
            this.label13.Text = "日";
            // 
            // billExpiredNUD
            // 
            this.billExpiredNUD.Location = new System.Drawing.Point(159, 202);
            this.billExpiredNUD.Name = "billExpiredNUD";
            this.billExpiredNUD.Size = new System.Drawing.Size(46, 21);
            this.billExpiredNUD.TabIndex = 19;
            this.billExpiredNUD.Value = new decimal(new int[] {
            23,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(38, 174);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 12);
            this.label14.TabIndex = 14;
            this.label14.Text = "账单出账日：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(232, 176);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(107, 12);
            this.label15.TabIndex = 16;
            this.label15.Text = "（例如：每月5日）";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(125, 174);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 12);
            this.label16.TabIndex = 17;
            this.label16.Text = "每月";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(210, 176);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(17, 12);
            this.label17.TabIndex = 18;
            this.label17.Text = "日";
            // 
            // billStartDayNUD
            // 
            this.billStartDayNUD.Location = new System.Drawing.Point(159, 171);
            this.billStartDayNUD.Name = "billStartDayNUD";
            this.billStartDayNUD.Size = new System.Drawing.Size(46, 21);
            this.billStartDayNUD.TabIndex = 19;
            this.billStartDayNUD.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(268, 37);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(179, 12);
            this.label18.TabIndex = 20;
            this.label18.Text = "（给这个账号/银行卡命个名吧）";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.m_accountNameTxt);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.billStartDayNUD);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.billExpiredNUD);
            this.groupBox1.Controls.Add(this.numberTxt);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.expiredDT);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Location = new System.Drawing.Point(12, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(459, 240);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本信息（必填）";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(119, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 12);
            this.label4.TabIndex = 22;
            this.label4.Text = "（名称一旦创建，不可更改！）";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(315, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 21;
            this.label2.Text = "（选填）";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_rateTxt);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.creditAmountTxt);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(12, 274);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(459, 107);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "账户额度信息";
            // 
            // m_rateTxt
            // 
            this.m_rateTxt.Location = new System.Drawing.Point(102, 73);
            this.m_rateTxt.Name = "m_rateTxt";
            this.m_rateTxt.Size = new System.Drawing.Size(146, 21);
            this.m_rateTxt.TabIndex = 10;
            this.m_rateTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_rateTxt_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "刷卡手续费率：";
            // 
            // AddAccountWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 430);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.applyBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddAccountWnd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加银行卡/账号";
            ((System.ComponentModel.ISupportInitialize)(this.billExpiredNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.billStartDayNUD)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox m_accountNameTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox creditAmountTxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button applyBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox numberTxt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker expiredDT;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown billExpiredNUD;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown billStartDayNUD;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox m_rateTxt;
        private System.Windows.Forms.Label label5;
    }
}