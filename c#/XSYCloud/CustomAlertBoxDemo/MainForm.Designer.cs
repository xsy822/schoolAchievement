namespace CustomAlertBoxDemo
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.exitBtn = new System.Windows.Forms.Button();
            this.selectBtn3 = new System.Windows.Forms.Button();
            this.selectBtn2 = new System.Windows.Forms.Button();
            this.selectBtn1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.topBar = new System.Windows.Forms.Panel();
            this.minBtn = new System.Windows.Forms.Button();
            this.maxBtn = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.panelDeskTopPane = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.topBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(159)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.exitBtn);
            this.panel1.Controls.Add(this.selectBtn3);
            this.panel1.Controls.Add(this.selectBtn2);
            this.panel1.Controls.Add(this.selectBtn1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(151, 445);
            this.panel1.TabIndex = 3;
            // 
            // exitBtn
            // 
            this.exitBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.exitBtn.FlatAppearance.BorderSize = 0;
            this.exitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitBtn.ForeColor = System.Drawing.Color.White;
            this.exitBtn.Image = global::XSYCloud.Properties.Resources.exit;
            this.exitBtn.Location = new System.Drawing.Point(0, 189);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(151, 63);
            this.exitBtn.TabIndex = 4;
            this.exitBtn.TabStop = false;
            this.exitBtn.Text = " 退出";
            this.exitBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.exitBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            this.exitBtn.MouseEnter += new System.EventHandler(this.exitBtn_MouseHover);
            this.exitBtn.MouseLeave += new System.EventHandler(this.exitBtn_MouseLeave);
            // 
            // selectBtn3
            // 
            this.selectBtn3.Dock = System.Windows.Forms.DockStyle.Top;
            this.selectBtn3.FlatAppearance.BorderSize = 0;
            this.selectBtn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectBtn3.ForeColor = System.Drawing.Color.White;
            this.selectBtn3.Image = global::XSYCloud.Properties.Resources._static;
            this.selectBtn3.Location = new System.Drawing.Point(0, 126);
            this.selectBtn3.Name = "selectBtn3";
            this.selectBtn3.Size = new System.Drawing.Size(151, 63);
            this.selectBtn3.TabIndex = 3;
            this.selectBtn3.TabStop = false;
            this.selectBtn3.Text = "  统计";
            this.selectBtn3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.selectBtn3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.selectBtn3.UseVisualStyleBackColor = true;
            this.selectBtn3.Click += new System.EventHandler(this.selectBtn3_Click);
            // 
            // selectBtn2
            // 
            this.selectBtn2.Dock = System.Windows.Forms.DockStyle.Top;
            this.selectBtn2.FlatAppearance.BorderSize = 0;
            this.selectBtn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectBtn2.ForeColor = System.Drawing.Color.White;
            this.selectBtn2.Image = global::XSYCloud.Properties.Resources.upload;
            this.selectBtn2.Location = new System.Drawing.Point(0, 63);
            this.selectBtn2.Name = "selectBtn2";
            this.selectBtn2.Size = new System.Drawing.Size(151, 63);
            this.selectBtn2.TabIndex = 2;
            this.selectBtn2.TabStop = false;
            this.selectBtn2.Text = "  上传";
            this.selectBtn2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.selectBtn2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.selectBtn2.UseVisualStyleBackColor = true;
            this.selectBtn2.Click += new System.EventHandler(this.selectBtn2_Click);
            // 
            // selectBtn1
            // 
            this.selectBtn1.Dock = System.Windows.Forms.DockStyle.Top;
            this.selectBtn1.FlatAppearance.BorderSize = 0;
            this.selectBtn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectBtn1.ForeColor = System.Drawing.Color.White;
            this.selectBtn1.Image = global::XSYCloud.Properties.Resources.file;
            this.selectBtn1.Location = new System.Drawing.Point(0, 0);
            this.selectBtn1.Name = "selectBtn1";
            this.selectBtn1.Size = new System.Drawing.Size(151, 63);
            this.selectBtn1.TabIndex = 1;
            this.selectBtn1.TabStop = false;
            this.selectBtn1.Text = "  文件";
            this.selectBtn1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.selectBtn1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.selectBtn1.UseVisualStyleBackColor = true;
            this.selectBtn1.Click += new System.EventHandler(this.selectBtn1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::XSYCloud.Properties.Resources.user;
            this.pictureBox1.Location = new System.Drawing.Point(10, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 29);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoEllipsis = true;
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.ForeColor = System.Drawing.Color.White;
            this.usernameLabel.Location = new System.Drawing.Point(44, 13);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(107, 23);
            this.usernameLabel.TabIndex = 0;
            this.usernameLabel.Text = "username";
            // 
            // topBar
            // 
            this.topBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(159)))), ((int)(((byte)(255)))));
            this.topBar.Controls.Add(this.pictureBox1);
            this.topBar.Controls.Add(this.minBtn);
            this.topBar.Controls.Add(this.usernameLabel);
            this.topBar.Controls.Add(this.maxBtn);
            this.topBar.Controls.Add(this.closeBtn);
            this.topBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBar.Location = new System.Drawing.Point(0, 0);
            this.topBar.Name = "topBar";
            this.topBar.Size = new System.Drawing.Size(849, 41);
            this.topBar.TabIndex = 6;
            this.topBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topBar_MouseDown);
            // 
            // minBtn
            // 
            this.minBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minBtn.FlatAppearance.BorderSize = 0;
            this.minBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minBtn.Font = new System.Drawing.Font("Malgun Gothic", 15F);
            this.minBtn.ForeColor = System.Drawing.Color.White;
            this.minBtn.Image = global::XSYCloud.Properties.Resources.subtract;
            this.minBtn.Location = new System.Drawing.Point(728, 3);
            this.minBtn.Name = "minBtn";
            this.minBtn.Size = new System.Drawing.Size(36, 36);
            this.minBtn.TabIndex = 2;
            this.minBtn.TabStop = false;
            this.minBtn.UseVisualStyleBackColor = true;
            this.minBtn.Click += new System.EventHandler(this.minBtn_Click);
            // 
            // maxBtn
            // 
            this.maxBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maxBtn.FlatAppearance.BorderSize = 0;
            this.maxBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.maxBtn.Font = new System.Drawing.Font("Malgun Gothic", 15F);
            this.maxBtn.ForeColor = System.Drawing.Color.White;
            this.maxBtn.Image = global::XSYCloud.Properties.Resources.full_screen;
            this.maxBtn.Location = new System.Drawing.Point(769, 3);
            this.maxBtn.Name = "maxBtn";
            this.maxBtn.Size = new System.Drawing.Size(36, 36);
            this.maxBtn.TabIndex = 1;
            this.maxBtn.TabStop = false;
            this.maxBtn.UseVisualStyleBackColor = true;
            this.maxBtn.Click += new System.EventHandler(this.maxBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeBtn.FlatAppearance.BorderSize = 0;
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.Font = new System.Drawing.Font("Malgun Gothic", 15F);
            this.closeBtn.ForeColor = System.Drawing.Color.White;
            this.closeBtn.Image = global::XSYCloud.Properties.Resources.close_window_1;
            this.closeBtn.Location = new System.Drawing.Point(810, 2);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(36, 36);
            this.closeBtn.TabIndex = 0;
            this.closeBtn.TabStop = false;
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // panelDeskTopPane
            // 
            this.panelDeskTopPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDeskTopPane.Location = new System.Drawing.Point(151, 41);
            this.panelDeskTopPane.Name = "panelDeskTopPane";
            this.panelDeskTopPane.Size = new System.Drawing.Size(698, 445);
            this.panelDeskTopPane.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(849, 486);
            this.ControlBox = false;
            this.Controls.Add(this.panelDeskTopPane);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.topBar);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(851, 488);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.topBar.ResumeLayout(false);
            this.topBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button selectBtn1;
        private System.Windows.Forms.Button selectBtn3;
        private System.Windows.Forms.Button selectBtn2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Panel topBar;
        private System.Windows.Forms.Panel panelDeskTopPane;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button minBtn;
        private System.Windows.Forms.Button maxBtn;
        private System.Windows.Forms.Button exitBtn;
    }
}

