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
    public partial class LoginWnd : Form
    {
        public LoginWnd()
        {
            InitializeComponent();

            this.AcceptButton = m_loginBtn;
            this.CancelButton = m_cancelBtn;
            this.m_usrNameTxt.Enabled = false;

            this.Text = "养卡记 - v" + Program.Version;
            SetTip("");
        }

        private void SetTip(string tip)
        {
            this.m_tipLbl.Text = tip;
        }

        private User m_user = null;
        private void LoginWnd_Load(object sender, EventArgs e)
        {
            UserDB db = new UserDB();
            m_user = db.Load();

            if (m_user == null)
            {
                this.m_loginBtn.Enabled = false;
                this.m_registerBtn.Enabled = true;
                SetTip("还没有用户，请先注册！");
            }
            else
            {
                this.m_usrNameTxt.Text = m_user.Name;
                this.m_registerBtn.Text = "修改密码";
                this.m_registerBtn.Visible = false;
            }
        }

        private void m_loginBtn_Click(object sender, EventArgs e)
        {
            string pwd = m_usrPwdTxt.Text.Trim();
            if (Utility.EncodeUserPwd(pwd) != m_user.Password)
            {
                SetTip("密码错误！");
                return;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void m_cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_registerBtn_Click(object sender, EventArgs e)
        {
            RegisterUserWnd wnd = new RegisterUserWnd(m_user);
            if (DialogResult.OK != wnd.ShowDialog())
            {
                return;
            }

            m_user = wnd.NewUser;

            UserDB db = new UserDB();
            m_user.Password = Utility.EncodeUserPwd(m_user.Password);
            db.Update(m_user);

            m_usrNameTxt.Text = wnd.NewUser.Name;
            this.m_loginBtn.Enabled = true;
            this.m_registerBtn.Enabled = false;
            SetTip("");
        }
    }
}
