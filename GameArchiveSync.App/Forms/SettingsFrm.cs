using GameArchiveSync.App.Helpers;
using GameArchiveSync.Business;
using GameArchiveSync.Business.Implements;
using GameArchiveSync.Business.Models;
using System;
using System.Windows.Forms;

namespace GameArchiveSync.App.Forms
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
            if (this.IsRepoAvailable())
            {
                WinFormsUtil.Alert("验证成功！");
            }
            else
            {
                WinFormsUtil.Alert("验证失败，请检查！");
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!this.IsRepoAvailable())
            {
                WinFormsUtil.Alert("存储库配置有误，请检查！");
                return;
            }
            var gameArchiveStorageRepo = new GameArchiveStorageRepo
            {
                RepoAddress = TbGitRepoAddress.Text.Trim(),
                GitCredential = new GitCredential
                {
                    AuthorizationMode = AuthorizationMode.UserNameAndPassword,
                    UserName = TbUsername.Text.Trim(),
                    Password = TbPassword.Text
                }
            };
            var saved = this.gasBiz.SaveGameArchiveStorageRepoInfo(gameArchiveStorageRepo);
            if (saved)
            {
                WinFormsUtil.Alert("保存成功！");
            }
            else
            {
                WinFormsUtil.Alert("保存失败！");
            }
        }

        private void SettingsFrm_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }

        #endregion UI Events

        #region Util Functions
        private bool IsRepoAvailable()
        {
            var isAvailable = this.gitBiz.CheckRemoteRepositoryAvailable(this.TbGitRepoAddress.Text.Trim(), new GitCredential
            {
                UserName = TbUsername.Text.Trim(),
                Password = TbPassword.Text
            });
            return isAvailable;
        }

        private void LoadData()
        {
            var repoSettings = this.gasBiz.GetGameArchiveStorageRepoInfo();
            if (repoSettings != null)
            {
                TbGitRepoAddress.Text = repoSettings.RepoAddress;
                TbUsername.Text = repoSettings.GitCredential.UserName;
                TbPassword.Text = repoSettings.GitCredential.Password;
            }
        }
        #endregion

    }
}