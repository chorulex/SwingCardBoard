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
            return FormatDateTimeString(DateTime.Now);
        }

        public static string FormatDateTimeString(DateTime dt)
        {
            return dt.ToLocalTime().ToString();
        }

        public static string FormatDateString(DateTime dt)
        {
            return dt.ToLocalTime().ToShortDateString();
        }

        public static string FormatDoubleString(double origin)
        {
            return FormatDoubleString(origin.ToString());
        }

        /// <summary>
        /// 根据账单出账日，算出上一个账单的日期区间
        /// </summary>
        /// <param name="billStartDay"></param>
        /// <param name="lastBillStart"></param>
        /// <param name="lastBillEnd"></param>
        public static void CalcLastBillDruction(int billStartDay, ref DateTime lastBillStart, ref DateTime lastBillEnd)
        {
            DateTime now = DateTime.Now.ToLocalTime();
            if (now.Day <= billStartDay)
            {
                if (now.Month - 1 == 0)
                {
                    lastBillEnd = new DateTime(now.Year - 1, 12, billStartDay);
                }
                else
                {
                    lastBillEnd = new DateTime(now.Year, now.Month - 1, billStartDay);
                }
            }
            else
            {
                lastBillEnd = new DateTime(now.Year, now.Month, billStartDay);
            }

            if (lastBillEnd.Month - 1 == 0)
            {
                lastBillStart = new DateTime(now.Year - 1, 12, billStartDay);
            }
            else
            {
                lastBillStart = new DateTime(now.Year, lastBillEnd.Month -1 , billStartDay);
            }
            lastBillStart = lastBillStart.AddDays(1);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="precision">小数点后位数</param>
        /// <param name="ctr"></param>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void CheckTextBoxKeyPress(System.Windows.Forms.TextBox ctr, object sender, System.Windows.Forms.KeyPressEventArgs e, int precision=2)
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
                if (dotPos != -1 && ctr.Text.Length - dotPos - 1 >= precision)
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