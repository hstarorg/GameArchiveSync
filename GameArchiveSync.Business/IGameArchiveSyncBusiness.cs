using GameArchiveSync.Business.Models;

namespace GameArchiveSync.Business
{
    public interface IGameArchiveSyncBusiness
    {
        GameArchiveStorageRepo GetGameArchiveStorageRepoInfo();

        bool HasGameArchiveStorageRepo();
    }
}