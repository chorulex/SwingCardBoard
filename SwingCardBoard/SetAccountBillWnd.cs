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
        private string m_account = null;
        public string GetAccount()
        {
            return m_account;
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

        private void InitAccountList()
        {
            if (AccountBook.GetInstance().AccountCount == 0)
                return;

            m_accountComb.Items.AddRange(AccountBook.GetInstance().GetAccountNameList().ToArray());

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

            double bill = 0.0;
            try
            {
                bill = double.Parse(m_billAmountTxt.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "请输入一个有效的金额！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double avaliable = 0.0;
            try
            {
                avaliable = double.Parse(m_avaliableAmountTxt.Text.Trim());
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
            account.AvaliableAmount = avaliable;
            account.SetBillAmount(bill);
            m_account = name;

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void m_accountComb_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetCardNumber(m_accountComb.SelectedIndex);
        }

        private void SetCardNumber(int selectedIndex)
        {
            m_cardNumberTxt.Text = AccountBook.GetInstance().GetAccounts()[selectedIndex].Number;
        }

        private void m_initLab_Click(object sender, EventArgs e)
        {
            AddAccountWnd addWnd = new AddAccountWnd();
            if (DialogResult.OK != addWnd.ShowDialog())
                return;

            m_mainWnd.AddAccountStatistics(addWnd.NewAccount);
            InitAccountList();
        }
    }
}
