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
        }

        private void m_addAccountBtn_Click(object sender, EventArgs e)
        {
            AddAccountWnd addWnd = new AddAccountWnd();
            if (DialogResult.OK != addWnd.ShowDialog() && addWnd.NewAccount == null)
            {
                return;
            }

            var account = addWnd.NewAccount;

            account.LastDateTime = DateTime.Now.ToLocalTime().ToString();
            m_mainwnd.AddAccountStatistics(account);

            //
            AddAccountToView(account);
        }

        private void m_applyBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
