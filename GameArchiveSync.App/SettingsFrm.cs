﻿using GameArchiveSync.Business;
using GameArchiveSync.Business.Implements;
using GameArchiveSync.Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameArchiveSync.App
{
    public partial class SettingsFrm : Form
    {
        private readonly IGitBusiness gitBiz;
        public SettingsFrm()
        {
            InitializeComponent();
            gitBiz = new DefaultGitBusiness();
        }

        #region UI Events

        private void SettingsFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
                Application.Exit();
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

        #endregion
    }
}