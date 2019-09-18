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
        public FundChangeHistoryWnd()
        {
            InitializeComponent();

            InitFundChangeEventView();
        }

        #region 资金变动事件表
        HistoryFundEventDB m_fundEventDB = new HistoryFundEventDB();
        Dictionary<string, ListViewGroup> m_accountGroup = new Dictionary<string, ListViewGroup>();
        void InitFundChangeEventView()
        {
            m_fundChangeLV.ShowGroups = true;

            var events = m_fundEventDB.Load();
            if (events == null || events.Count == 0)
            {
                return;
            }

            InitFundChangeGroupWithAccount(events);

            foreach (var eve in events)
            {
                AddFundChangeEventToListView(eve);
            }
        }

        void InitFundChangeGroupWithAccount(List<FundEvent> events)
        {
            foreach (var eve in events)
            {
                if (!m_accountGroup.ContainsKey(eve.Account))
                {
                    AddFundChangeGroup(eve.Account);
                }

                var account = AccountBook.GetInstance().FindAccount(eve.Account);
                if (account != null && eve.Type == "刷卡" && eve.DateTime.CompareTo(account.BillSetDate) >= 0)
                {
                    SaveToAccountCurrentSwingEvents(eve);
                }
            }
        }

        void SaveToAccountCurrentSwingEvents(FundEvent eve)
        {
            var account = AccountBook.GetInstance().FindAccount(eve.Account);
            if (account != null && eve.Type == "刷卡")
                account.SwingEvents.Add(eve);
        }

        ListViewGroup AddFundChangeGroup(string account)
        {
            ListViewGroup group = new ListViewGroup();
            group.Header = account;
            group.HeaderAlignment = HorizontalAlignment.Left;

            m_fundChangeLV.Groups.Add(group);
            m_accountGroup.Add(account, group);

            return group;
        }

        ListViewGroup FindAccountGroup(string account)
        {
            if (m_accountGroup.ContainsKey(account))
            {
                return m_accountGroup[account];
            }

            return null;
        }

        public void AddFundChangeEvent(FundEvent eve)
        {
            AddFundChangeEventToListView(eve);
            SaveToAccountCurrentSwingEvents(eve);
            m_fundEventDB.AddNewFundEvent(eve);
        }

        void AddFundChangeEventToListView(FundEvent eve)
        {
            var group = FindAccountGroup(eve.Account);
            if (group == null)
                group = AddFundChangeGroup(eve.Account);

            ListViewItem row = new ListViewItem();

            row.Text = (group.Items.Count + 1).ToString();
            row.SubItems.Add(eve.Account);
            row.SubItems.Add(eve.Type);
            row.SubItems.Add(eve.Amount.ToString());
            row.SubItems.Add(eve.DateTime);

            group.Items.Add(row);
            m_fundChangeLV.Items.Add(row);
        }
        #endregion

        private void FundChangeHistoryWnd_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

    }
}
