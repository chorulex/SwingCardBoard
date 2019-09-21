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
    public partial class RegisterUserWnd : Form
    {
        private User m_oldUser = null;
        public User NewUser { get; set; }

        public RegisterUserWnd(User user)
        {
            m_oldUser = user;

            InitializeComponent();
            SetTip("");
        }

        private void SetTip(string tip)
        {
            this.m_tipLbl.Text = tip;
        }

        private void m_okBtn_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.Name = m_userNameTxt.Text.Trim();
            user.Password = m_pwdTxt.Text.Trim();

            if (user.Name.Length == 0)
            {
                SetTip("请输入用户名");
                return;
            }

            if (user.Password.Length == 0)
            {
                SetTip("请输入用户密码");
                return;
            }

            if (user.Password.Length < 6)
            {
                SetTip("密码长度必须大于等于6");
                return;
            }

            string pwdAuth = m_pwdAuthTxt.Text.Trim();
            if (pwdAuth.Length== 0)
            {
                SetTip("请输入确认密码");
                return;
            }
            if (user.Password != pwdAuth)
            {
                SetTip("密码不一致！");
                return;
            }

            this.NewUser = user;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void m_cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
