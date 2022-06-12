using CustomAlertBoxDemo;
using Newtonsoft.Json.Linq;
using System;
using System.Windows.Forms;

namespace XSYCloud.Forms
{
    public partial class StatictisForm : Form
    {
        public StatictisForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 从服务器获取信息，写入前端
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StatictisForm_Load(object sender, EventArgs e)
        {
            string token = (string)Tag;
            JObject res = Modules.PostUrl("https://cloud.xiaoshiyan.top:8081/count", $"{{\"token\":\"{token}\"}}");
            JObject count = (JObject)res["count"];
            int used = (int)count["used"];
            int rest = (int)count["rest"];
            int amount = (int)count["amount"];
            int percent = (int)((used * 1.0 / (rest + used)) * 1000);
            progressBar1.Value = percent;
            groupBox1.Text += $"      {(percent * 1.0 / 10).ToString("F1")}%";
            countLabel.Text = $"{(used * 1.0 / 1024).ToString("F3")}kb/{(rest * 1.0 / 1024).ToString("F3")}kb";
            amountLabel.Text = amount.ToString() + "个";
        }
    }
}
