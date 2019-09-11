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
    public partial class AccountFundEventWnd : Form
    {
        private Account m_account = null;
        public Account Account
        {
            get { return m_account; }
        }
        private double m_amount = 0.0;
        public double Amount
        {
            get { return m_amount; }
        }

        private MainWnd m_mainWnd = null;
        public AccountFundEventWnd(MainWnd mainWnd, string eventName)
        {
            InitializeComponent();

            this.Text += eventName;

            this.AcceptButton = m_applyBtn;
            this.CancelButton = m_cancelBtn;

            m_mainWnd = mainWnd;
            InitAccountList();
        }

        private void InitAccountList()
        {
            if (AccountBook.GetInstance().AccountCount == 0)
            {
                return;
            }

            m_cardComb.Items.AddRange(AccountBook.GetInstance().GetAccountNameList().ToArray());

            if (m_cardComb.Items.Count > 0)
            {
                m_cardComb.SelectedIndex = 0;
                SetCardNumber(0);
            }
        }

        private void addCardLab_Click(object sender, EventArgs e)
        {
            AddAccountWnd addWnd = new AddAccountWnd();
            if (DialogResult.OK != addWnd.ShowDialog())
                return;

            m_mainWnd.AddAccountStatistics(addWnd.NewAccount);
            InitAccountList();
        }

        private void SetCardNumber(int selectedIndex)
        {
            var account = AccountBook.GetInstance().GetAccounts()[selectedIndex];
            m_cardNumTxt.Text = account.Number;

            m_noRepayAmountTxt.Text = account.NoRepayAmount.ToString();
            m_avaliableAmountTxt.Text = account.AvaliableAmount.ToString();
        }

        private void m_cardComb_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetCardNumber(m_cardComb.SelectedIndex);
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            if (m_cardComb.SelectedIndex == -1)
            {
                MessageBox.Show(this, "请先选择一个信用卡/账号，如果没有请先添加一个！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var name = m_cardComb.SelectedItem.ToString();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show(this, "请先选择一个信用卡/账号，如果没有请先添加一个！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double bill = 0.0;
            try
            {
                bill = double.Parse(m_amoutTxt.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "请输入一个有效的金额！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var account = AccountBook.GetInstance().FindAccount(name);
            if (account == null)
            {
                MessageBox.Show(this, "账号不存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            account.LastDateTime = DateTime.Now.ToLocalTime().ToString();
            m_account = account;
            m_amount = bill;

            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
