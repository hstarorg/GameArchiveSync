using System;

namespace GameArchiveSync.App
{
    public static class GlobalConfig
    {
        /// <summary>
        /// DB文件路径
        /// </summary>
        public readonly static string DbPath;

        static GlobalConfig()
        {
            DbPath = $"{AppDomain.CurrentDomain.BaseDirectory}/GameArchiveSync.db";
        }
    }
}