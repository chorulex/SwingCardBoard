using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwingCardBoard
{
    public class FundEvent
    {
        private string m_dateTime;
        public string DateTime
        {
            get { return m_dateTime; }
            set { m_dateTime = value; }
        }

        private string m_account;
        public string Account
        {
            get { return m_account; }
            set { m_account = value; }
        }

        private double m_amount;
        public double Amount
        {
            get { return m_amount; }
            set { m_amount = value; }
        }

        /// <summary>
        /// 刷卡手续费，仅在刷卡时才有效！
        /// </summary>
        private double m_charge;
        public double Charge
        {
            get { return m_charge; }
            set { m_charge = value; }
        }

        /// <summary>
        /// 1：刷卡
        /// 2：还款
        /// </summary>
        private string m_type;
        public string Type
        {
            get { return m_type; }
            set { m_type = value; }
        }

        public FundEvent(string account, double amount, string type)
        {
            Type = type;
            Account = account;
            Amount = amount;
            DateTime = Utility.GetCurrentDTString();
        }

        public FundEvent(string account, double amount,double charge, string type, string dt)
        {
            Type = type;
            Account = account;
            Amount = amount;
            Charge = charge;
            DateTime = dt;
        }
    }

    // 存储到csv
    class HistoryFundEventDB
    {
        readonly string m_fileName = @"data\fund_change_history.csv";

        public void Clean()
        {
            if (File.Exists(m_fileName))
                File.Delete(m_fileName);
        }

        public List<FundEvent> Load()
        {
            List<FundEvent> events = new List<FundEvent>();

            if (!File.Exists(m_fileName))
                return events;

            StreamReader reader = new StreamReader(m_fileName);
            if (reader == null)
                return events;

            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] items = line.Split(',');

                if (items.Length >= 5)
                    events.Add(new FundEvent(items[0], double.Parse(items[2]), double.Parse(items[4]), items[1], items[3]));
                else
                    events.Add(new FundEvent(items[0], double.Parse(items[2]), 0, items[1], items[3]));
            }

            reader.Close();
            return events;
        }

        // update and save to file
        public void AddNewFundEvent(FundEvent eve)
        {
            bool newFile = !File.Exists(m_fileName);

            StreamWriter writer = new StreamWriter(m_fileName, true);

            if (newFile)
            {
                writer.Write("账号名称,资金变动类型,资金变动额度,操作日期时间, 刷卡手续费");
                writer.Write("\r\n");
                writer.Flush();
            }

            writer.Write(eve.Account);
            WriteSpliter(writer);
            writer.Write(eve.Type);
            WriteSpliter(writer);
            writer.Write(eve.Amount.ToString());
            WriteSpliter(writer);
            writer.Write(eve.DateTime);
            WriteSpliter(writer);
            writer.Write(eve.Charge);
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
