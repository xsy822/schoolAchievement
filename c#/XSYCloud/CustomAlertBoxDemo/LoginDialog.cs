using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CustomAlertBoxDemo
{
    public partial class LoginDialog : Form
    {
        public LoginDialog()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            this.Select();
        }

        private Boolean down = false;
        private int jizhu;
        private int x, y;
        private void LoginDialog_MouseDown(object sender, MouseEventArgs e)
        {
            /*
             * 获取鼠标在窗口内的位置
             */
            x = e.X;
            y = e.Y;
            down = true;
        }

        private void LoginDialog_MouseUp(object sender, MouseEventArgs e)
        {
            down = false;
        }

        private void LoginDialog_MouseMove(object sender, MouseEventArgs e)
        {
            /*
             * 拖动
             */
            if (down)
            {
                this.Location = new Point(Control.MousePosition.X - x, Control.MousePosition.Y - y);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            /*
             * 获取输入信息，发送请求
             * 处理返回数据
             * Tag : string[] username,token
             */
            jizhu = checkBox1.Checked ? 1 : 0;
            string username = userNameBox.Text;
            string pwd = pwdBox.Text;
            if (username == "" || pwd == "")
            {
                new Form_Alert().showAlert("用户名或密码为空", Form_Alert.enmType.Error);
                return;
            }
            string content = $"{{\"username\":\"{username}\",\"password\":\"{pwd}\",\"jizhu\":{jizhu}}}";
            JObject res = Modules.PostUrl("https://cloud.xiaoshiyan.top:8081/login", content);
            if ((int)res["code"] != 0)
            {
                new Form_Alert().showAlert(res["reason"].ToString(), Form_Alert.enmType.Error);
            }
            else
            {
                new Form_Alert().showAlert("本应用不保障账号及文件安全", Form_Alert.enmType.Info);
                Tag = new string[] { username, res["token"].ToString() };
                Modules.WriteTo("cookies.txt", res["token"].ToString());
                DialogResult = DialogResult.OK;
                Close();
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            /*
             * 取消登录，返回
             */
            DialogResult = DialogResult.Cancel;
        }

    }
}
