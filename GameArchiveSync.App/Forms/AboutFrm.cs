using GameArchiveSync.App.Helpers;
using System;
using System.Windows.Forms;

namespace GameArchiveSync.App.Forms
{
    public partial class AboutFrm : Form
    {
        public AboutFrm()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Handle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var url = (sender as LinkLabel).Text;
            WinFormsUtil.OpenUrl(url);
        }

        private void AboutFrm_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void LoadData()
        {
            this.LabVersion.Text += GlobalConfig.CurrentVersion;
        }
    }
}
