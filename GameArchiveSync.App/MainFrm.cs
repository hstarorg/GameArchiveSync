using GameArchiveSync.Business;
using GameArchiveSync.Business.Implements;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameArchiveSync.App
{
    public partial class MainFrm : Form
    {
        private readonly IGameArchiveSyncBusiness gasBiz;

        private delegate void DelegateVoid();

        public MainFrm()
        {
            InitializeComponent();
            this.gasBiz = new DefaultGameArchiveSyncBusiness(GlobalConfig.DbPath);
            this.LoadAppData();
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
            System.Diagnostics.Process.Start("https://github.com/hstarorg/GameArchiveSync/issues/new");
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
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion UI Events

        #region Util Functions

        private void LoadAppData()
        {
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