using System.Data;
using System.Data.SQLite;
using System.Threading.Tasks;
using GameArchiveSync.Business.Models;

namespace GameArchiveSync.Business.Implements
{
    public class DefaultGameArchiveSyncBusiness : IGameArchiveSyncBusiness
    {
        private readonly IDbConnection DbConn;
        public DefaultGameArchiveSyncBusiness(string sqlitePath)
        {
            DbConn = new SQLiteConnection(this.BuildSqliteConnectionString(sqlitePath));
        }

        private string BuildSqliteConnectionString(string dataSource)
        {
            var builder = new SQLiteConnectionStringBuilder
            {
                DataSource = dataSource
            };
            return builder.ConnectionString;
        }

        public async Task<GameArchiveStorageRepo> GetGameArchiveStorageRepoInfo()
        {
            return null;
        }
    }
}
