using System.Threading.Tasks;
using GameArchiveSync.Business.Models;
using LiteDB;

namespace GameArchiveSync.Business.Implements
{
    public class DefaultGameArchiveSyncBusiness : IGameArchiveSyncBusiness
    {
        private readonly string DbPath;
        public DefaultGameArchiveSyncBusiness(string dbPath)
        {
            this.DbPath = dbPath;
        }

        public GameArchiveStorageRepo GetGameArchiveStorageRepoInfo()
        {
            using (var db = new LiteDatabase(this.DbPath))
            {
                var col = db.GetCollection<GameArchiveStorageRepo>("game_archive_storage_repo");
                return col.FindOne(x => true);
            }
        }

        public bool HasGameArchiveStorageRepo()
        {
            var repoInfo = this.GetGameArchiveStorageRepoInfo();
            return repoInfo != null;
        }
    }
}
