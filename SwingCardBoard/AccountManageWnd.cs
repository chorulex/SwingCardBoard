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
    public partial class AccountManageWnd : Form
    {
        private MainWnd m_mainwnd = null;
        public AccountManageWnd(MainWnd wnd)
        {
            InitializeComponent();

            this.AcceptButton = m_applyBtn;
            this.CancelButton = m_cancelBtn;
            m_mainwnd = wnd;

            InitAccountStatistics();
        }

        private void InitAccountStatistics()
        {
            var font = new Font("宋体", 9.5f, FontStyle.Bold);
            creditAmount.DefaultCellStyle.Font = font;
            creditAmount.DefaultCellStyle.ForeColor = Color.Green;
            creditAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            rateColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            foreach (var account in AccountBook.GetInstance().GetAccounts())
            {
                AddAccountToView(account);
            }
        }

        private void AddAccountToView(Account account)
        {
            int index = m_accountListDGV.Rows.Add();
            var row = m_accountListDGV.Rows[index];

            row.Cells[0].Value = account.Name;
            row.Cells[1].Value = account.Number;
            row.Cells[2].Value = account.BillStartDay;
            row.Cells[3].Value = account.BillExpiredDay;
            row.Cells[4].Value = account.CreditAmount.ToString();
            row.Cells[5].Value = account.Rate.ToString();
            row.Cells[6].Value = "删除";
            row.Cells[7].Value = "编辑";
        }

        private Account GetAccountInView(int rowIndex)
        {
            string accountName = m_accountListDGV.Rows[rowIndex].Cells[0].Value.ToString();
            return AccountBook.GetInstance().FindAccount(accountName);
        }

        private void m_addAccountBtn_Click(object sender, EventArgs e)
        {
            AddAccountWnd addWnd = new AddAccountWnd();
            if (DialogResult.OK != addWnd.ShowDialog() && addWnd.NewAccount == null)
            {
                return;
            }

            var account = addWnd.NewAccount;

            account.LastDateTime = Utility.GetCurrentDTString();
            m_mainwnd.AddAccountToView(account);

            //
            AddAccountToView(account);
        }

        private void m_applyBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void m_cleanBtn_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show(this, "该操作会删除所有数据包括历史操作记录，删除后不可恢复！\r\n你确定清空吗？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                CleanAccounts();
            }
        }

        private void CleanAccounts()
        {
            AccountBook.GetInstance().RemoveAll();

            m_accountListDGV.Rows.Clear();
            m_mainwnd.Reset();
        }

        private void m_accountListDGV_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            Account account = GetAccountInView(e.RowIndex);

            // 删除
            if (e.ColumnIndex == 6)
            {
                if (DialogResult.No == MessageBox.Show(this, "删除后不可恢复！确定删除吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    return;
                }

                m_accountListDGV.Rows.RemoveAt(e.RowIndex);
                m_mainwnd.RemoveAccount(account.Name);
                return;
            }

            if (e.ColumnIndex == 7)
            {
                AddAccountWnd addWnd = new AddAccountWnd(account);
                if (DialogResult.OK != addWnd.ShowDialog() && addWnd.NewAccount == null)
                {
                    return;
                }

                Account newAccount = addWnd.NewAccount;
                m_mainwnd.UpdateAccount(newAccount);
                m_accountListDGV.Rows[e.RowIndex].Cells[2].Value = account.BillStartDay;
                m_accountListDGV.Rows[e.RowIndex].Cells[3].Value = account.BillExpiredDay;
                m_accountListDGV.Rows[e.RowIndex].Cells[4].Value = account.CreditAmount.ToString();
                m_accountListDGV.Rows[e.RowIndex].Cells[5].Value = account.Rate.ToString();
                return;
            }
        }
    }
}
