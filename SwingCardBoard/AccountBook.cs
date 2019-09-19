using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwingCardBoard
{
    public class Account
    {
        // 区分Account的唯一标识
        private string m_name;
        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        // 设置当期账单时的日期
        private string m_billSetDate;
        public string BillSetDate
        {
            get { return m_billSetDate; }
            set { m_billSetDate = value; }
        }

        /// <summary>
        /// 当期所有刷卡记录
        /// </summary>
        private List<FundEvent> m_swingEvents = new List<FundEvent>();
        public List<FundEvent> SwingEvents
        {
            get { return m_swingEvents; }
            set { m_swingEvents = value; }
        }

        private string m_lastDateTime;
        public string LastDateTime
        {
            get { return m_lastDateTime; }
            set { m_lastDateTime = value; }
        }

        private string m_number;
        public string Number
        {
            get { return m_number; }
            set { m_number = value; }
        }

        // 信用卡期日
        private string m_expiredDate;
        public string ExpiredDate
        {
            get { return m_expiredDate; }
            set { m_expiredDate = value; }
        }

        // 每月账单出账日,[1,31]
        private int m_billStartDay;
        public int BillStartDay
        {
            get { return m_billStartDay; }
            set
            {
                m_billStartDay = value;
                CalcLastBillDruction();
            }
        }

        // 计算出该账户上一期账单时间范围
        public DateTime LastBillEnd { get; set; }
        public DateTime LastBillStart { get; set; }
        public void CalcLastBillDruction()
        {
            DateTime now = DateTime.Now.ToLocalTime();
            if (now.Day <= m_billStartDay)
            {
                if (now.Month - 1 == 0)
                {
                    LastBillEnd = new DateTime(now.Year - 1, 12, m_billStartDay);
                }
                else
                {
                    LastBillEnd = new DateTime(now.Year, now.Month - 1, m_billStartDay);
                }
            }
            else
            {
                LastBillEnd = new DateTime(now.Year, now.Month, m_billStartDay);
            }

            if (LastBillEnd.Month - 1 == 0)
            {
                LastBillStart = new DateTime(now.Year - 1, 12, m_billStartDay);
            }
            else
            {
                LastBillStart = new DateTime(now.Year, LastBillEnd.Month -1 , m_billStartDay);
            }
            LastBillStart = LastBillStart.AddDays(1);
        }

        // 每月最后还款日,[1,31]
        private int m_billExpiredDay;
        public int BillExpiredDay
        {
            get { return m_billExpiredDay; }
            set { m_billExpiredDay = value; }
        }

        // 可用金额
        private double m_avaliableAmount;
        public double AvaliableAmount
        {
            get { return m_avaliableAmount; }
            set { m_avaliableAmount = value; }
        }

        // 信用金额
        private double m_creditAmount;
        public double CreditAmount
        {
            get { return m_creditAmount; }
            set { m_creditAmount = value; }
        }

        // 账单金额
        private double m_billAmount;
        public double BillAmount
        {
            get { return m_billAmount; }
            set { m_billAmount = value; }
        }

        // 刷卡金额总计
        private double m_swingAmount = 0.0;
        public double SwingAmount
        {
            get { return m_swingAmount; }
            set { m_swingAmount = value; }
        }

        // 刷卡手续费
        public double Charge { get; set; }

        // 刷卡手续费率
        public double Rate { get; set; }

        // 未还金额：当前未还，但不包含出账后的任何消费项
        private double m_noRepayAmount = 0.0;
        public double NoRepayAmount
        {
            get { return m_noRepayAmount; }
            set { m_noRepayAmount = value; }
        }

        // 已还金额
        private double m_repayAmount = 0.0;
        public double RepayAmount
        {
            get { return m_repayAmount; }
            set { m_repayAmount = value; }
        }

        public void SetBillAmount(double bill)
        {
            m_billAmount = bill;
            m_noRepayAmount = bill;
            m_repayAmount = 0;
            m_swingAmount = 0;
            Charge = 0;

            // m_avaliableAmount = m_creditAmount - m_billAmount - m_swingAmount;
            m_billSetDate = Utility.GetCurrentDTString();
            m_swingEvents.Clear();
        }

        // 刷卡
        public void AddSwing(double amount, double charge)
        {
            m_swingAmount += amount;
            m_avaliableAmount -= amount;
            Charge += charge;
        }

        // 还款
        public void AddRepay(double amount)
        {
            m_repayAmount += amount;
            m_avaliableAmount += amount;
            m_noRepayAmount -= amount;
        }
    }

    // 单例
    class AccountBook
    {
        static private AccountBook m_instance = null;
        private AccountBook()
        {

        }
        static public AccountBook GetInstance()
        {
            if (m_instance == null)
            {
                m_instance = new AccountBook();
                m_instance.m_totalAccount.Name = "总计";
            }
            return m_instance;
        }

        private Dictionary<string, Account> m_acounts = new Dictionary<string, Account>();
        public int AccountCount
        {
            get { return m_acounts.Count; }
        }

        // 所有账户总计
        private Account m_totalAccount = new Account();
        public Account TotalAccount
        {
            get { return m_totalAccount; }
            set { m_totalAccount = value; }
        }

        public void RemoveAll()
        {
            m_acounts.Clear();
            UpdateTotalAccount();
        }

        public void Remove(string account)
        {
            if (m_acounts.ContainsKey(account))
            {
                m_acounts.Remove(account);
                UpdateTotalAccount();
            }
        }

        public List<Account> GetAccounts()
        {
            return m_acounts.Values.ToList();
        }

        public List<string> GetAccountNameList()
        {
            List<string> list = null;
            if (m_acounts.Count > 0)
            {
                list = new List<string>();

                foreach (var account in GetAccounts())
                {
                    list.Add(account.Name);
                }
            }

            return list;
        }

        public bool ExistAccount(string name)
        {
            return m_acounts.ContainsKey(name);
        }

        public bool AddAccount(Account card)
        {
            m_acounts.Add(card.Name, card);

            UpdateTotalAccount(card);
            return true;
        }

        public Account FindAccount(string name)
        {
            if (!ExistAccount(name))
                return null;

            return m_acounts[name];
        }

        public void UpdateTotalAccount()
        {
            // 先清空，然后重新计算。
            m_totalAccount.CreditAmount = 0;
            m_totalAccount.AvaliableAmount = 0;
            m_totalAccount.BillAmount = 0;
            m_totalAccount.RepayAmount = 0;
            m_totalAccount.NoRepayAmount = 0;
            m_totalAccount.SwingAmount = 0;
            m_totalAccount.Charge = 0;

            foreach (var account in AccountBook.GetInstance().GetAccounts())
            {
                UpdateTotalAccount(account);
            }
        }

        public void UpdateTotalAccount(Account account)
        {
            m_totalAccount.CreditAmount += account.CreditAmount;
            m_totalAccount.AvaliableAmount += account.AvaliableAmount;
            m_totalAccount.BillAmount += account.BillAmount;
            m_totalAccount.RepayAmount += account.RepayAmount;
            m_totalAccount.NoRepayAmount += account.NoRepayAmount;
            m_totalAccount.SwingAmount += account.SwingAmount;
            m_totalAccount.Charge += account.Charge;
        }
    }
}
