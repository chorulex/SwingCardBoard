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
    public partial class FundChangeHistoryWnd : Form
    {
        private string m_currentAccount = "";
        private string m_currentEventType = "所有";
        private string m_currentYearMonth = "";

        public FundChangeHistoryWnd()
        {
            InitializeComponent();

            m_eventTypeComb.Items.Add("所有");
            m_eventTypeComb.Items.Add("刷卡");
            m_eventTypeComb.Items.Add("还款");
            m_eventTypeComb.SelectedIndex = 0;

            LoadAccountEvents();
            InitAccountView();
        }

        public void Clean()
        {
            m_fundEventDB.Clear();
            m_fundChangeLV.Clear();
        }

        void InitAccountView()
        {
            var root = m_accountTreeView.Nodes.Add("账号");

            var accounts = AccountBook.GetInstance().GetAll();
            foreach (var account in accounts)
            {
                var text = account.Name;
                text += " (卡号：" + account.Number + ")";
                var node = root.Nodes.Add(text);

                if (m_events.ContainsKey(account.Name))
                {
                    var dates = GetAccountEventsDateList(m_events[account.Name]);
                    if (dates != null && dates.Count > 0)
                    {
                        foreach (var date in dates)
                        {
                            node.Nodes.Add(date);
                        }
                    }
                }
            }
        }

        List<string> GetAccountEventsDateList(List<FundEvent> events)
        {
            if (events == null || events.Count == 0)
                return null;

            List<string> dates = new List<string>();
            foreach (var eve in events)
            {
                var date = eve.DateTime.Substring(0, 7); // 1900-01
                if (!dates.Contains(date))
                    dates.Add(date);
            }

            return dates;
        }

        #region 资金变动事件表
        HistoryFundEventDB m_fundEventDB = new HistoryFundEventDB();
        Dictionary<string, List<FundEvent>> m_events = null;

        void LoadAccountEvents()
        {
            m_events = m_fundEventDB.Load(AccountBook.GetInstance().GetAllAccountName());
        }

        void SaveToAccountCurrentSwingEvents(FundEvent eve)
        {
            var account = BillBook.GetInstance().Find(eve.Account);
            if (account != null && eve.Type == "刷卡")
                account.SwingEvents.Add(eve);
        }

        public void AddFundChangeEvent(FundEvent eve)
        {
            m_fundEventDB.AddNewFundEvent(eve);

            AddFundChangeEventToListView(eve);
            SaveToAccountCurrentSwingEvents(eve);
        }

        bool AddFundChangeEventToListView(FundEvent eve)
        {
            if (m_currentEventType == "所有" || eve.Type == m_currentEventType)
            {
                ListViewItem row = new ListViewItem();
                row.Text = (m_fundChangeLV.Items.Count + 1).ToString();
                row.SubItems.Add(eve.Account);
                row.SubItems.Add(eve.Type);
                row.SubItems.Add(eve.Amount.ToString());
                row.SubItems.Add(eve.Charge.ToString());
                row.SubItems.Add(eve.DateTime);
                m_fundChangeLV.Items.Add(row);

                return true;
            }

            return false;
        }
        #endregion

        private void FundChangeHistoryWnd_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*
            this.Hide();
            e.Cancel = true;
            */
        }

        private void m_accountTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var node = e.Node;
            if (node.Level == 1)
            {
                m_currentAccount = GetAccountName(node);
                ShowAccountFundEvents();
            }
            else if (node.Level == 2)
            {
                var accountNode = node.Parent;
                m_currentAccount = GetAccountName(accountNode);

                m_currentYearMonth = node.Text;
                ShowAccountFundEvents();
            }
        }

        private string GetAccountName(TreeNode node)
        {
            int pos = node.Text.IndexOf('(');
            if (pos == -1)
                return node.Text;

            return node.Text.Substring(0, pos).Trim();
        }

        private void ShowAccountFundEvents()
        {
            m_tipLB.Text = "共有 0 条记录";
            m_fundChangeLV.Items.Clear();

            if (!m_events.ContainsKey(m_currentAccount))
                return;

            var events = m_events[m_currentAccount];
            if (events == null || events.Count == 0)
                return;

            int count = 0;
            foreach (var eve in events)
            {
                if (string.IsNullOrEmpty(m_currentYearMonth))
                {
                    if (AddFundChangeEventToListView(eve))
                        count++;
                }
                else
                {
                    string begin = m_currentYearMonth + "-01 00:00:00";
                    string end = m_currentYearMonth + "-31 23:59:59";

                    if (begin.CompareTo(eve.DateTime) <= 0 && end.CompareTo(eve.DateTime) >= 0)
                    {
                        if (AddFundChangeEventToListView(eve))
                            count++;
                    }
                }
            }

            m_tipLB.Text = "共有 " + count.ToString() + " 条记录";
        }

        private void m_eventTypeComb_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = m_eventTypeComb.SelectedItem.ToString();
            if (type != m_currentEventType)
            {
                m_currentEventType = type;
                ShowAccountFundEvents();
            }
        }
    }
}
