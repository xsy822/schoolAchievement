
namespace XSYCloud.Forms
{
    partial class FilesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listView1 = new System.Windows.Forms.ListView();
            this.filename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.countLabel = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.pageBox = new System.Windows.Forms.TextBox();
            this.rightBtn = new System.Windows.Forms.Button();
            this.leftBtn = new System.Windows.Forms.Button();
            this.delBtn = new System.Windows.Forms.Button();
            this.downloadBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.AllowColumnReorder = true;
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.filename,
            this.type,
            this.size,
            this.time});
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.LabelEdit = true;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(776, 381);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listView1_AfterLabelEdit);
            // 
            // filename
            // 
            this.filename.Text = "文件名";
            this.filename.Width = 280;
            // 
            // type
            // 
            this.type.Text = "类型";
            this.type.Width = 84;
            // 
            // size
            // 
            this.size.Text = "大小";
            this.size.Width = 100;
            // 
            // time
            // 
            this.time.Text = "时间";
            this.time.Width = 176;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(159)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.countLabel);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.pageBox);
            this.panel1.Controls.Add(this.rightBtn);
            this.panel1.Controls.Add(this.leftBtn);
            this.panel1.Controls.Add(this.delBtn);
            this.panel1.Controls.Add(this.downloadBtn);
            this.panel1.Location = new System.Drawing.Point(12, 392);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 44);
            this.panel1.TabIndex = 2;
            // 
            // countLabel
            // 
            this.countLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.countLabel.AutoSize = true;
            this.countLabel.ForeColor = System.Drawing.Color.White;
            this.countLabel.Location = new System.Drawing.Point(243, 17);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(45, 15);
            this.countLabel.TabIndex = 5;
            this.countLabel.Text = "共x条";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "10 条/页",
            "20 条/页",
            "30 条/页",
            "50 条/页",
            "90 条/页"});
            this.comboBox1.Location = new System.Drawing.Point(133, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(104, 23);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // pageBox
            // 
            this.pageBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pageBox.Location = new System.Drawing.Point(55, 14);
            this.pageBox.Name = "pageBox";
            this.pageBox.Size = new System.Drawing.Size(29, 25);
            this.pageBox.TabIndex = 3;
            this.pageBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pageBox_KeyDown);
            // 
            // rightBtn
            // 
            this.rightBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rightBtn.FlatAppearance.BorderSize = 0;
            this.rightBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rightBtn.Image = global::XSYCloud.Properties.Resources.right;
            this.rightBtn.Location = new System.Drawing.Point(92, 5);
            this.rightBtn.Name = "rightBtn";
            this.rightBtn.Size = new System.Drawing.Size(35, 35);
            this.rightBtn.TabIndex = 2;
            this.rightBtn.UseVisualStyleBackColor = true;
            this.rightBtn.Click += new System.EventHandler(this.rightBtn_Click);
            // 
            // leftBtn
            // 
            this.leftBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.leftBtn.FlatAppearance.BorderSize = 0;
            this.leftBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.leftBtn.Image = global::XSYCloud.Properties.Resources.left;
            this.leftBtn.Location = new System.Drawing.Point(14, 5);
            this.leftBtn.Name = "leftBtn";
            this.leftBtn.Size = new System.Drawing.Size(35, 35);
            this.leftBtn.TabIndex = 1;
            this.leftBtn.UseVisualStyleBackColor = true;
            this.leftBtn.Click += new System.EventHandler(this.leftBtn_Click);
            // 
            // delBtn
            // 
            this.delBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.delBtn.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.delBtn.FlatAppearance.BorderSize = 2;
            this.delBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delBtn.ForeColor = System.Drawing.Color.LightGray;
            this.delBtn.Location = new System.Drawing.Point(620, 7);
            this.delBtn.Name = "delBtn";
            this.delBtn.Size = new System.Drawing.Size(70, 30);
            this.delBtn.TabIndex = 0;
            this.delBtn.Text = "删除";
            this.delBtn.UseVisualStyleBackColor = true;
            this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
            // 
            // downloadBtn
            // 
            this.downloadBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.downloadBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.downloadBtn.FlatAppearance.BorderSize = 2;
            this.downloadBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downloadBtn.ForeColor = System.Drawing.Color.White;
            this.downloadBtn.Location = new System.Drawing.Point(701, 7);
            this.downloadBtn.Name = "downloadBtn";
            this.downloadBtn.Size = new System.Drawing.Size(70, 30);
            this.downloadBtn.TabIndex = 0;
            this.downloadBtn.Text = "下载";
            this.downloadBtn.UseVisualStyleBackColor = true;
            this.downloadBtn.Click += new System.EventHandler(this.downloadBtn_Click);
            // 
            // FilesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listView1);
            this.Name = "FilesForm";
            this.Text = "FilesForm";
            this.Load += new System.EventHandler(this.FilesForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader filename;
        private System.Windows.Forms.ColumnHeader type;
        private System.Windows.Forms.ColumnHeader size;
        private System.Windows.Forms.ColumnHeader time;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button downloadBtn;
        private System.Windows.Forms.Button delBtn;
        private System.Windows.Forms.TextBox pageBox;
        private System.Windows.Forms.Button rightBtn;
        private System.Windows.Forms.Button leftBtn;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label countLabel;
    }
}