using CustomAlertBoxDemo;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Web;
using System.Windows.Forms;

namespace XSYCloud.Forms
{
    public partial class FilesForm : Form
    {
        //此页面的一些设置属性和http返回结果
        private JObject res;
        private int nowPage = 1;
        private int limit = 10;
        private int count;

        public FilesForm()
        {
            InitializeComponent();
            filename.TextAlign = HorizontalAlignment.Center;
        }
        private void FilesForm_Load(object sender, EventArgs e)
        {
            getMyfiles();
            comboBox1.SelectedIndex = 0;
        }
        /// <summary>
        /// 设置按钮状态
        /// </summary>
        private void setBtnStatus()
        {
            if (nowPage > 1)
            {
                leftBtn.Enabled = true;
            }
            else
            {
                leftBtn.Enabled = false;
            }
            if (nowPage * limit < count)
            {
                rightBtn.Enabled = true;
            }
            else
            {
                rightBtn.Enabled = false;
            }
        }
        /// <summary>
        /// 刷新页面表格内容
        /// </summary>
        public void getMyfiles()
        {
            Dictionary<string, string> data = new Dictionary<string, string>
            {
                { "page", nowPage.ToString() },
                { "limit", limit.ToString() },
                { "token", (string)Tag }
            };
            res = Modules.GetUrl("https://cloud.xiaoshiyan.top:8081/myfiles", data);
            if ((int)res["code"] == 0)
            {
                count = (int)res["count"];
                countLabel.Text = "共" + count.ToString() + "条";
                listView1.Items.Clear();
                pageBox.Text = nowPage.ToString();

                setBtnStatus();

                foreach (JObject file in res["data"])
                {
                    ListViewItem item = new ListViewItem(file["filename"].ToString());
                    item.SubItems.Add(file["class"].ToString());
                    item.SubItems.Add(file["size"].ToString());
                    item.SubItems.Add(file["date"].ToString());
                    listView1.Items.Add(item);
                }
            }
            else
            {
                new Form_Alert().showAlert(res["reason"].ToString(), Form_Alert.enmType.Error);
            }
        }

        /// <summary>
        /// 下载所选文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void downloadBtn_Click(object sender, EventArgs e)
        {
            if (listView1.CheckedItems.Count > 0)
            {
                using (FolderBrowserDialog dialog = new FolderBrowserDialog())
                {
                    dialog.Description = "选择保存路径";
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        string path = dialog.SelectedPath;
                        foreach (ListViewItem item in listView1.CheckedItems)
                        {
                            string filename1 = res["data"][item.Index]["filename1"].ToString(); //带时间戳的文件名
                            string filename = res["data"][item.Index]["filename"].ToString();
                            string url = res["data"][item.Index]["url"].ToString();
                            Dictionary<string, string> data = new Dictionary<string, string>
                            {
                                { "token", (string)Tag },
                                { "filename", HttpUtility.UrlEncode(filename1)},
                                { "url", HttpUtility.UrlEncode(url)}
                            };
                            Modules.GetFileFromUrl("https://cloud.xiaoshiyan.top:8081/download", data, filename, path);

                        }
                        new Form_Alert().showAlert("下载完成", Form_Alert.enmType.Success);
                        getMyfiles();
                    }
                }

            }

        }
        /// <summary>
        /// 向前一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void leftBtn_Click(object sender, EventArgs e)
        {
            nowPage--;
            getMyfiles();
        }
        /// <summary>
        /// 向后一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rightBtn_Click(object sender, EventArgs e)
        {
            nowPage++;
            getMyfiles();
        }
        /// <summary>
        /// 改变combobox数值后，取得limit，并刷新表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            limit = int.Parse(comboBox1.Text.Substring(0, 2));
            getMyfiles();
        }

        /// <summary>
        /// 页数框回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pageBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                foreach (char i in pageBox.Text)
                {
                    if (!(i >= '0' && i <= '9'))
                    {
                        new Form_Alert().showAlert("输入有误", Form_Alert.enmType.Error);
                        return;
                    }
                }
                if (int.Parse(pageBox.Text) > (count / limit + 1))
                {
                    new Form_Alert().showAlert("超过最大页数", Form_Alert.enmType.Info);
                    return;
                }
                nowPage = int.Parse(pageBox.Text);
                getMyfiles();
            }
        }

        /// <summary>
        /// 删除所选项文件，刷新表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delBtn_Click(object sender, EventArgs e)
        {
            if (listView1.CheckedItems.Count > 0)
            {
                foreach (ListViewItem item in listView1.CheckedItems)
                {
                    string content = $"{{\"filename\":\"{res["data"][item.Index]["filename1"]}\",\"token\":\"{Tag}\"}}";
                    JObject respon = Modules.PostUrl("https://cloud.xiaoshiyan.top:8081/delfiles", content);
                    if ((int)respon["code"] == 0)
                    {
                        new Form_Alert().showAlert($"成功删除{res["data"][item.Index]["filename"]}", Form_Alert.enmType.Success);
                    }
                    else
                    {
                        new Form_Alert().showAlert(respon["reason"].ToString(), Form_Alert.enmType.Error);
                    }
                }
                getMyfiles();
            }
        }

        private void listView1_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            string newName = e.Label;
            if (newName == null)
            {}
            else if (newName == "")
            {
                new Form_Alert().showAlert("不能为空", Form_Alert.enmType.Warning);
            }
            else if (!newName.Contains("."))
            {
                new Form_Alert().showAlert("不能删掉后缀名", Form_Alert.enmType.Warning);
            }
            else
            {
                string fileName = (string)res["data"][e.Item]["filename1"];
                string url = "https://cloud.xiaoshiyan.top:8081/changefile";
                string content = $"{{\"filename\":\"{fileName}\",\"newname\":\"{newName}\",\"token\":\"{Tag}\"}}";
                JObject respon = Modules.PostUrl(url, content);
                if ((int)respon["code"] == 0)
                {
                    new Form_Alert().showAlert("已更改！", Form_Alert.enmType.Success);
                }
                else
                {
                    new Form_Alert().showAlert(respon["reason"].ToString(), Form_Alert.enmType.Error);
                }
            }
            getMyfiles();
        }
    }
}
