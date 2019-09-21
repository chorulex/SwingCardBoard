using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SwingCardBoard
{
    public partial class AboutWnd : Form
    {
        public AboutWnd()
        {
            InitializeComponent();
        }

        private void AboutWnd_Load(object sender, EventArgs e)
        {
            m_descriptionTxt.Text = "养卡记\r\n\r\n用于管理所有刷卡/还款管理，简化操作，避免手动操作错误。";
            m_versionLbl.Text = "版本：v" + Program.Version;
        }
    }
}
