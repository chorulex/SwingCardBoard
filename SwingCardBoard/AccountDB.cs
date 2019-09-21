using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwingCardBoard
{
    // save to csv
    class AccountDB
    {
          readonly string m_fileName = @"data\accounts.csv";

        public void Clear()
        {
            if (File.Exists(m_fileName))
                File.Delete(m_fileName);
        }

        public void Remove(string account)
        {
            UpdateDB();
        }

        public void Add(Account account)
        {
            UpdateDB();
        }

        public void Update(Account account)
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

                Account account = new Account();
                account.Name = items[0];
                account.Number = items[1];
                account.ExpiredDate = items[2];
                account.BillStartDay = int.Parse(items[3]);
                account.BillExpiredDay = int.Parse(items[4]);
                account.CreditAmount = double.Parse(items[5]);
                account.Rate = double.Parse(items[6]);

                AccountBook.GetInstance().Add(account);
            }

            reader.Close();
        }

        // update and save to file
        private void UpdateDB()
        {
            StreamWriter writer = new StreamWriter(m_fileName);

            writer.Write("名称,账号,账号到期日,出账日期,账单最后还款日,信用额度,刷卡手续费率");
            writer.Write("\r\n");
            writer.Flush();

            foreach (var account in AccountBook.GetInstance().GetAll())
            {
                writer.Write(account.Name);
                WriteSpliter(writer);
                writer.Write(account.Number);
                WriteSpliter(writer);
                writer.Write(account.ExpiredDate);
                WriteSpliter(writer);
                writer.Write(account.BillStartDay);
                WriteSpliter(writer);
                writer.Write(account.BillExpiredDay);
                WriteSpliter(writer);
                writer.Write(account.CreditAmount);
                WriteSpliter(writer);
                writer.Write(account.Rate);
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

}
