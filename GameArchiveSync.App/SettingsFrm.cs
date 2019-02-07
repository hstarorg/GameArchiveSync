using GameArchiveSync.Business;
using GameArchiveSync.Business.Implements;
using GameArchiveSync.Business.Models;
using System;
using System.IO;
using System.Windows.Forms;

namespace GameArchiveSync.App
{
    public partial class SettingsFrm : Form
    {
        private readonly IGitBusiness gitBiz;
        private readonly IGameArchiveSyncBusiness gasBiz;

        public SettingsFrm()
        {
            InitializeComponent();
            this.gitBiz = new DefaultGitBusiness();
            this.gasBiz = new DefaultGameArchiveSyncBusiness(GlobalConfig.DbPath);
        }

        #region UI Events

        private void SettingsFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!this.gasBiz.HasGameArchiveStorageRepo())
            {
                Application.Exit();
            }
        }

        private void BtnCheckConnection_Click(object sender, EventArgs e)
        {
            var isAvailable = this.gitBiz.CheckRemoteRepositoryAvailable(this.TbGitRepoAddress.Text.Trim(), new GitCredential
            {
                UserName = TbUsername.Text.Trim(),
                Password = TbPassword.Text
            });
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            var workdirPath = Path.Combine(AppContext.BaseDirectory, "repo");
            var isGitRepo = this.gitBiz.IsGitRepository(workdirPath);
            try
            {
                if (isGitRepo)
                {
                }
                else
                {
                    this.gitBiz.CloneRepo("", workdirPath);
                }
                WinFormsUtil.Alert("验证成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion UI Events
    }
}