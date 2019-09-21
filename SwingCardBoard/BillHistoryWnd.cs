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
    public partial class BillHistoryWnd : Form
    {
        /// <summary>
        /// 按账户保存对应的历史账单
        /// </summary>
        private Dictionary<string, List<AccountBill>> m_accountBills = new Dictionary<string, List<AccountBill>>();

        /// <summary>
        /// 按年月保存历史账单
        /// </summary>
        private Dictionary<string, List<AccountBill>> m_dtBills = new Dictionary<string, List<AccountBill>>();

        private bool m_showByMonth = true;

        public BillHistoryWnd()
        {
            InitializeComponent();
        }

        private void BillHistoryWnd_Load(object sender, EventArgs e)
        {
            m_showByAccountRB.Checked = false;
            m_showByDTRb.Checked = true;
            m_showByMonth = true;

            InitDGV();
            if (LoadAllHistory())
            {
                ShowHistory();
            }
        }

        private void InitDGV()
        {
            var font = new Font("微软雅黑", 9f, FontStyle.Regular);

            accountColumn.DefaultCellStyle.Font = font;
            billDate.DefaultCellStyle.Font = font;

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
        }

        private bool LoadAllHistory()
        {
            HistoryBillDB db = new HistoryBillDB();
            var bills = db.Load();
            if (bills == null || bills.Count == 0)
                return false;

            WashBills(bills);
            return true;
        }

        private void WashBills(List<AccountBill> bills)
        {
            foreach (var bill in bills)
            {
                AddAccountBill(bill);
                AddYearmonthBill(bill);
            }
        }

        private void ShowHistory()
        {
            if (m_showByMonth)
                ShowByMonth();
            else
                ShowByAccount();
        }

        private void ShowByMonth()
        {
            if (m_dtBills.Count == 0)
                return;

            foreach (var bills in m_dtBills)
            {
                AddBlackRowWithTitle(bills.Key);

                AccountBill total = new AccountBill();
                total.Account.Name = "总计";
                foreach (var bill in bills.Value)
                {
                    total.Account.CreditAmount += bill.Account.CreditAmount;
                    total.AvaliableAmount += bill.AvaliableAmount;
                    total.BillAmount += bill.BillAmount;
                    total.RepayAmount += bill.RepayAmount;
                    total.NoRepayAmount += bill.NoRepayAmount;
                    total.SwingAmount += bill.SwingAmount;
                    total.Charge += bill.Charge;

                    AddAccountBillToView(bill);
                }

                AddTotalBill(total);
                AddBlackRow();
            }
        }

        private void ShowByAccount()
        {
            if (m_accountBills.Count == 0)
                return;

            foreach (var bills in m_accountBills)
            {
                AddBlackRowWithTitle(bills.Key);

                foreach (var bill in bills.Value)
                {
                    AddAccountBillToView(bill);
                }

                AddBlackRow();
            }
        }

        private void AddTotalBill(AccountBill total)
        {
            int rowIndex = m_billDgv.Rows.Add();
            for(int i=0;i<11;i++)
            {
                m_billDgv.Rows[rowIndex].Cells[i].Style.BackColor = Color.Coral;
            }

            SetTotalAccountAmount(m_billDgv.Rows[rowIndex], total);
        }

        private void SetTotalAccountAmount(DataGridViewRow row, AccountBill bill)
        {
            var font = new Font("微软雅黑", 9.5f, FontStyle.Bold);

            row.Cells[0].Value = bill.Account.Name;
            row.Cells[0].Style.Font = font;
            row.Cells[2].Value = Utility.ConvertDouble(bill.Account.CreditAmount);
            row.Cells[2].Style.Font = font;
            row.Cells[3].Value = Utility.ConvertDouble(bill.AvaliableAmount);
            row.Cells[3].Style.Font = font;
            row.Cells[4].Value = Utility.ConvertDouble(bill.BillAmount);
            row.Cells[4].Style.Font = font;
            row.Cells[5].Value = Utility.ConvertDouble(bill.RepayAmount);
            row.Cells[5].Style.Font = font;
            row.Cells[6].Value = Utility.ConvertDouble(bill.NoRepayAmount);
            row.Cells[6].Style.Font = font;
            row.Cells[7].Value = Utility.ConvertDouble(bill.SwingAmount);
            row.Cells[7].Style.Font = font;
            row.Cells[8].Value = bill.Charge.ToString();
            row.Cells[8].Style.Font = font;
        }

        private void AddAccountBill(AccountBill bill)
        {
            var account = bill.Account.Name;
            if (!m_accountBills.ContainsKey(account))
            {
                var bills = new List<AccountBill>();
                m_accountBills.Add(account, bills);
            }

            m_accountBills[account].Add(bill);
        }

        private void AddYearmonthBill(AccountBill bill)
        {
            // 格式：1900-01
            var billDate = Utility.FormatDateString(bill.LastBillStart).Substring(0, 7);
            if (!m_dtBills.ContainsKey(billDate))
            {
                var bills = new List<AccountBill>();
                m_dtBills.Add(billDate, bills);
            }

            m_dtBills[billDate].Add(bill);
        }

        private void AddBlackRow()
        {
            var rowIndex = m_billDgv.Rows.Add();
        }

        private void AddBlackRowWithTitle(string title)
        {
            var rowIndex = m_billDgv.Rows.Add();
            m_billDgv.Rows[rowIndex].Cells[0].Value = title;
            m_billDgv.Rows[rowIndex].Cells[0].Style.ForeColor = Color.Blue;
        }

        private void AddAccountBillToView(AccountBill bill)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(m_billDgv);

            row.Cells[0].Value = bill.Account.Name;
            row.Cells[1].Value = Utility.FormatDateString(bill.LastBillStart) + " - " + Utility.FormatDateString(bill.LastBillEnd);

            SetAcountBillAmount(bill, row);
            m_billDgv.Rows.Add(row);
        }

        private void SetAcountBillAmount(AccountBill bill, DataGridViewRow row)
        {
            row.Cells[1].Value = Utility.FormatDateString(bill.LastBillStart) + " - " + Utility.FormatDateString(bill.LastBillEnd);
            row.Cells[2].Value = Utility.ConvertDouble(bill.Account.CreditAmount);
            row.Cells[3].Value = Utility.ConvertDouble(bill.AvaliableAmount);
            row.Cells[4].Value = Utility.ConvertDouble(bill.BillAmount);
            row.Cells[5].Value = Utility.ConvertDouble(bill.RepayAmount);
            row.Cells[6].Value = Utility.ConvertDouble(bill.NoRepayAmount);
            row.Cells[7].Value = Utility.ConvertDouble(bill.SwingAmount);
            row.Cells[8].Value = bill.Charge.ToString();

            // 已还清
            if (bill.isRepayAll)
            {
                row.Cells[9].Value = "本期已还清";
                row.Cells[9].Style.ForeColor = Color.Green;
            }
            else
            {
                row.Cells[9].Value = "本期尚未还清";
                row.Cells[9].Style.ForeColor = Color.Red;
            }

            row.Cells[10].Value = bill.LastDateTime;
        }

        private void m_showByAccountRB_CheckedChanged(object sender, EventArgs e)
        {
            m_showByMonth = false;
            m_billDgv.Rows.Clear();
            ShowHistory();
        }

        private void m_showByDTRb_CheckedChanged(object sender, EventArgs e)
        {
            m_showByMonth = true;
            m_billDgv.Rows.Clear();
            ShowHistory();
        }
    }
}
