using GameArchiveSync.Business.Helpers;
using GameArchiveSync.Business.Models;
using LiteDB;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;

namespace GameArchiveSync.Business.Implements
{
    public class DefaultGameArchiveSyncBusiness : IGameArchiveSyncBusiness
    {
        private readonly string DbPath;

        /// <summary>
        /// 仓库设置表
        /// </summary>
        private const string GAME_ARCHIVE_STORAGE_SETTINGS_COLLECTION = "game_archive_storage_repo";
        private const string GAME_ARCHIVE_COLLECTION = "game_archive";

        public DefaultGameArchiveSyncBusiness(string dbPath)
        {
            this.DbPath = dbPath;
        }

        private LiteCollection<T> GetCollection<T>(LiteDatabase db, string collectionName) where T : class
        {
            return db.GetCollection<T>(collectionName);
        }

        public GameArchiveStorageRepo GetGameArchiveStorageRepoInfo()
        {
            using (var db = new LiteDatabase(this.DbPath))
            {
                var col = this.GetCollection<GameArchiveStorageRepo>(db, GAME_ARCHIVE_STORAGE_SETTINGS_COLLECTION);
                return col.FindById("repoSettings");
            }
        }

        public IList<GameArchive> GetAllGameArchiveList()
        {
            using (var db = new LiteDatabase(this.DbPath))
            {
                var col = this.GetCollection<GameArchive>(db, GAME_ARCHIVE_COLLECTION);
                return col.FindAll().ToList();
            }
        }


        public IList<GameArchive> GetLocalGameArchiveList(string userName)
        {
            var allList = this.GetAllGameArchiveList();
            var localList = allList.AsParallel().Where(x =>
            {
                var gameArchivePath = Path.Combine(x.RootDir.Replace("{UserName}", userName), x.StorageLocation);
                return Directory.Exists(gameArchivePath);
            }).ToList();
            return localList;
        }

        public bool HasGameArchiveStorageRepo()
        {
            var repoInfo = this.GetGameArchiveStorageRepoInfo();
            return repoInfo != null;
        }

        public bool SaveGameArchiveStorageRepoInfo(GameArchiveStorageRepo repoSettingInfo)
        {
            using (var db = new LiteDatabase(this.DbPath))
            {
                var col = this.GetCollection<GameArchiveStorageRepo>(db, GAME_ARCHIVE_STORAGE_SETTINGS_COLLECTION);
                return col.Upsert("repoSettings", repoSettingInfo);
            }
        }

        public bool SyncGameArchiveList(string gameArchiveListUrl)
        {
            // Get game archive list.
            var client = new HttpClient();
            var resultStr = client.GetStringAsync(gameArchiveListUrl).Result;
            var gameArchiveList = resultStr.Parse<IList<GameArchive>>();

            // Write to db
            return this.UpsertGameArchiveList(gameArchiveList);
        }

        private bool UpsertGameArchiveList(IList<GameArchive> gameArchiveList)
        {
            using (var db = new LiteDatabase(this.DbPath))
            {
                var col = this.GetCollection<GameArchive>(db, GAME_ARCHIVE_COLLECTION);
                foreach (var gameArchive in gameArchiveList)
                {
                    col.Upsert(gameArchive.GameId, gameArchive);
                }
            }
            return true;
        }
    }
}