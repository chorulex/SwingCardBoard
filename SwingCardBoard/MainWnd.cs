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
    public partial class MainWnd : Form
    {
        private CurrentAccountStatus m_accountStatDB = new CurrentAccountStatus();

        public MainWnd()
        {
            InitializeComponent();
        }

        private void MainWnd_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            SetCurrentTime();

            m_accountStatDB.Load();
            InitAccountStatistics();
        }

        private void SetCurrentTime()
        {
            var currentDate = DateTime.Now.ToLocalTime().Date;
            m_dateLab.Text = currentDate.Year + "年" + currentDate.Month + "月";
        }

        // 记录一笔刷卡记录
        private void takeNoteBtn_Click(object sender, EventArgs e)
        {
            AccountFundEventWnd eventWnd = new AccountFundEventWnd(this, "刷卡");
            if (DialogResult.OK == eventWnd.ShowDialog())
            {
                var account = eventWnd.Account;

                // 当期第一次刷卡时，刷卡总计和备用金是一样的。
                account.AddSwing(eventWnd.Amount);
                account.ReservedAmount = eventWnd.Amount;

                UpdateAccountStatistics(account);
            }
        }

        // 记一笔还款记录
        private void m_repayBtn_Click(object sender, EventArgs e)
        {
            AccountFundEventWnd eventWnd = new AccountFundEventWnd(this, "还卡");
            if (DialogResult.OK == eventWnd.ShowDialog())
            {
                var account = eventWnd.Account;
                account.AddRepay(eventWnd.Amount);

                UpdateAccountStatistics(account);
            }
        }

        private void addCardBtn_Click(object sender, EventArgs e)
        {
            AddAccountWnd addWnd = new AddAccountWnd();
            if (DialogResult.OK != addWnd.ShowDialog() && addWnd.NewAccount == null)
            {
                return;
            }

            addWnd.NewAccount.LastDateTime = DateTime.Now.ToLocalTime().ToString();
            AddAccountStatistics(addWnd.NewAccount);
        }

        private void m_setBillBtn_Click(object sender, EventArgs e)
        {
            SetAccountBillWnd wnd = new SetAccountBillWnd(this);
            if (DialogResult.OK == wnd.ShowDialog())
            {
                UpdateAccountStatistics(wnd.GetAccount());
            }
        }

        # region 当期账号状态记录
        private void InitAccountStatistics()
        {
            foreach (var account in AccountBook.GetInstance().GetAccounts())
            {
                AddAccountStatistics(account);
            }
        }

        private int GetAccountRow(string account)
        {
            for (int i = 0; i < m_accountStatisticsDgv.Rows.Count; i++)
            {
                if (m_accountStatisticsDgv.Rows[i].Cells[0].Value.ToString() == account)
                    return i;
            }

            return -1;
        }

        public void AddAccountStatistics(Account account)
        {
            int index = m_accountStatisticsDgv.Rows.Add();
            var row = m_accountStatisticsDgv.Rows[index];

            row.Cells[0].Value = account.Name;
            row.Cells[1].Value = account.BillStartDay + "/" + account.BillExpiredDay;
            row.Cells[2].Value = account.CreditAmount.ToString();

            SetAcountAmount(account, row);
            m_accountStatDB.Update();
        }

        private void SetAcountAmount(Account account, DataGridViewRow row)
        {
            var font = new Font("宋体", 9.5f, FontStyle.Bold);
            //billDate.DefaultCellStyle.Font = font;
            creditAmount.DefaultCellStyle.Font = font;
            swingAmount.DefaultCellStyle.Font = font;
            swingDetails.DefaultCellStyle.Font = font;

            avaliableAmount.DefaultCellStyle.Font = font;
            avaliableAmount.DefaultCellStyle.ForeColor = Color.Green;
            billAmount.DefaultCellStyle.Font = font;
            billAmount.DefaultCellStyle.ForeColor = Color.Red;
            repayAmount.DefaultCellStyle.Font = font;
            repayAmount.DefaultCellStyle.ForeColor = Color.Green;
            norepayAmount.DefaultCellStyle.Font = font;
            norepayAmount.DefaultCellStyle.ForeColor = Color.Red;

            row.Cells[3].Value = account.AvaliableAmount.ToString();
            row.Cells[4].Value = account.BillAmount.ToString();
            row.Cells[5].Value = account.RepayAmount.ToString();
            row.Cells[6].Value = account.NoRepayAmount.ToString();
            row.Cells[7].Value = account.SwingAmount.ToString();
            row.Cells[8].Value = account.ReservedAmount.ToString();

            // 已还清
            if (account.NoRepayAmount - 0.0 <= 0.000001)
            {
                row.Cells[9].Value = "（本期已还清）";
                row.Cells[9].Style.ForeColor = Color.Green;
            }
            else
            {
                row.Cells[9].Value = "（本期尚未还清）";
                row.Cells[9].Style.ForeColor = Color.Red;
            }

            row.Cells[10].Value = account.LastDateTime;
        }

        private void UpdateAccountStatistics(string name)
        {
            var account = AccountBook.GetInstance().FindAccount(name);
            UpdateAccountStatistics(account);
        }

        private void UpdateAccountStatistics(Account account)
        {
            int index = GetAccountRow(account.Name);
            var row = m_accountStatisticsDgv.Rows[index];

            SetAcountAmount(account, row);
            m_accountStatDB.Update();
        }
        # endregion
    }
}
