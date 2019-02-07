using System.Windows.Forms;

namespace GameArchiveSync.App
{
    public static class WinFormsUtil
    {
        public static DialogResult Alert(string text, string caption = "提示")
        {
            return MessageBox.Show(text, caption);
        }
    }
}