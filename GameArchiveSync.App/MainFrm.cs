using GameArchiveSync.App.Forms;
using GameArchiveSync.App.Helpers;
using GameArchiveSync.Business;
using GameArchiveSync.Business.Implements;
using GameArchiveSync.Business.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameArchiveSync.App
{
    public partial class MainFrm : Form
    {
        private readonly IGameArchiveSyncBusiness gasBiz;
        private readonly IGitBusiness gitBiz;
        /// <summary>
        /// 仓库是否已初始化
        /// </summary>
        private bool isRepoInitialized = false;

        private delegate void DelegateVoid();

        public MainFrm()
        {
            InitializeComponent();
            this.gasBiz = new DefaultGameArchiveSyncBusiness(GlobalConfig.DbPath);
            this.gitBiz = new DefaultGitBusiness();
            this.LoadData();
        }

        #region UI Events

        private void MainFrm_SizeChanged(object sender, System.EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                // 最小化
                this.ShowInTaskbar = false;
            }
            else
            {
                this.ShowInTaskbar = true;
            }
        }

        private void AppNotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void SendFeedbackMenuItem_Click(object sender, System.EventArgs e)
        {
            WinFormsUtil.OpenUrl("https://github.com/hstarorg/GameArchiveSync/issues/new");
        }

        private void CheckUpdateMenuItem_Click(object sender, EventArgs e)
        {
            WinFormsUtil.OpenUrl("https://github.com/hstarorg/GameArchiveSync/releases");
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            var mainFrm = this;
            if (!this.gasBiz.HasGameArchiveStorageRepo())
            {
                this.DelayDo(() =>
                {
                    var settingsFrm = new SettingsFrm();
                    settingsFrm.ShowDialog(mainFrm);
                });
            }
            else
            {
                Task.Run(() =>
                {
                    this.PrepareRepo();
                });
            }
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RepoSettingsMenuItem_Click(object sender, EventArgs e)
        {
            var settingsFrm = new SettingsFrm();
            settingsFrm.ShowDialog(this);
            // 关闭设置后，尝试执行一次Prepare仓库
            Task.Run(() =>
            {
                this.PrepareRepo();
            });
        }

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            var aboutFrm = new AboutFrm();
            aboutFrm.ShowDialog(this);
        }

        private void SyncGameArchiveMenuItem_Click(object sender, EventArgs e)
        {
            var syncResult = this.gasBiz.SyncGameArchiveList(GlobalConfig.GameArchiveListUrl);
            WinFormsUtil.Alert("同步成功！");
        }

        private void BtnRefreshArchive_Click(object sender, EventArgs e)
        {
            this.RefreshGameList();
        }

        private void BtnBackup_Click(object sender, EventArgs e)
        {
            WinFormsUtil.Alert(WinFormsUtil.GetCurrentUser());
        }


        private void SystemTimeTimer_Tick(object sender, EventArgs e)
        {
            SysTimeStatusLabel.Text = $"系统时间：{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}";
        }

        #endregion UI Events

        #region Util Functions

        private void LoadData()
        {
            this.SystemTimeTimer_Tick(null, null);
        }

        private void PrepareRepo()
        {
            if (this.isRepoInitialized)
            {
                return;
            }
            var repoInfo = this.gasBiz.GetGameArchiveStorageRepoInfo();

            if (!this.gitBiz.IsGitRepository(GlobalConfig.TempRepoPath))
            {
                // 如果还不是Git仓库，则创建目录，Clone仓库
                WinFormsUtil.EnsureDirExists(GlobalConfig.TempRepoPath);
                this.gitBiz.CloneRepo(GlobalConfig.TempRepoPath, repoInfo);
                this.isRepoInitialized = true;
            }
            else
            {
                // 如果已经是Git仓库，则执行pull
                this.isRepoInitialized = true;
            }
            if (this.isRepoInitialized)
            {
                ArchiveRepoStatusLabel.Text = $"存档仓库：{repoInfo.RepoAddress}";
                this.RefreshGameList();
            }
        }

        private void RefreshGameList()
        {
            var localList = this.gasBiz.GetLocalGameArchiveList(WinFormsUtil.GetCurrentUser());
            this.DelayDo(() =>
            {
                ClbGameArchive.Items.Clear();
                ClbGameArchive.Items.AddRange(localList.Select(x => x.GameName).ToArray());
            }, 300);
        }

        private void DelayDo(Action action, int delayMs = 0)
        {
            Task.Run(() =>
            {
                Thread.Sleep(delayMs);
                this.BeginInvoke(new DelegateVoid(action));
            });
        }

        #endregion Util Functions

    }
}