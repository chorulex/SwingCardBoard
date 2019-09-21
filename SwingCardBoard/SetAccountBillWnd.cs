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
    public partial class SetAccountBillWnd : Form
    {
        private AccountBill m_bill = null;
        public AccountBill Bill
        {
            get { return m_bill; }
        }

        private MainWnd m_mainWnd = null;
        public SetAccountBillWnd(MainWnd mainWnd)
        {
            InitializeComponent();

            this.AcceptButton = m_applyBtn;
            this.CancelButton = m_cancelBtn;

            m_mainWnd = mainWnd;
            InitAccountList();
        }

        private void InitBillDruction(string accountName)
        {
            AccountBill bill = BillBook.GetInstance().Find(accountName);
            if (Bill == null)
            {
                var lastBillStart = new DateTime();
                var lastBillEnd = new DateTime();
                Utility.CalcLastBillDruction(bill.Account.BillStartDay, ref lastBillStart, ref lastBillEnd);
                m_billDructionLB.Text = Utility.FormatDateString(lastBillStart) + " - " + Utility.FormatDateString(lastBillEnd);
            }
            else
            {
                m_billDructionLB.Text="";
            }
        }

        private void InitAccountList()
        {
            if (AccountBook.GetInstance().Count == 0)
                return;

            m_accountComb.Items.Clear();
            m_accountComb.Items.AddRange(AccountBook.GetInstance().GetAllAccountName().ToArray());

            if (m_accountComb.Items.Count > 0)
            {
                m_accountComb.SelectedIndex = 0;
                SetCardNumber(0);
            }
        }

        private void m_applyBtn_Click(object sender, EventArgs e)
        {
            if (m_accountComb.SelectedIndex == -1)
            {
                MessageBox.Show(this, "请先选择一个信用卡/账号，如果没有请先添加一个！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var name = m_accountComb.SelectedItem.ToString();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show(this, "请先选择一个信用卡/账号，如果没有请先添加一个！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double billVal = 0.0;
            try
            {
                billVal = double.Parse(m_billAmountTxt.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "请输入一个有效的账单金额！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double avaliable = 0.0;
            try
            {
                avaliable = double.Parse(m_avaliableAmountTxt.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "请输入一个有效的可用额度！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 使用一个新的对象与旧的账单区分开来
            Account account = AccountBook.GetInstance().Find(name);
            m_bill = new AccountBill(account);
            m_bill.LastDateTime = Utility.GetCurrentDTString();
            m_bill.AvaliableAmount = avaliable;
            m_bill.SetBillAmount(billVal);

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void m_accountComb_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetCardNumber(m_accountComb.SelectedIndex);
        }

        private void SetCardNumber(int selectedIndex)
        {
            var account = AccountBook.GetInstance().GetAll()[selectedIndex];
            m_cardNumberTxt.Text = account.Number;
            m_creditAmountTxt.Text = account.CreditAmount.ToString();
            InitBillDruction(account.Name);
        }

        private void m_initLab_Click(object sender, EventArgs e)
        {
            AddAccountWnd addWnd = new AddAccountWnd();
            if (DialogResult.OK != addWnd.ShowDialog())
                return;

            m_mainWnd.AddAccountBillToView(addWnd.NewAccount);
            InitAccountList();
        }

        private void m_avaliableAmountTxt_TextChanged(object sender, EventArgs e)
        {
            m_avaliableAmountTxt.Text = Utility.FormatDoubleString(Utility.ConvertToOrigin(m_avaliableAmountTxt.Text.Trim()));
            Utility.SetSelectToLastest(m_avaliableAmountTxt);

            var account = AccountBook.GetInstance().GetAll()[m_accountComb.SelectedIndex];
            string origin = Utility.ConvertToOrigin(m_avaliableAmountTxt.Text);
            if (origin.Length == 0)
            {
                m_billAmountTxt.Text = "0.0";
            }
            else
            {
                m_billAmountTxt.Text = Utility.FormatDoubleString(account.CreditAmount - double.Parse(origin));
            }
        }

        private void m_billAmountTxt_TextChanged(object sender, EventArgs e)
        {
            m_billAmountTxt.Text = Utility.FormatDoubleString(Utility.ConvertToOrigin(m_billAmountTxt.Text.Trim()));
            Utility.SetSelectToLastest(m_billAmountTxt);
        }

        private void m_avaliableAmountTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.CheckTextBoxKeyPress(m_avaliableAmountTxt, sender, e);
        }

        private void m_billAmountTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.CheckTextBoxKeyPress(m_billAmountTxt, sender, e);
        }

        private void m_creditAmountTxt_TextChanged(object sender, EventArgs e)
        {
            m_creditAmountTxt.Text = Utility.FormatDoubleString(Utility.ConvertToOrigin(m_creditAmountTxt.Text.Trim()));
        }
    }
}
