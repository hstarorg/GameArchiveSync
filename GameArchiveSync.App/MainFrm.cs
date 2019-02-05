using System.Windows.Forms;

namespace GameArchiveSync.App
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

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
    }
}
