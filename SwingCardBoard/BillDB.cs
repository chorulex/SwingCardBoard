using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwingCardBoard
{
    // save to csv
    class AccountBillDB
    {
        readonly string m_fileName = @"data\account_current_bill.csv";

        public void Clear()
        {
            if (File.Exists(m_fileName))
                File.Delete(m_fileName);
        }

        public void Remove(string account)
        {
            UpdateDB();
        }

        public void Add(AccountBill bill)
        {
            UpdateDB();
        }

        public void Update(AccountBill bill)
        {
            UpdateDB();
        }

        public void Load()
        {
            if (!File.Exists(m_fileName))
                return;

            StreamReader reader = new StreamReader(m_fileName);
            if (reader == null)
                return;

            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] items = line.Split(',');

                // bind account
                string accountName = items[0];
                Account account = AccountBook.GetInstance().Find(accountName);
                AccountBill bill = new AccountBill(account);

                bill.LastBillStart = DateTime.Parse(items[2]);
                bill.LastBillEnd = DateTime.Parse(items[3]);
                bill.AvaliableAmount = double.Parse(items[4]);
                bill.BillAmount = double.Parse(items[5]);
                bill.RepayAmount = double.Parse(items[6]);
                bill.NoRepayAmount = double.Parse(items[7]);
                bill.SwingAmount = double.Parse(items[8]);
                bill.BillSetDate = items[9];
                bill.LastDateTime = items[10];
                bill.Charge = double.Parse(items[11]);

                BillBook.GetInstance().Add(bill);
            }

            reader.Close();
        }

        // update and save to file
        private void UpdateDB()
        {
            StreamWriter writer = new StreamWriter(m_fileName);

            writer.Write("账号名称,信用额度,账单起始日期,账单截止日期,可用额度,账单金额,已还金额,未还金额,刷卡合计,上次设置账单日期时间,最后操作日期时间,刷卡手续费");
            writer.Write("\r\n");
            writer.Flush();

            foreach (var bill in BillBook.GetInstance().GetAll())
            {
                writer.Write(bill.Account.Name);
                WriteSpliter(writer);
                writer.Write(bill.Account.CreditAmount);
                WriteSpliter(writer);
                writer.Write(bill.LastBillStart);
                WriteSpliter(writer);
                writer.Write(bill.LastBillEnd);
                WriteSpliter(writer);
                writer.Write(bill.AvaliableAmount);
                WriteSpliter(writer);
                writer.Write(bill.BillAmount);
                WriteSpliter(writer);
                writer.Write(bill.RepayAmount);
                WriteSpliter(writer);
                writer.Write(bill.NoRepayAmount);
                WriteSpliter(writer);
                writer.Write(bill.SwingAmount);
                WriteSpliter(writer);
                writer.Write(bill.BillSetDate);
                WriteSpliter(writer);
                writer.Write(bill.LastDateTime);
                WriteSpliter(writer);
                writer.Write(bill.Charge);
                writer.Write("\r\n");
                writer.Flush();
            }

            writer.Close();
        }

        private void WriteSpliter(StreamWriter writer)
        {
            writer.Write(",");
        }
    }

    // save to csv
    class HistoryBillDB
    {
        readonly string m_fileName = @"data\account_history_bill.csv";

        public void Clear()
        {
            if (File.Exists(m_fileName))
                File.Delete(m_fileName);
        }

        public void Add(AccountBill bill)
        {
            SaveToDB(bill);
        }

        public List<AccountBill> Load()
        {
            List<AccountBill> bills = new List<AccountBill>();

            if (!File.Exists(m_fileName))
                return bills;

            StreamReader reader = new StreamReader(m_fileName);
            if (reader == null)
                return bills;

            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] items = line.Split(',');

                AccountBill bill = new AccountBill();
                bill.Account.Name = items[0];
                bill.Account.CreditAmount = double.Parse(items[1]);
                bill.LastBillStart = DateTime.Parse(items[2]);
                bill.LastBillEnd = DateTime.Parse(items[3]);
                bill.AvaliableAmount = double.Parse(items[4]);
                bill.BillAmount = double.Parse(items[5]);
                bill.RepayAmount = double.Parse(items[6]);
                bill.NoRepayAmount = double.Parse(items[7]);
                bill.SwingAmount = double.Parse(items[8]);
                bill.BillSetDate = items[9];
                bill.LastDateTime = items[10];
                bill.Charge = double.Parse(items[11]);

                bills.Add(bill);
            }

            reader.Close();
            return bills;
        }

        // update and save to file
        private void SaveToDB(AccountBill bill)
        {
            bool exist = File.Exists(m_fileName);

            StreamWriter writer = null;

            if (!exist)
            {
                writer = new StreamWriter(m_fileName);
                writer.Write("账号名称,信用额度,账单起始日期,账单截止日期,可用额度,账单金额,已还金额,未还金额,刷卡合计,上次设置账单日期时间,最后操作日期时间,刷卡手续费");
                writer.Write("\r\n");
                writer.Flush();
            }
            else
            {
                writer = new StreamWriter(m_fileName,true);
            }

            writer.Write(bill.Account.Name);
            WriteSpliter(writer);
            writer.Write(bill.Account.CreditAmount);
            WriteSpliter(writer);
            writer.Write(Utility.FormatDateString(bill.LastBillStart));
            WriteSpliter(writer);
            writer.Write(Utility.FormatDateString(bill.LastBillEnd));
            WriteSpliter(writer);
            writer.Write(bill.AvaliableAmount);
            WriteSpliter(writer);
            writer.Write(bill.BillAmount);
            WriteSpliter(writer);
            writer.Write(bill.RepayAmount);
            WriteSpliter(writer);
            writer.Write(bill.NoRepayAmount);
            WriteSpliter(writer);
            writer.Write(bill.SwingAmount);
            WriteSpliter(writer);
            writer.Write(bill.BillSetDate);
            WriteSpliter(writer);
            writer.Write(bill.LastDateTime);
            WriteSpliter(writer);
            writer.Write(bill.Charge);
            writer.Write("\r\n");
            writer.Flush();

            writer.Close();
        }

        private void WriteSpliter(StreamWriter writer)
        {
            writer.Write(",");
        }
    }
}
