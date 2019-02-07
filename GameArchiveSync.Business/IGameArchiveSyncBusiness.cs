using GameArchiveSync.Business.Models;
using System.Collections.Generic;

namespace GameArchiveSync.Business
{
    public interface IGameArchiveSyncBusiness
    {
        GameArchiveStorageRepo GetGameArchiveStorageRepoInfo();

        bool HasGameArchiveStorageRepo();

        bool SaveGameArchiveStorageRepoInfo(GameArchiveStorageRepo repoSettingInfo);

        bool SyncGameArchiveList(string gameArchiveListUrl);

        IList<GameArchive> GetAllGameArchiveList();

        IList<GameArchive> GetLocalGameArchiveList(string userName);

        bool SyncGameArchiveToRemote(IList<GameArchive> gameArchives, string gitWorkdir, string userName);
    }
}