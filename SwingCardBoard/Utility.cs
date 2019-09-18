using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwingCardBoard
{
    class Utility
    {
        private Utility()
        {

        }

        # region common
        public static string GetCurrentDTString()
        {
            return DateTime.Now.ToLocalTime().ToString();
        }

        public static string FormatDoubleString(double origin)
        {
            return FormatDoubleString(origin.ToString());
        }

        // 1000 -> 1,000
        public static string FormatDoubleString(string origin)
        {
            if (origin.Length <= 3)
                return origin;

            string res = null;
            int dotPos = origin.IndexOf('.');
            if (dotPos == -1)
            {
                res = (string)origin.Clone();
            }
            else
            {
                res = origin.Substring(0, dotPos);
            }

            int times = 0;
            string tmpOrigin = (string)res.Clone();
            while ((times + 1) * 3 < tmpOrigin.Length)
            {
                res = res.Insert(res.Length - (times + 1) * 3 - times, ",");
                times++;
            }

            return dotPos == -1 ? res : (res + origin.Substring(dotPos));
        }

        public static string ConvertToOrigin(string value)
        {
            return value.Replace(",", "");
        }
        #endregion

        #region control
        public static void SetSelectToLastest(System.Windows.Forms.TextBox txtBox)
        {
            txtBox.Select(txtBox.TextLength, 0);
        }
        public static void CheckTextBoxKeyPress(System.Windows.Forms.TextBox ctr, object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            int dotPos = ctr.Text.IndexOf('.');

            if (ch == '.')
            {
                // 仅能输入一个小数点符号
                if (dotPos != -1)
                {
                    e.Handled = true;
                    return;
                }
            }
            else if (char.IsDigit(ch))
            {
                // 小数点后仅能两位有效数
                if (dotPos != -1 && ctr.Text.Length - dotPos - 1 >= 2)
                {
                    e.Handled = true;
                    return;
                }
            }
            else if (ch == '\b')
            {
                // 退格键
            }
            else
            {
                // 其他任何输入键无效！
                e.Handled = true;
                return;
            }
        }
        #endregion
    }
}