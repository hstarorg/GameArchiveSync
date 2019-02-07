using System.Windows.Forms;
using System.IO;

namespace GameArchiveSync.App.Helpers
{
    public static class WinFormsUtil
    {
        /// <summary>
        /// 弹出提示框
        /// </summary>
        /// <param name="text"></param>
        /// <param name="caption"></param>
        /// <returns></returns>
        public static DialogResult Alert(string text, string caption = "提示")
        {
            return MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 在浏览器中打开地址
        /// </summary>
        /// <param name="url"></param>
        public static void OpenUrl(string url)
        {
            System.Diagnostics.Process.Start(url);
        }

        public static string GetCurrentUser()
        {
            return System.Environment.UserName;
        }

        public static void EnsureDirExists(string dir)
        {
            Directory.CreateDirectory(dir);
        }
    }
}