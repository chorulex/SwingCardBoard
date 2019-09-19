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

        // 刷卡手续费，仅在刷卡时有效！
        private double m_charge = 0.0;
        public double Charge
        {
            get { return m_charge; }
        }

        private bool m_withdraw = false;

        private MainWnd m_mainWnd = null;
        public AccountFundEventWnd(MainWnd mainWnd, string eventName)
        {
            InitializeComponent();

            this.Text += eventName;
            if (eventName == "刷卡")
            {
                m_withdraw = true;
            }
            else
            {
                m_chargeTxt.Enabled = false;
            }

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

            m_mainWnd.AddAccountToView(addWnd.NewAccount);
            InitAccountList();
        }

        private void SetCardNumber(int selectedIndex)
        {
            var account = AccountBook.GetInstance().GetAccounts()[selectedIndex];
            m_cardNumTxt.Text = account.Number;
            m_rateLb.Text = "刷卡手续费率：" + account.Rate.ToString();

            m_noRepayAmountTxt.Text = Utility.FormatDoubleString(account.NoRepayAmount);
            m_avaliableAmountTxt.Text = Utility.FormatDoubleString(account.AvaliableAmount);
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
            account.LastDateTime = Utility.GetCurrentDTString();
            m_account = account;
            m_amount = bill;
            m_charge = double.Parse(m_chargeTxt.Text);

            DialogResult = DialogResult.OK;
            this.Close();
        }

        // 调整数值显示格式
        private void m_amoutTxt_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(m_amoutTxt.Text))
            {
                m_chargeTxt.Text = "0.0";
                return;
            }

            double origin = double.Parse(Utility.ConvertToOrigin(m_amoutTxt.Text));
            m_amoutTxt.Text = Utility.FormatDoubleString(origin);
            Utility.SetSelectToLastest(m_amoutTxt);

            if (m_withdraw)
            {
                var account = AccountBook.GetInstance().FindAccount(m_cardComb.SelectedItem.ToString());
                if (account != null)
                {
                    m_chargeTxt.Text = (origin * account.Rate).ToString();
                }
            }
        }

        // 仅允许输入数值，且小数点后只能保留两位
        private void m_amoutTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.CheckTextBoxKeyPress(m_amoutTxt, sender, e);
        }

        private void m_chargeTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.CheckTextBoxKeyPress(m_amoutTxt, sender, e, 4);
        }
    }
}
