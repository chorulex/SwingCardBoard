﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwingCardBoard
{
    public class Account
    {
        private string m_lastDateTime;
        public string LastDateTime
        {
            get{return m_lastDateTime;}
            set{m_lastDateTime = value;}
        }

        private string m_name;
        public string Name
        {
            get{return m_name;}
            set{m_name = value;}
        }

        private string m_number;
        public string Number
        {
            get{return m_number;}
            set{m_number = value;}
        }

        // 信用卡期日
        private string m_expiredDate;
        public string ExpiredDate
        {
            get{return m_expiredDate;}
            set{m_expiredDate = value;}
        }

        // 每月账单出账日,[1,31]
        private int m_billStartDay;
        public int BillStartDay
        {
            get{return m_billStartDay;}
            set{m_billStartDay = value;}
        }


        // 每月账单到期日,[1,31]
        private int m_billExpiredDay;
        public int BillExpiredDay
        {
            get{return m_billExpiredDay;}
            set{m_billExpiredDay = value;}
        }

        // 可用金额
        private double m_avaliableAmount;
        public double AvaliableAmount
        {
            get{return m_avaliableAmount;}
            set{m_avaliableAmount = value;}
        }

        // 信用金额
        private double m_creditAmount;
        public double CreditAmount
        {
            get{return m_creditAmount;}
            set{m_creditAmount = value;}
        }

        // 账单金额
        private double m_billAmount;
        public double BillAmount
        {
            get{return m_billAmount;}
            set{m_billAmount = value;}
        }

        // 刷卡金额总计
        private double m_swingAmount = 0.0;
        public double SwingAmount
        {
            get{return m_swingAmount;}
            set{m_swingAmount = value;}
        }

        // 最后一次刷卡得到的可用金额总计，这个金额可用来还款，也可用来做其他的消费，
        // 与可用额度是不同的。
        // 称之为准备金或者备用金
        private double m_reservedAmount = 0.0;
        public double ReservedAmount
        {
            get{return m_reservedAmount;}
            set{m_reservedAmount = value;}
        }

        // 未还金额：当前未还，但不包含出账后的任何消费项
        private double m_noRepayAmount = 0.0;
        public double NoRepayAmount
        {
            get{return m_noRepayAmount;}
            set{m_noRepayAmount = value;}
        }

        // 已还金额
        private double m_repayAmount = 0.0;
        public double RepayAmount
        {
            get{return m_repayAmount;}
            set{m_repayAmount = value;}
        }

        public void SetBillAmount(double bill)
        {
            m_billAmount = bill;
            m_noRepayAmount = bill;

            m_avaliableAmount = m_creditAmount - m_billAmount - m_swingAmount;
        }

        // 刷卡
        public void AddSwing(double amount)
        {
            m_swingAmount += amount;
            m_avaliableAmount -= amount;
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
                m_instance = new AccountBook();

            return m_instance;
        }

        private Dictionary<string, Account> m_acounts = new Dictionary<string, Account>();
        public int AccountCount
        {
            get{return m_acounts.Count;}
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

                foreach(var account in GetAccounts())
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
            return true;
        }

        public Account FindAccount(string name)
        {
            return m_acounts[name];
        }

        public void RemoveAcount()
        {

        }

        public void UpdateAcount()
        {

        }
    }
}