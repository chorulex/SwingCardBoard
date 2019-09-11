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
        /// 仅两种类型：
        /// 1：刷卡
        /// 2：还款
        /// </summary>
        private string m_type;
        public string Type
        {
            get { return m_type; }
            set { m_type = value; }
        }
    }

    // 存储到csv
    class HistoryFundEventDB
    {
        readonly string m_fileName = @"data\fund_change_history.csv";

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

                FundEvent eve = new FundEvent();
                eve.Account = items[0];
                eve.Type = items[1];
                eve.Amount = double.Parse(items[2]);
                eve.DateTime = items[3];

                events.Add(eve);
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
                writer.Write("账号名称,资金变动类型,资金变动额度,操作日期时间");
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
