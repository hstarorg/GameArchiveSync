using GameArchiveSync.Business.Models;
using System.Threading.Tasks;

namespace GameArchiveSync.Business
{
    public interface IGameArchiveSyncBusiness
    {
        Task<GameArchiveStorageRepo> GetGameArchiveStorageRepoInfo();
    }
}
