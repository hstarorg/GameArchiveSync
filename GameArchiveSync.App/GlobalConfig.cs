using System;

namespace GameArchiveSync.App
{
    public static class GlobalConfig
    {
        /// <summary>
        /// DB文件路径
        /// </summary>
        public readonly static string DbPath;

        public readonly static string TempRepoPath;

        public const string CurrentVersion = "0.0.1";

        static GlobalConfig()
        {
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;

            DbPath = $"{baseDir}/GameArchiveSync.db";
            TempRepoPath = $"{baseDir}/repo";
        }
    }
}