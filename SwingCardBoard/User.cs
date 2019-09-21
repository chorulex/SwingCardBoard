using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwingCardBoard
{
    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }

    class UserDB
    {
        readonly string m_fileName = @"data\user.csv";

        public User Load()
        {
            if (!File.Exists(m_fileName))
                return null;

            StreamReader reader = new StreamReader(m_fileName);
            if (reader == null)
                return null;

            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] items = line.Split(',');

                User user = new User();
                user.Name = items[0];
                user.Password = items[1];

                reader.Close();
                return user;
            }

            return null;
        }

        // update and save to file
        public void Update(User user)
        {
            StreamWriter writer = new StreamWriter(m_fileName);

            writer.Write("用户名,密码");
            writer.Write("\r\n");
            writer.Flush();

            writer.Write(user.Name);
            WriteSpliter(writer);
            writer.Write(user.Password);
            //writer.Write("\r\n");
            writer.Flush();

            writer.Close();
        }

        private void WriteSpliter(StreamWriter writer)
        {
            writer.Write(",");
        }
    }
}
