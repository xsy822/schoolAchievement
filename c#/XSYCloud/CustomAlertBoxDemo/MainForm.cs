using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using XSYCloud.Forms;

namespace CustomAlertBoxDemo
{
    public partial class MainForm : Form
    {
        private string username;
        private string token;
        private Form activeForm;
        public MainForm()
        {
            InitializeComponent();
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //如果有token验证登录
            string cookie = Modules.ReadFrom("cookies.txt");
            if (cookie != "")
            {
                JObject res = Modules.PostUrl("https://cloud.xiaoshiyan.top:8081/validate", $"{{\"token\":\"{cookie}\"}}");
                if ((int)res["code"] == 0)
                {
                    new Form_Alert().showAlert("本应用不保障账号及文件安全", Form_Alert.enmType.Info);
                    username = res["username"].ToString();
                    token = cookie;
                    usernameLabel.Text = username;
                    FilesForm childForm = new FilesForm();
                    childForm.Tag = token;
                    openChildForm(childForm, selectBtn1);
                    return;
                }
                else
                {
                    new Form_Alert().showAlert(res["reason"].ToString(), Form_Alert.enmType.Error);
                }
            }
            //正常弹出登录窗口
            LoginDialog loginDialog = new LoginDialog();
            if (loginDialog.ShowDialog() == DialogResult.OK)
            {
                username = ((string[])loginDialog.Tag)[0].ToString();
                token = ((string[])loginDialog.Tag)[1].ToString();
                loginDialog.Dispose();
                usernameLabel.Text = username;
                FilesForm childForm = new FilesForm();
                childForm.Tag = token;
                openChildForm(childForm, selectBtn1);
            }
            else
            {
                Application.Exit();
            }

        }
        private void changeBtnColor(Button btn)
        {
            selectBtn1.BackColor = Color.FromArgb(30, 159, 255);
            selectBtn2.BackColor = Color.FromArgb(30, 159, 255);
            selectBtn3.BackColor = Color.FromArgb(30, 159, 255);
            btn.BackColor = Color.FromArgb(95, 184, 120);
        }
        /*
         * 按钮切换改变颜色
         */
        private void selectBtn1_Click(object sender, EventArgs e)
        {
            FilesForm childForm = new FilesForm();
            childForm.Tag = token;
            openChildForm(childForm, (Button)sender);
        }
        private void selectBtn2_Click(object sender, EventArgs e)
        {
            UploadForm childForm = new UploadForm();
            childForm.Tag = token;
            openChildForm(childForm, (Button)sender);
        }

        private void selectBtn3_Click(object sender, EventArgs e)
        {
            StatictisForm childForm = new StatictisForm();
            childForm.Tag = token;
            openChildForm(childForm, (Button)sender);
        }
        /*
         * 在内容panel显示子窗口
         */
        private void openChildForm(Form childForm, Button sender)
        {
            changeBtnColor((Button)sender);
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDeskTopPane.Controls.Add(childForm);
            panelDeskTopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        //拖拽
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        private void topBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        /*
         * 最大化、最小化和关闭按钮
         */
        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void maxBtn_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                maxBtn.Image = XSYCloud.Properties.Resources.nomalWin;
            }
            else
            {
                WindowState = FormWindowState.Normal;
                maxBtn.Image = XSYCloud.Properties.Resources.full_screen;
            }
        }

        private void minBtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        /*
         * 退出登录
         * 重启项目
         */
        private void exitBtn_Click(object sender, EventArgs e)
        {
            Modules.WriteTo("cookies.txt", "");
            Application.Restart();
        }
        /*
         * 悬停改变颜色
         */
        private void exitBtn_MouseHover(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.FromArgb(200, 200, 200);
            ((Button)sender).ForeColor = Color.FromArgb(255, 71, 87);
        }

        private void exitBtn_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.FromArgb(30, 159, 255);
            ((Button)sender).ForeColor = Color.White;
        }
    }
}
