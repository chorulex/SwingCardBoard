using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwingCardBoard
{
    public class Account
    {
        // 区分Account的唯一标识
        public string Name { get; set; }

        // 卡号或者账号标记
        public string Number{get;set;}

        // 到期日
        public string ExpiredDate {get;set;}

        // 每月账单出账日,[1,31]
        public int BillStartDay {get ;set;}

        // 每月最后还款日,[1,31]
        public int BillExpiredDay {get;set;}

        // 信用金额
        public double CreditAmount {get;set;}

        // 刷卡手续费率
        public double Rate { get; set; }

    }

    /// <summary>
    /// 账号的当期账单信息
    /// </summary>
    public class AccountBill
    {
        private Account m_account = null;
        public Account Account
        {
            get { return m_account; }
            set
            {
                m_account = value;

                var lastBillStart = new DateTime();
                var lastBillEnd = new DateTime();
                Utility.CalcLastBillDruction(Account.BillStartDay, ref lastBillStart, ref lastBillEnd);
                LastBillEnd = lastBillEnd;
                LastBillStart = lastBillStart;
            }
        }

        public AccountBill()
        {
            m_account = new Account();
        }
        public AccountBill(Account account)
        {
            Account = account;
        }

        // 设置当期账单时的日期
        private string m_billSetDate;
        public string BillSetDate
        {
            get { return m_billSetDate; }
            set { m_billSetDate = value; }
        }

        /// <summary>
        ///  上次操作日期时间
        /// </summary>
        public string LastDateTime { get;set;}

        // 该账户上一期账单时间范围
        public DateTime LastBillEnd { get; set; }
        public DateTime LastBillStart { get; set; }

        // 可用金额
        public double AvaliableAmount {get; set;}

        // 账单金额
        public double BillAmount {get; set;}

        /// <summary>
        /// 当期所有刷卡记录
        /// </summary>
        private List<FundEvent> m_swingEvents = new List<FundEvent>();
        public List<FundEvent> SwingEvents
        {
            get { return m_swingEvents; }
            set { m_swingEvents = value; }
        }

        // 刷卡金额总计
        public double SwingAmount {get; set;}

        // 刷卡手续费
        public double Charge { get; set; }

        // 未还金额：当前未还，但不包含出账后的任何消费项
        public double NoRepayAmount {get; set;}
        public bool isRepayAll
        {
            get
            {
                return NoRepayAmount - 0.0 <= 0.000001;
            }
        }

        // 已还金额
        public double RepayAmount {get; set;}

        public void SetBillAmount(double bill)
        {
            BillAmount = bill;
            NoRepayAmount = bill;
            RepayAmount = 0;
            SwingAmount = 0;
            Charge = 0;

            // m_avaliableAmount = m_creditAmount - m_billAmount - m_swingAmount;
            m_billSetDate = Utility.GetCurrentDTString();
            m_swingEvents.Clear();
        }

        // 刷卡
        public void AddSwing(double amount, double charge)
        {
            SwingAmount += amount;
            AvaliableAmount -= amount;
            Charge += charge;
        }

        // 还款
        public void AddRepay(double amount)
        {
            RepayAmount += amount;
            AvaliableAmount += amount;
            NoRepayAmount -= amount;
        }
    }

    /// <summary>
    /// 所有账户
    /// 单例模式
    /// </summary>
    public class AccountBook
    {
        private AccountBook()
        {

        }

        private static  AccountBook m_instance = null;
        public static AccountBook GetInstance()
        {
            if (m_instance == null)
            {
                m_instance = new AccountBook();
            }

            return m_instance;
        }

        private Dictionary<string, Account> m_acounts = new Dictionary<string, Account>();
        public int Count
        {
            get { return m_acounts.Count; }
        }
        public List<Account> GetAll()
        {
            return m_acounts.Values.ToList();
        }

        public void Clear()
        {
            m_acounts.Clear();
        }

        public List<string> GetAllAccountName()
        {
            List<string> list = null;
            if (m_acounts.Count > 0)
            {
                list = new List<string>();

                foreach (var account in m_acounts)
                {
                    list.Add(account.Value.Name);
                }
            }

            return list;
        }

        public void Remove(string name)
        {
            if (m_acounts.ContainsKey(name))
            {
                m_acounts.Remove(name);
            }
        }

        public bool Exist(string name)
        {
            return m_acounts.ContainsKey(name);
        }

        public bool Add(Account account)
        {
            m_acounts.Add(account.Name, account);
            return true;
        }

        public Account Find(string name)
        {
            if (!Exist(name))
                return null;

            return m_acounts[name];
        }
    }

    /// <summary>
    /// 所有账户的当期账单信息
    /// 单例模式
    /// </summary>
    class BillBook
    {
        private static  BillBook m_instance = null;
        private BillBook()
        {

        }
        public static BillBook GetInstance()
        {
            if (m_instance == null)
            {
                m_instance = new BillBook();
                m_instance.m_total.Account.Name = "总计";
            }
            return m_instance;
        }

        private Dictionary<string, AccountBill> m_bills = new Dictionary<string, AccountBill>();
        // 所有账户总计
        private AccountBill m_total = new AccountBill();
        public AccountBill TotalAccount
        {
            get { return m_total; }
            set { m_total = value; }
        }

        public void Clear()
        {
            m_bills.Clear();
            UpdateTotal();
        }

        public void Remove(string account)
        {
            if (m_bills.ContainsKey(account))
            {
                m_bills.Remove(account);
                UpdateTotal();
            }
        }

        public List<AccountBill> GetAll()
        {
            return m_bills.Values.ToList();
        }

        public bool Exist(string name)
        {
            return m_bills.ContainsKey(name);
        }

        public bool Add(AccountBill bill)
        {
            m_bills.Add(bill.Account.Name, bill);

            UpdateTotal(bill);
            return true;
        }

        public AccountBill Find(string name)
        {
            if (!Exist(name))
                return null;

            return m_bills[name];
        }

        public void ResetBilll(AccountBill bill)
        {
            m_bills[bill.Account.Name] = bill;
        }

        public void UpdateTotal()
        {
            // 先清空，然后重新计算。
            m_total.Account.CreditAmount = 0;
            m_total.AvaliableAmount = 0;
            m_total.BillAmount = 0;
            m_total.RepayAmount = 0;
            m_total.NoRepayAmount = 0;
            m_total.SwingAmount = 0;
            m_total.Charge = 0;

            foreach (var account in BillBook.GetInstance().GetAll())
            {
                UpdateTotal(account);
            }
        }

        public void UpdateTotal(AccountBill bill)
        {
            m_total.Account.CreditAmount += bill.Account.CreditAmount;
            m_total.AvaliableAmount += bill.AvaliableAmount;
            m_total.BillAmount += bill.BillAmount;
            m_total.RepayAmount += bill.RepayAmount;
            m_total.NoRepayAmount += bill.NoRepayAmount;
            m_total.SwingAmount += bill.SwingAmount;
            m_total.Charge += bill.Charge;
        }
    }
}
