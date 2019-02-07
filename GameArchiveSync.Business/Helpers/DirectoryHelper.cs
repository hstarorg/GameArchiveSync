using System.IO;

namespace GameArchiveSync.Business.Helpers
{
    public static class DirectoryHelper
    {
        /// <summary>
        /// 拷贝目录
        /// </summary>
        /// <param name="fromDir"></param>
        /// <param name="toDir"></param>
        public static void CopyDirectory(string fromDir, string toDir)
        {
            var fromDirInfo = new DirectoryInfo(fromDir);
            var toDirInfo = new DirectoryInfo(toDir);
            if (!fromDirInfo.Exists)
            {
                throw new DirectoryNotFoundException($"{fromDir} not found.");
            }
            if (!toDirInfo.Exists)
            {
                toDirInfo.Create();
            }
            // 拷贝文件
            var files = fromDirInfo.GetFiles();
            for (int i = 0; i < files.Length; i++)
            {
                File.Copy(files[i].FullName, Path.Combine(toDir, files[i].Name), true);
            }
            // 拷贝目录
            var dirs = fromDirInfo.GetDirectories();
            for (int i = 0; i < dirs.Length; i++)
            {
                CopyDirectory(dirs[i].FullName, Path.Combine(toDir, dirs[i].Name));
            }
        }
    }
}
