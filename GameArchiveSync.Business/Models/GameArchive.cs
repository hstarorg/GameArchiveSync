using System;
using System.Runtime.Serialization;

namespace GameArchiveSync.Business.Models
{
    [DataContract]
    public class GameArchive
    {
        /// <summary>
        /// 游戏ID
        /// </summary>
        [DataMember(Name = "gameId")]
        public string GameId { get; set; }

        /// <summary>
        /// 游戏名称
        /// </summary>
        [DataMember(Name = "gameName")]
        public string GameName { get; set; }

        [DataMember(Name = "platform")]
        public string PlatfirmString { get; set; }

        /// <summary>
        /// 操作系统
        /// </summary>

        public OSPlatform Platform
        {
            get
            {
                try
                {
                    return (OSPlatform)Enum.Parse(typeof(OSPlatform), this.PlatfirmString);
                }
                catch
                {
                    return OSPlatform.Windows10;
                }
            }
            set
            {
                this.PlatfirmString = value.ToString();
            }
        }

        /// <summary>
        /// 根路径
        /// </summary>
        [DataMember(Name = "rootDir")]
        public string RootDir { get; set; }

        /// <summary>
        /// 存储位置（相对于根路径）
        /// </summary>
        [DataMember(Name = "storageLocation")]
        public string StorageLocation { get; set; }

        /// <summary>
        /// 是否本地配置
        /// </summary>
        public bool IsLocal { get; set; }
    }
}
