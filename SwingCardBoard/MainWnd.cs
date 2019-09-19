using System;
using System.IO;
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
        private AccountDB m_accountStatDB = new AccountDB();
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
            if (!Directory.Exists(@"data\"))
                Directory.CreateDirectory(@"data\");

            SetCurrentTime();

            m_accountStatDB.Load();
            InitAccountView(); 

            m_fundEventWnd = new FundChangeHistoryWnd();
            m_fundEventWnd.Hide();
        }

        private void SetCurrentTime()
        {
            var currentDate = DateTime.Now.ToLocalTime().Date;
            this.Text = "养卡记";
            this.m_dateLblabel1.Text = currentDate.Year + "年" + currentDate.Month + "月";
        }

        public void Reset()
        {
            ResetView();

            // history
            m_accountStatDB.Clean();
            m_fundEventWnd.Clean();
        }

        public void RemoveAccount(string account)
        {
            AccountBook.GetInstance().Remove(account);
            ResetView();
            m_accountStatDB.Remove(account);

            // TODO: 清除资金变动记录
        }

        public void UpdateAccount(Account account)
        {
            UpdateAccountView(account);
        }

        # region 当期账号状态记录
        private int m_totalRowIndex = -1;

        private void ResetView()
        {
            m_totalRowIndex = -1;
            m_accountStatisticsDgv.Rows.Clear();
            InitAccountView();
        }

        // TODO: to private replaced with mainWnd.AddAccount()
        public void AddAccountToView(Account account)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(m_accountStatisticsDgv);

            row.Cells[0].Value = account.Name;
            row.Cells[1].Value = account.LastBillStart.ToShortDateString() + " - " + account.LastBillEnd.ToShortDateString();
            row.Cells[2].Value = account.BillStartDay +"/"+account.BillExpiredDay;

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

            m_accountStatDB.Add(account);

            if (m_totalRowIndex != -1)
            {
                UpdateTotalAccountView();
            }
        }

        private void InitAccountView()
        {
            var font = new Font("微软雅黑", 9f, FontStyle.Regular);
            accountColumn.DefaultCellStyle.Font = font;
            billDate.DefaultCellStyle.Font = font;
            repayDayColumn.DefaultCellStyle.Font = font;
            creditAmount.DefaultCellStyle.Font = font;
            swingAmount.DefaultCellStyle.Font = font;
            chargeColumn.DefaultCellStyle.Font = font;
            avaliableAmount.DefaultCellStyle.Font = font;
            avaliableAmount.DefaultCellStyle.ForeColor = Color.Green;
            billAmount.DefaultCellStyle.Font = font;
            billAmount.DefaultCellStyle.ForeColor = Color.Red;
            repayAmount.DefaultCellStyle.Font = font;
            repayAmount.DefaultCellStyle.ForeColor = Color.Green;
            norepayAmount.DefaultCellStyle.Font = font;
            norepayAmount.DefaultCellStyle.ForeColor = Color.Red;
            swingAmount.DefaultCellStyle.ForeColor = Color.DarkBlue;
            chargeColumn.DefaultCellStyle.ForeColor = Color.DarkBlue;

            // 禁止排序
            for (int i = 0; i < m_accountStatisticsDgv.Columns.Count; i++)
            {
                m_accountStatisticsDgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            // 
            foreach (var account in AccountBook.GetInstance().GetAccounts())
            {
                AddAccountToView(account);
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

        private void SetAcountAmount(Account account, DataGridViewRow row)
        {
            row.Cells[2].Value = account.BillStartDay +"/"+account.BillExpiredDay;
            row.Cells[3].Value = Utility.FormatDoubleString(account.CreditAmount);
            row.Cells[4].Value = Utility.FormatDoubleString(account.AvaliableAmount);
            row.Cells[5].Value = Utility.FormatDoubleString(account.BillAmount);
            row.Cells[6].Value = Utility.FormatDoubleString(account.RepayAmount);
            row.Cells[7].Value = Utility.FormatDoubleString(account.NoRepayAmount);
            row.Cells[8].Value = Utility.FormatDoubleString(account.SwingAmount);
            row.Cells[9].Value =account.Charge.ToString();

            // 已还清
            if (account.NoRepayAmount - 0.0 <= 0.000001)
            {
                row.Cells[10].Value = "本期已还清";
                row.Cells[10].Style.ForeColor = Color.Green;
            }
            else
            {
                row.Cells[10].Value = "本期尚未还清";
                row.Cells[10].Style.ForeColor = Color.Red;
            }

            row.Cells[11].Value = account.LastDateTime;
        }

        private void UpdateAccountView(string name)
        {
            var account = AccountBook.GetInstance().FindAccount(name);
            UpdateAccountView(account);
        }

        private void UpdateAccountView(Account account)
        {
            int index = GetAccountRow(account.Name);
            var row = m_accountStatisticsDgv.Rows[index];

            SetAcountAmount(account, row);
            UpdateTotalAccountView();

            m_accountStatDB.Update(account);
        }

        // 用于更新总计栏
        private void InitTotalAccount()
        {
            m_totalRowIndex = m_accountStatisticsDgv.Rows.Add();
            SetTotalAccountAmount();
        }

        private void UpdateTotalAccountView()
        {
            AccountBook.GetInstance().UpdateTotalAccount();
            SetTotalAccountAmount();
        }

        private void SetTotalAccountAmount()
        {
            var font = new Font("微软雅黑", 9.5f, FontStyle.Bold);

            var row = m_accountStatisticsDgv.Rows[m_totalRowIndex];
            var account = AccountBook.GetInstance().TotalAccount;

            row.Cells[0].Value = account.Name;
            row.Cells[0].Style.Font = font;
            row.Cells[3].Value = Utility.FormatDoubleString(account.CreditAmount);
            row.Cells[3].Style.Font = font;
            row.Cells[4].Value = Utility.FormatDoubleString(account.AvaliableAmount);
            row.Cells[4].Style.Font = font;
            row.Cells[5].Value = Utility.FormatDoubleString(account.BillAmount);
            row.Cells[5].Style.Font = font;
            row.Cells[6].Value = Utility.FormatDoubleString(account.RepayAmount);
            row.Cells[6].Style.Font = font;
            row.Cells[7].Value = Utility.FormatDoubleString(account.NoRepayAmount);
            row.Cells[7].Style.Font = font;
            row.Cells[8].Value = Utility.FormatDoubleString(account.SwingAmount);
            row.Cells[8].Style.Font = font;
            row.Cells[9].Value = account.Charge.ToString();
            row.Cells[9].Style.Font = font;
        }

        // 鼠标放到刷卡明细单元格时显示当期所有刷卡明细
        private void m_accountStatisticsDgv_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8 && e.RowIndex >= 0 && e.RowIndex != m_totalRowIndex)
            {
                var row = m_accountStatisticsDgv.Rows[e.RowIndex];
                string accountName = row.Cells[0].Value.ToString();

                row.Cells[e.ColumnIndex].ToolTipText = null;

                var account = AccountBook.GetInstance().FindAccount(accountName);
                if (account.SwingEvents.Count != 0)
                {
                    row.Cells[e.ColumnIndex].ToolTipText = GenerateTipString(account.SwingEvents);
                }
            }
        }

        private string GenerateTipString(List<FundEvent> events)
        {
            string tip = "当期刷卡明细：\r\n";
            tip += "--------------------------------------\r\n";

            double total = 0.0;
            int times = 0;
            foreach (var eve in events)
            {
                tip += (++times).ToString() + "  " + eve.DateTime + ": " + Utility.FormatDoubleString(eve.Amount) + "元\r\n";
                total += eve.Amount;
            }

            tip += "--------------------------------------\r\n";
            tip += "总计:                            " + Utility.FormatDoubleString(total) + "元";

            return tip;
        }

        # endregion

        // 记录一笔刷卡记录
        private void takeNoteBtn_Click(object sender, EventArgs e)
        {
            AccountFundEventWnd eventWnd = new AccountFundEventWnd(this, "刷卡");
            if (DialogResult.OK == eventWnd.ShowDialog())
            {
                var account = eventWnd.Account;

                account.AddSwing(eventWnd.Amount, eventWnd.Charge);
                UpdateAccountView(account);
                m_fundEventWnd.AddFundChangeEvent(new FundEvent(account.Name, eventWnd.Amount, eventWnd.Charge, "刷卡", account.LastDateTime));
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

                UpdateAccountView(account);
                m_fundEventWnd.AddFundChangeEvent(new FundEvent(account.Name, eventWnd.Amount,0, "还款", account.LastDateTime));
            }
        }

        private void 账号管理ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AccountManageWnd wnd = new AccountManageWnd(this);
            wnd.ShowDialog();
        }

        private void 资金变动历史ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            m_fundEventWnd.Show();
        }

        private void 设置当期账单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetAccountBillWnd wnd = new SetAccountBillWnd(this);
            if (DialogResult.OK == wnd.ShowDialog())
            {
                var account = wnd.GetAccount();
                UpdateAccountView(account.Name);
                m_fundEventWnd.AddFundChangeEvent(new FundEvent(account.Name, account.BillAmount, "账单"));
            }
        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutWnd wnd = new AboutWnd();
            wnd.ShowDialog();
        }
    }
}
