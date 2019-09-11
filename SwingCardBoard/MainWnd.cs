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
        private FundChangeHistoryWnd m_fundEventWnd = null;

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
            InitAccountStatistics(); 

            m_fundEventWnd = new FundChangeHistoryWnd();
            m_fundEventWnd.Hide();
        }

        private void SetCurrentTime()
        {
            var currentDate = DateTime.Now.ToLocalTime().Date;
            m_dateLab.Text = currentDate.Year + "年" + currentDate.Month + "月" + currentDate.Day + "日";
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

                FundEvent eve = new FundEvent();
                eve.Account = account.Name;
                eve.Type = "刷卡";
                eve.Amount = eventWnd.Amount;
                eve.DateTime = account.LastDateTime;
                m_fundEventWnd.AddFundChangeEvent(eve);
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

                FundEvent eve = new FundEvent();
                eve.Account = account.Name;
                eve.Type = "还款";
                eve.Amount = eventWnd.Amount;
                eve.DateTime = account.LastDateTime;
                m_fundEventWnd.AddFundChangeEvent(eve);
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

        private void cardManageBtn_Click(object sender, EventArgs e)
        {
            AccountManageWnd wnd = new AccountManageWnd(this);
            wnd.ShowDialog();
        }

        private void m_showFundChangeEventsBtn_Click(object sender, EventArgs e)
        {
            m_fundEventWnd.Show();
        }

        # region 当期账号状态记录
        private int m_totalRowIndex = -1;
        private void InitAccountStatistics()
        {
            m_accountStatDB.Load();

            var font = new Font("微软雅黑", 9.5f, FontStyle.Regular);
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

            for (int i = 0; i < m_accountStatisticsDgv.Columns.Count; i++)
            {
                m_accountStatisticsDgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            // 
            foreach (var account in AccountBook.GetInstance().GetAccounts())
            {
                AddAccountStatistics(account);
            }

            InitTotalAccount();
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
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(m_accountStatisticsDgv);

            row.Cells[0].Value = account.Name;
            row.Cells[1].Value = account.BillStartDay + "/" + account.BillExpiredDay;
            row.Cells[2].Value = account.CreditAmount.ToString();

            SetAcountAmount(account, row);

            if (m_totalRowIndex != -1)
            {
                m_accountStatisticsDgv.Rows.Insert(m_accountStatisticsDgv.Rows.Count - 1, row);
                m_totalRowIndex++;
            }
            else
            {
                m_accountStatisticsDgv.Rows.Add(row);
            }

            m_accountStatDB.Update();
        }

        private void SetAcountAmount(Account account, DataGridViewRow row)
        {
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
            UpdateTotalAccountStatistics();

            m_accountStatDB.Update();
        }

        // 用于更新总计栏
        private void InitTotalAccount()
        {
            m_totalRowIndex = m_accountStatisticsDgv.Rows.Add();
            SetTotalAccountAmount();
        }

        private void UpdateTotalAccountStatistics()
        {
            AccountBook.GetInstance().UpdateTotalAccount();
            SetTotalAccountAmount();
        }

        private void SetTotalAccountAmount()
        {
            var font = new Font("微软雅黑", 11f, FontStyle.Bold);

            var row = m_accountStatisticsDgv.Rows[m_totalRowIndex];
            var account = AccountBook.GetInstance().TotalAccount;

            row.Cells[0].Value = account.Name;
            row.Cells[0].Style.Font = font;
            row.Cells[3].Value = account.AvaliableAmount.ToString();
            row.Cells[3].Style.Font = font;
            row.Cells[4].Value = account.BillAmount.ToString();
            row.Cells[4].Style.Font = font;
            row.Cells[5].Value = account.RepayAmount.ToString();
            row.Cells[5].Style.Font = font;
            row.Cells[6].Value = account.NoRepayAmount.ToString();
            row.Cells[6].Style.Font = font;
            row.Cells[7].Value = account.SwingAmount.ToString();
            row.Cells[7].Style.Font = font;
        }
        # endregion
    }
}
