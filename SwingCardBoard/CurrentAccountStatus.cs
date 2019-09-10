﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwingCardBoard
{
    // save to csv
    class CurrentAccountStatus
    {
        readonly string m_fileName = @"data\account_status.csv";

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
                account.BillStartDay = int.Parse(items[2].Split('|')[0]);
                account.BillExpiredDay = int.Parse(items[2].Split('|')[1]);

                if (items.Length > 3)
                    account.CreditAmount = double.Parse(items[3]);
                if (items.Length > 4)
                    account.AvaliableAmount = double.Parse(items[4]);
                if (items.Length > 5)
                    account.BillAmount = double.Parse(items[5]);
                if (items.Length > 6)
                    account.RepayAmount = double.Parse(items[6]);
                if (items.Length > 7)
                    account.NoRepayAmount = double.Parse(items[7]);
                if (items.Length > 8)
                    account.SwingAmount = double.Parse(items[8]);
                if (items.Length > 9)
                    account.ReservedAmount = double.Parse(items[9]);
                if (items.Length > 10)
                    account.LastDateTime = items[10];

                AccountBook.GetInstance().AddAccount(account);
            }

            reader.Close();
        }

        // update and save to file
        public void Update()
        {
            StreamWriter writer = new StreamWriter(m_fileName);

            writer.Write("账号名称,卡号/账号,账单日期,信用额度,可用额度,账单金额,已还金额,未还金额,刷卡合计,刷卡明细");
            writer.Write("\r\n");
            writer.Flush();

            foreach (var account in AccountBook.GetInstance().GetAccounts())
            {
                writer.Write(account.Name);
                WriteSpliter(writer);
                writer.Write(account.Number);
                WriteSpliter(writer);
                writer.Write(account.BillStartDay+"|"+account.BillExpiredDay);
                WriteSpliter(writer);
                writer.Write(account.CreditAmount);
                WriteSpliter(writer);
                writer.Write(account.AvaliableAmount);
                WriteSpliter(writer);
                writer.Write(account.BillAmount);
                WriteSpliter(writer);
                writer.Write(account.RepayAmount);
                WriteSpliter(writer);
                writer.Write(account.NoRepayAmount);
                WriteSpliter(writer);
                writer.Write(account.SwingAmount);
                WriteSpliter(writer);
                writer.Write(account.ReservedAmount);
                WriteSpliter(writer);
                writer.Write(account.LastDateTime);
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
