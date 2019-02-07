namespace GameArchiveSync.App
{
    partial class MainFrm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.AppMenuStrip = new System.Windows.Forms.MenuStrip();
            this.功能FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RepoSettingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SyncGameArchiveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SendFeedbackMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CheckUpdateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AppStatusStrip = new System.Windows.Forms.StatusStrip();
            this.SysTimeStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.AppNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.AppNotifyContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnBackup = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BtnRefreshArchive = new System.Windows.Forms.Button();
            this.SystemTimeTimer = new System.Windows.Forms.Timer(this.components);
            this.ArchiveRepoStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ClbGameArchive = new System.Windows.Forms.CheckedListBox();
            this.AppMenuStrip.SuspendLayout();
            this.AppStatusStrip.SuspendLayout();
            this.AppNotifyContextMenuStrip.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // AppMenuStrip
            // 
            this.AppMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.功能FToolStripMenuItem,
            this.帮助HToolStripMenuItem});
            this.AppMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.AppMenuStrip.Name = "AppMenuStrip";
            this.AppMenuStrip.Size = new System.Drawing.Size(784, 25);
            this.AppMenuStrip.TabIndex = 0;
            // 
            // 功能FToolStripMenuItem
            // 
            this.功能FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RepoSettingsMenuItem,
            this.SyncGameArchiveMenuItem});
            this.功能FToolStripMenuItem.Name = "功能FToolStripMenuItem";
            this.功能FToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.功能FToolStripMenuItem.Text = "设置(&S)";
            // 
            // RepoSettingsMenuItem
            // 
            this.RepoSettingsMenuItem.Name = "RepoSettingsMenuItem";
            this.RepoSettingsMenuItem.Size = new System.Drawing.Size(148, 22);
            this.RepoSettingsMenuItem.Text = "存储仓库设置";
            this.RepoSettingsMenuItem.Click += new System.EventHandler(this.RepoSettingsMenuItem_Click);
            // 
            // SyncGameArchiveMenuItem
            // 
            this.SyncGameArchiveMenuItem.Name = "SyncGameArchiveMenuItem";
            this.SyncGameArchiveMenuItem.Size = new System.Drawing.Size(148, 22);
            this.SyncGameArchiveMenuItem.Text = "同步游戏列表";
            this.SyncGameArchiveMenuItem.Click += new System.EventHandler(this.SyncGameArchiveMenuItem_Click);
            // 
            // 帮助HToolStripMenuItem
            // 
            this.帮助HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SendFeedbackMenuItem,
            this.CheckUpdateMenuItem,
            this.AboutMenuItem});
            this.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            this.帮助HToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.帮助HToolStripMenuItem.Text = "帮助(&H)";
            // 
            // SendFeedbackMenuItem
            // 
            this.SendFeedbackMenuItem.Name = "SendFeedbackMenuItem";
            this.SendFeedbackMenuItem.Size = new System.Drawing.Size(138, 22);
            this.SendFeedbackMenuItem.Text = "发送反馈(&F)";
            this.SendFeedbackMenuItem.Click += new System.EventHandler(this.SendFeedbackMenuItem_Click);
            // 
            // CheckUpdateMenuItem
            // 
            this.CheckUpdateMenuItem.Name = "CheckUpdateMenuItem";
            this.CheckUpdateMenuItem.Size = new System.Drawing.Size(138, 22);
            this.CheckUpdateMenuItem.Text = "检查更新";
            this.CheckUpdateMenuItem.Click += new System.EventHandler(this.CheckUpdateMenuItem_Click);
            // 
            // AboutMenuItem
            // 
            this.AboutMenuItem.Name = "AboutMenuItem";
            this.AboutMenuItem.Size = new System.Drawing.Size(138, 22);
            this.AboutMenuItem.Text = "关于(&A)...";
            this.AboutMenuItem.Click += new System.EventHandler(this.AboutMenuItem_Click);
            // 
            // AppStatusStrip
            // 
            this.AppStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SysTimeStatusLabel,
            this.ArchiveRepoStatusLabel});
            this.AppStatusStrip.Location = new System.Drawing.Point(0, 439);
            this.AppStatusStrip.Name = "AppStatusStrip";
            this.AppStatusStrip.Size = new System.Drawing.Size(784, 22);
            this.AppStatusStrip.SizingGrip = false;
            this.AppStatusStrip.TabIndex = 1;
            // 
            // SysTimeStatusLabel
            // 
            this.SysTimeStatusLabel.Name = "SysTimeStatusLabel";
            this.SysTimeStatusLabel.Size = new System.Drawing.Size(68, 17);
            this.SysTimeStatusLabel.Text = "系统时间：";
            // 
            // AppNotifyIcon
            // 
            this.AppNotifyIcon.ContextMenuStrip = this.AppNotifyContextMenuStrip;
            this.AppNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("AppNotifyIcon.Icon")));
            this.AppNotifyIcon.Text = "幻星游戏存储同步";
            this.AppNotifyIcon.Visible = true;
            this.AppNotifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AppNotifyIcon_MouseClick);
            // 
            // AppNotifyContextMenuStrip
            // 
            this.AppNotifyContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExitMenuItem});
            this.AppNotifyContextMenuStrip.Name = "AppNotifyContextMenuStrip";
            this.AppNotifyContextMenuStrip.Size = new System.Drawing.Size(116, 26);
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.Name = "ExitMenuItem";
            this.ExitMenuItem.Size = new System.Drawing.Size(115, 22);
            this.ExitMenuItem.Text = "退出(&E)";
            this.ExitMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(552, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(220, 408);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "其他";
            // 
            // BtnBackup
            // 
            this.BtnBackup.Location = new System.Drawing.Point(6, 20);
            this.BtnBackup.Name = "BtnBackup";
            this.BtnBackup.Size = new System.Drawing.Size(208, 54);
            this.BtnBackup.TabIndex = 0;
            this.BtnBackup.Text = "立即备份";
            this.BtnBackup.UseVisualStyleBackColor = true;
            this.BtnBackup.Click += new System.EventHandler(this.BtnBackup_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnBackup);
            this.groupBox2.Location = new System.Drawing.Point(282, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(220, 408);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "备份";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ClbGameArchive);
            this.groupBox3.Controls.Add(this.BtnRefreshArchive);
            this.groupBox3.Location = new System.Drawing.Point(12, 28);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(220, 408);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "游戏存档列表";
            // 
            // BtnRefreshArchive
            // 
            this.BtnRefreshArchive.Location = new System.Drawing.Point(6, 379);
            this.BtnRefreshArchive.Name = "BtnRefreshArchive";
            this.BtnRefreshArchive.Size = new System.Drawing.Size(208, 23);
            this.BtnRefreshArchive.TabIndex = 1;
            this.BtnRefreshArchive.Text = "刷新";
            this.BtnRefreshArchive.UseVisualStyleBackColor = true;
            this.BtnRefreshArchive.Click += new System.EventHandler(this.BtnRefreshArchive_Click);
            // 
            // SystemTimeTimer
            // 
            this.SystemTimeTimer.Enabled = true;
            this.SystemTimeTimer.Interval = 1000;
            this.SystemTimeTimer.Tick += new System.EventHandler(this.SystemTimeTimer_Tick);
            // 
            // ArchiveRepoStatusLabel
            // 
            this.ArchiveRepoStatusLabel.Name = "ArchiveRepoStatusLabel";
            this.ArchiveRepoStatusLabel.Size = new System.Drawing.Size(68, 17);
            this.ArchiveRepoStatusLabel.Text = "存档仓库：";
            // 
            // ClbGameArchive
            // 
            this.ClbGameArchive.CheckOnClick = true;
            this.ClbGameArchive.FormattingEnabled = true;
            this.ClbGameArchive.Location = new System.Drawing.Point(6, 20);
            this.ClbGameArchive.Name = "ClbGameArchive";
            this.ClbGameArchive.Size = new System.Drawing.Size(208, 356);
            this.ClbGameArchive.TabIndex = 2;
            this.ClbGameArchive.ThreeDCheckBoxes = true;
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.AppStatusStrip);
            this.Controls.Add(this.AppMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.AppMenuStrip;
            this.MaximizeBox = false;
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "幻星游戏存储同步 - by hstarorg";
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.SizeChanged += new System.EventHandler(this.MainFrm_SizeChanged);
            this.AppMenuStrip.ResumeLayout(false);
            this.AppMenuStrip.PerformLayout();
            this.AppStatusStrip.ResumeLayout(false);
            this.AppStatusStrip.PerformLayout();
            this.AppNotifyContextMenuStrip.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip AppMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 功能FToolStripMenuItem;
        private System.Windows.Forms.StatusStrip AppStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel SysTimeStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon AppNotifyIcon;
        private System.Windows.Forms.ContextMenuStrip AppNotifyContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ExitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SendFeedbackMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CheckUpdateMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RepoSettingsMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button BtnBackup;
        private System.Windows.Forms.Button BtnRefreshArchive;
        private System.Windows.Forms.ToolStripMenuItem SyncGameArchiveMenuItem;
        private System.Windows.Forms.Timer SystemTimeTimer;
        private System.Windows.Forms.ToolStripStatusLabel ArchiveRepoStatusLabel;
        private System.Windows.Forms.CheckedListBox ClbGameArchive;
    }
}

