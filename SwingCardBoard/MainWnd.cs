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
        private AccountBillDB m_billDB = new AccountBillDB();
        private AccountDB m_accountBD = new AccountDB();
        private HistoryFundEventDB m_fundEventDB = new HistoryFundEventDB();

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

            m_accountBD.Load();
            m_billDB.Load();
            InitBillView();

            LoadAccountSwingEvent();
        }

        private void SetCurrentTime()
        {
            var currentDate = DateTime.Now.ToLocalTime().Date;
            this.Text = "养卡记";
            this.m_dateLblabel1.Text = currentDate.Year + "年" + currentDate.Month + "月";
        }

        public void Clear()
        {
            // history
            m_billDB.Clear();
            m_accountBD.Clear();
            m_fundEventDB.Clear();
            var historyDB = new HistoryBillDB();
            historyDB.Clear();

            // cache
            AccountBook.GetInstance().Clear();
            BillBook.GetInstance().Clear();

            ResetView();
        }

        public void RemoveAccount(string account)
        {
            BillBook.GetInstance().Remove(account);
            ResetView();
            m_billDB.Remove(account);

            AccountBook.GetInstance().Remove(account);
            m_accountBD.Remove(account);

            m_fundEventDB.Remove(account);
        }

        public void UpdateAccount(Account account)
        {
            m_accountBD.Update(account);
            UpdateAccountBillView(account);
        }

        # region 当期账号状态记录
        private int m_totalRowIndex = -1;

        private void ResetView()
        {
            m_totalRowIndex = -1;
            m_billDgv.Rows.Clear();
            InitBillView();
        }

        public void AddAccountBillToView(Account account)
        {
            m_accountBD.Add(account);

            AccountBill bill = new AccountBill(account);
            BillBook.GetInstance().Add(bill);
            m_billDB.Add(bill);

            AddAccountBillToView(bill);
        }

        private void AddAccountBillToView(AccountBill bill)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(m_billDgv);

            row.Cells[0].Value = bill.Account.Name;
            row.Cells[1].Value = Utility.FormatDateString(bill.LastBillStart) + " - " + Utility.FormatDateString(bill.LastBillEnd);
            row.Cells[2].Value = bill.Account.BillStartDay + "/" + bill.Account.BillExpiredDay;

            SetAcountBillAmount(bill, row);

            if (m_totalRowIndex != -1)
            {
                m_billDgv.Rows.Insert(m_billDgv.Rows.Count - 1, row);
                m_totalRowIndex++;
            }
            else
            {
                m_billDgv.Rows.Add(row);
            }

            if (m_totalRowIndex != -1)
            {
                UpdateTotalAccountBillView();
            }
        }

        private void InitBillView()
        {
            var font = new Font("微软雅黑", 9f, FontStyle.Regular);

            accountColumn.DefaultCellStyle.Font = font;
            billDate.DefaultCellStyle.Font = font;
            repayDayColumn.DefaultCellStyle.Font = font;

            creditAmount.DefaultCellStyle.Font = font;
            creditAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            creditAmount.DefaultCellStyle.BackColor = Color.AntiqueWhite;

            avaliableAmount.DefaultCellStyle.Font = font;
            avaliableAmount.DefaultCellStyle.ForeColor = Color.Green;
            avaliableAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            avaliableAmount.DefaultCellStyle.BackColor = Color.Azure;

            billAmount.DefaultCellStyle.Font = font;
            billAmount.DefaultCellStyle.ForeColor = Color.Red;
            billAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            billAmount.DefaultCellStyle.BackColor = Color.BlanchedAlmond;

            repayAmount.DefaultCellStyle.Font = font;
            repayAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            repayAmount.DefaultCellStyle.ForeColor = Color.Green;

            norepayAmount.DefaultCellStyle.Font = font;
            norepayAmount.DefaultCellStyle.ForeColor = Color.Red;
            norepayAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            swingAmount.DefaultCellStyle.Font = font;
            swingAmount.DefaultCellStyle.ForeColor = Color.DarkBlue;
            swingAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            chargeColumn.DefaultCellStyle.Font = font;
            chargeColumn.DefaultCellStyle.ForeColor = Color.DarkBlue;
            chargeColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // 禁止排序
            for (int i = 0; i < m_billDgv.Columns.Count; i++)
            {
                m_billDgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            // 
            foreach (var account in BillBook.GetInstance().GetAll())
            {
                AddAccountBillToView(account);
            }

            InitTotalAccount();
        }

        private int GetAccountBillRow(string account)
        {
            for (int i = 0; i < m_billDgv.Rows.Count; i++)
            {
                if (m_billDgv.Rows[i].Cells[0].Value.ToString() == account)
                    return i;
            }

            return -1;
        }

        private void SetAcountBillAmount(AccountBill bill, DataGridViewRow row)
        {
            row.Cells[1].Value = Utility.FormatDateString(bill.LastBillStart) + " - " + Utility.FormatDateString(bill.LastBillEnd);
            row.Cells[2].Value = bill.Account.BillStartDay + "/" + bill.Account.BillExpiredDay;
            row.Cells[3].Value = Utility.ConvertDouble(bill.Account.CreditAmount);
            row.Cells[4].Value = Utility.ConvertDouble(bill.AvaliableAmount);
            row.Cells[5].Value = Utility.ConvertDouble(bill.BillAmount);
            row.Cells[6].Value = Utility.ConvertDouble(bill.RepayAmount);
            row.Cells[7].Value = Utility.ConvertDouble(bill.NoRepayAmount);
            row.Cells[8].Value = Utility.ConvertDouble(bill.SwingAmount);
            row.Cells[9].Value = bill.Charge.ToString();

            // 已还清
            if (bill.isRepayAll)
            {
                row.Cells[10].Value = "本期已还清";
                row.Cells[10].Style.ForeColor = Color.Green;
            }
            else
            {
                row.Cells[10].Value = "本期尚未还清";
                row.Cells[10].Style.ForeColor = Color.Red;
            }

            row.Cells[11].Value = bill.LastDateTime;
        }

        private void UpdateAccountBillView(string name)
        {
            var bill = BillBook.GetInstance().Find(name);
            UpdateAccountBillView(bill);
        }

        private void UpdateAccountBillView(Account account)
        {
            var bill = BillBook.GetInstance().Find(account.Name);
            bill.Account = account;
            UpdateAccountBillView(bill);
        }

        private void UpdateAccountBillView(AccountBill bill)
        {
            int index = GetAccountBillRow(bill.Account.Name);
            var row = m_billDgv.Rows[index];

            SetAcountBillAmount(bill, row);
            UpdateTotalAccountBillView();

            m_billDB.Update(bill);
        }

        // 用于更新总计栏
        private void InitTotalAccount()
        {
            m_totalRowIndex = m_billDgv.Rows.Add();
            SetTotalAccountAmount();
        }

        private void UpdateTotalAccountBillView()
        {
            BillBook.GetInstance().UpdateTotal();
            SetTotalAccountAmount();
        }

        private void SetTotalAccountAmount()
        {
            var font = new Font("微软雅黑", 9.5f, FontStyle.Bold);

            var row = m_billDgv.Rows[m_totalRowIndex];
            var bill = BillBook.GetInstance().TotalAccount;

            row.Cells[0].Value = bill.Account.Name;
            row.Cells[0].Style.Font = font;
            row.Cells[3].Value = Utility.ConvertDouble(bill.Account.CreditAmount);
            row.Cells[3].Style.Font = font;
            row.Cells[4].Value = Utility.ConvertDouble(bill.AvaliableAmount);
            row.Cells[4].Style.Font = font;
            row.Cells[5].Value = Utility.ConvertDouble(bill.BillAmount);
            row.Cells[5].Style.Font = font;
            row.Cells[6].Value = Utility.ConvertDouble(bill.RepayAmount);
            row.Cells[6].Style.Font = font;
            row.Cells[7].Value = Utility.ConvertDouble(bill.NoRepayAmount);
            row.Cells[7].Style.Font = font;
            row.Cells[8].Value = Utility.ConvertDouble(bill.SwingAmount);
            row.Cells[8].Style.Font = font;
            row.Cells[9].Value = bill.Charge.ToString();
            row.Cells[9].Style.Font = font;
        }

        // 鼠标放到刷卡明细单元格时显示当期所有刷卡明细
        private void m_accountStatisticsDgv_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8 && e.RowIndex >= 0 && e.RowIndex != m_totalRowIndex)
            {
                var row = m_billDgv.Rows[e.RowIndex];
                string accountName = row.Cells[0].Value.ToString();

                row.Cells[e.ColumnIndex].ToolTipText = null;

                var account = BillBook.GetInstance().Find(accountName);
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
                tip += (++times).ToString() + "  " + eve.DateTime + ": " + Utility.ConvertDouble(eve.Amount) + "元\r\n";
                total += eve.Amount;
            }

            tip += "--------------------------------------\r\n";
            tip += "总计:                            " + Utility.ConvertDouble(total) + "元";

            return tip;
        }
        # endregion

        #region fund events
        /// <summary>
        /// 加载当期账户刷卡明细
        /// </summary>
        void LoadAccountSwingEvent()
        {
            var m_events = m_fundEventDB.Load(AccountBook.GetInstance().GetAllAccountName());
            foreach (var accountItem in m_events)
            {
                var accountName = accountItem.Key;
                var account = BillBook.GetInstance().Find(accountName);
                if (account == null)
                    continue;

                var events = accountItem.Value;
                foreach (var eve in events)
                {
                    if (eve.Type == "刷卡" && eve.DateTime.CompareTo(Utility.FormatDateTimeString(account.LastBillEnd)) >= 0)
                    {
                        account.SwingEvents.Add(eve);
                    }
                }
            }
        }
        #endregion

        # region wnd event
        // 记录一笔刷卡记录
        private void takeNoteBtn_Click(object sender, EventArgs e)
        {
            AccountFundEventWnd eventWnd = new AccountFundEventWnd(this, "刷卡");
            if (DialogResult.OK == eventWnd.ShowDialog())
            {
                var accountName = eventWnd.AccountName;
                var dt = Utility.GetCurrentDTString();

                var bill = BillBook.GetInstance().Find(accountName);
                bill.AddSwing(eventWnd.Amount, eventWnd.Charge);
                bill.LastDateTime = dt;
                UpdateAccountBillView(bill);

                m_fundEventDB.AddNewFundEvent(new FundEvent(accountName, eventWnd.Amount, eventWnd.Charge, "刷卡", dt));
            }
        }

        // 记一笔还款记录
        private void m_repayBtn_Click(object sender, EventArgs e)
        {
            AccountFundEventWnd eventWnd = new AccountFundEventWnd(this, "还卡");
            if (DialogResult.OK == eventWnd.ShowDialog())
            {
                var accountName = eventWnd.AccountName;
                var dt = Utility.GetCurrentDTString();

                var bill = BillBook.GetInstance().Find(accountName);
                bill.AddRepay(eventWnd.Amount);

                UpdateAccountBillView(bill);
                m_fundEventDB.AddNewFundEvent(new FundEvent(accountName, eventWnd.Amount, 0, "还款", dt));
            }
        }

        // 查看往期账单
        private void m_historyBillBtn_Click(object sender, EventArgs e)
        {
            BillHistoryWnd wnd = new BillHistoryWnd();
            wnd.ShowDialog();
        }

        private void 账号管理ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AccountManageWnd wnd = new AccountManageWnd(this);
            wnd.ShowDialog();
        }

        private void 资金变动历史ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FundChangeHistoryWnd historyWnd = new FundChangeHistoryWnd();
            historyWnd.ShowDialog();
        }

        private void 设置当期账单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetAccountBillWnd wnd = new SetAccountBillWnd(this);
            if (DialogResult.OK == wnd.ShowDialog())
            {
                var newBill = wnd.Bill;
                var accountName = newBill.Account.Name;

                var oldBill = BillBook.GetInstance().Find(accountName);
                // 切换账单日期了，进入当期账单
                if (oldBill.LastBillEnd <= newBill.LastBillStart)
                {
                    HistoryBillDB db = new HistoryBillDB();
                    db.Add(oldBill);
                }

                // 覆盖旧账单，保存为当期账单
                BillBook.GetInstance().ResetBilll(newBill);
                UpdateAccountBillView(accountName);
                m_fundEventDB.AddNewFundEvent(new FundEvent(accountName, newBill.BillAmount, "账单"));
            }
        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutWnd wnd = new AboutWnd();
            wnd.ShowDialog();
        }
        #endregion

    }
}
