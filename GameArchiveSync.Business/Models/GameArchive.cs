namespace GameArchiveSync.Business.Models
{
    public class GameArchive
    {
        /// <summary>
        /// 游戏ID
        /// </summary>
        public string GameId { get; set; }

        /// <summary>
        /// 游戏名称
        /// </summary>
        public string GameName { get; set; }

        /// <summary>
        /// 操作系统
        /// </summary>
        public OSPlatform Platform { get; set; } = OSPlatform.Windows10;

        /// <summary>
        /// 根路径
        /// </summary>
        public string RootDir { get; set; }

        /// <summary>
        /// 存储位置（相对于根路径）
        /// </summary>
        public string StorageLocation { get; set; }

        /// <summary>
        /// 是否本地配置
        /// </summary>
        public bool IsLocal { get; set; }
    }
}
