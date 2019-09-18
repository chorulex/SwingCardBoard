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

        public AddAccountWnd()
        {
            InitializeComponent();

            this.AcceptButton = applyBtn;
            this.CancelButton = cancelBtn;

            this.billExpiredNUD.Maximum = 31;
            this.billExpiredNUD.Minimum = 1;
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            Account account = new Account();

            account.Name = cardNameTxt.Text.Trim();
            account.Number = numberTxt.Text.Trim();
            account.ExpiredDate = expiredDT.Value.ToShortDateString();
            account.BillStartDay = int.Parse(billStartDayNUD.Value.ToString());
            account.BillExpiredDay = int.Parse(billExpiredNUD.Value.ToString());

            string amountStr = creditAmountTxt.Text.Trim();
            if (string.IsNullOrEmpty(amountStr))
            {
                MessageBox.Show(this, "请输入信用额度!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                account.CreditAmount = double.Parse(amountStr);
                account.AvaliableAmount = account.CreditAmount;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "请输入有效的信用额度!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            account.NoRepayAmount = account.BillAmount;
            if (AccountBook.GetInstance().ExistAccount(account.Name))
            {
                string msg = "账号\"" + account.Name + "\"已经存在，请使用其他的名称！";
                MessageBox.Show(this, msg , "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            m_newAccount = account;
            AccountBook.GetInstance().AddAccount(account);

            DialogResult = DialogResult.OK;
            this.Close();
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
    }
}
