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
        public string AccountName { get; set; }
        // 刷卡手续费，仅在刷卡时有效！
        public double Charge { get; set; }
        public double Amount{get;set;}

        private MainWnd m_mainWnd = null;
        private bool m_withdraw = false;

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
            this.m_chargeTxt.Text = "0.0";

            m_mainWnd = mainWnd;
            InitAccountList();
        }

        private void InitAccountList()
        {
            if (AccountBook.GetInstance().Count == 0)
            {
                return;
            }

            m_accountComb.Items.Clear();
            m_accountComb.Items.AddRange(AccountBook.GetInstance().GetAllAccountName().ToArray());

            if (m_accountComb.Items.Count > 0)
            {
                m_accountComb.SelectedIndex = 0;
                SetCardNumber(0);
            }
        }

        private void addCardLab_Click(object sender, EventArgs e)
        {
            AddAccountWnd addWnd = new AddAccountWnd();
            if (DialogResult.OK != addWnd.ShowDialog())
                return;

            m_mainWnd.AddAccountBillToView(addWnd.NewAccount);
            InitAccountList();
        }

        private void SetCardNumber(int selectedIndex)
        {
            var bill = BillBook.GetInstance().GetAll()[selectedIndex];
            m_cardNumTxt.Text = Utility.FormatAccountString(bill.Account.Number);
            m_rateLb.Text = "刷卡手续费率：" + bill.Account.Rate.ToString();

            m_noRepayAmountTxt.Text = Utility.ConvertDouble(bill.NoRepayAmount);
            m_avaliableAmountTxt.Text = Utility.ConvertDouble(bill.AvaliableAmount);
        }

        private void m_cardComb_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetCardNumber(m_accountComb.SelectedIndex);
        }

        private void applyBtn_Click(object sender, EventArgs e)
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
                bill = double.Parse(m_amoutTxt.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "请输入一个有效的金额！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AccountName = name;
            Amount = bill;
            Charge = double.Parse(m_chargeTxt.Text);

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

            m_amoutTxt.Text = Utility.FormatDoubleString(Utility.ConvertToOrigin(m_amoutTxt.Text));
            Utility.SetSelectToLastest(m_amoutTxt);

            if (m_withdraw)
            {
                var bill = BillBook.GetInstance().Find(m_accountComb.SelectedItem.ToString());
                if (bill != null)
                {
                    double origin = double.Parse(Utility.ConvertToOrigin(m_amoutTxt.Text));
                    m_chargeTxt.Text = (origin * bill.Account.Rate).ToString();
                }
            }
        }

        // 仅允许输入数值，且小数点后只能保留两位
        private void m_amoutTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.CheckTextBoxKeyPress(m_amoutTxt, sender, e,2);
        }

        private void m_chargeTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utility.CheckTextBoxKeyPress(m_chargeTxt, sender, e, 4);
        }

        private void m_chargeTxt_TextChanged(object sender, EventArgs e)
        {
            m_chargeTxt.Text = Utility.FormatDoubleString(Utility.ConvertToOrigin(m_chargeTxt.Text.Trim()));
            Utility.SetSelectToLastest(m_chargeTxt);
        }
    }
}
