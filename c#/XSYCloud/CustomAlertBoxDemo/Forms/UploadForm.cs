using CustomAlertBoxDemo;
using Newtonsoft.Json.Linq;
using System;
using System.Windows.Forms;

namespace XSYCloud.Forms
{
    public partial class UploadForm : Form
    {
        public UploadForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string filename = dialog.FileName;
                    JObject res = Modules.PostFileToURL(filename, (string)Tag, "https://cloud.xiaoshiyan.top:8081/upload");
                    if ((int)res["code"] == 0)
                    {
                        new Form_Alert().showAlert("上传成功！", Form_Alert.enmType.Success);
                    }
                    else
                    {
                        new Form_Alert().showAlert(res["reason"].ToString(), Form_Alert.enmType.Error);
                    }
                }
            }
        }

        private void button1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;                                                              //重要代码：表明是所有类型的数据，比如文件路径
            else
                e.Effect = DragDropEffects.None;
        }

        private void button1_DragDrop(object sender, DragEventArgs e)
        {
            Array files = (Array)e.Data.GetData(DataFormats.FileDrop);
            foreach (Object item in files)
            {
                JObject res = Modules.PostFileToURL(item.ToString(), (string)Tag, "https://cloud.xiaoshiyan.top:8081/upload");
                if ((int)res["code"] != 0)
                {
                    new Form_Alert().showAlert(res["reason"].ToString(), Form_Alert.enmType.Error);
                    return;
                }
            }
            new Form_Alert().showAlert("上传成功！", Form_Alert.enmType.Success);
        }
    }
}
