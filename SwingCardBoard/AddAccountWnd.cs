using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SwingCardBoard
{
    public partial class AddAccountWnd : Form
    {
        private Account m_newAccount = null;
        public Account NewAccount
        {
            get { return m_newAccount; }
        }

        // 添加新账号
        public AddAccountWnd()
        {
            InitializeComponent();
            this.AcceptButton = applyBtn;
            this.CancelButton = cancelBtn;
            this.billExpiredNUD.Maximum = 31;
            this.billExpiredNUD.Minimum = 1;
            this.m_rateTxt.Text = "0.0";
            this.Text = "添加新账号";
        }

        // 编辑更新
        public AddAccountWnd(Account account)
        {
            InitializeComponent();
            this.AcceptButton = applyBtn;
            this.CancelButton = cancelBtn;
            this.billExpiredNUD.Maximum = 31;
            this.billExpiredNUD.Minimum = 1;
            this.m_rateTxt.Text = "0.0";
            this.Text = "修改账号";

            // 账号不可更改！
            this.m_accountNameTxt.Enabled = false;
            this.m_accountNameTxt.Text = account.Name;
            this.expiredDT.Text = account.ExpiredDate;
            this.billExpiredNUD.Text = account.BillExpiredDay.ToString();
            this.billStartDayNUD.Text = account.BillStartDay.ToString();
            this.numberTxt.Text = account.Number;
            this.creditAmountTxt.Text = account.CreditAmount.ToString();
            this.m_rateTxt.Text = account.Rate.ToString();

            m_newAccount = account;
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            Account account = new Account();

            account.Name = m_accountNameTxt.Text.Trim();
            if (string.IsNullOrEmpty(account.Name))
            {
                MessageBox.Show(this, "请输入账户名称！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            account.Number = numberTxt.Text.Trim().Replace(" ","");
            account.ExpiredDate = expiredDT.Value.ToShortDateString();
            account.BillStartDay = int.Parse(billStartDayNUD.Value.ToString());
            account.BillExpiredDay = int.Parse(billExpiredNUD.Value.ToString());
            account.Rate = double.Parse(m_rateTxt.Text);

            string amountStr = creditAmountTxt.Text.Trim();
            if (string.IsNullOrEmpty(amountStr))
            {
                MessageBox.Show(this, "请输入信用额度!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                account.CreditAmount = double.Parse(amountStr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "请输入有效的信用额度!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (m_newAccount == null)
            {
                // 新增
                if (!AddAccount(account))
                {
                    return;
                }
            }
            else
            {
                // 更新
                UpdateAccount(account);
            }

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void UpdateAccount(Account account)
        {
            m_newAccount.Number = account.Number;
            m_newAccount.ExpiredDate = account.ExpiredDate;
            m_newAccount.BillExpiredDay = account.BillExpiredDay;
            m_newAccount.BillStartDay = account.BillStartDay;
            m_newAccount.CreditAmount = account.CreditAmount;
            m_newAccount.Rate = account.Rate;
        }

        private bool AddAccount(Account newAccount)
        {
            if (AccountBook.GetInstance().Exist(newAccount.Name))
            {
                string msg = "账号\"" + newAccount.Name + "\"已经存在！";
                MessageBox.Show(this, msg , "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            m_newAccount = newAccount;
            AccountBook.GetInstance().Add(newAccount);
            return true;
        }

        private void creditAmountTxt_TextChanged(object sender, EventArgs e)
        {
            creditAmountTxt.Text = Utility.FormatDoubleString(Utility.ConvertToOrigin(creditAmountTxt.Text.Trim()));
            Utility.SetSelectToLastest(creditAmountTxt);
        }

        private void creditAmountTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.CheckTextBoxKeyPress(creditAmountTxt, sender, e);
        }

        private void m_rateTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.CheckTextBoxKeyPress(m_rateTxt, sender, e, 4);
        }

        private void numberTxt_TextChanged(object sender, EventArgs e)
        {
            string text = numberTxt.Text.Replace(" ", "");
            numberTxt.Text = Utility.FormatAccountString(text);
            Utility.SetSelectToLastest(numberTxt);
        }

        private void numberTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
    }
}
