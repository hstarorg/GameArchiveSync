using GameArchiveSync.Business.Models;

namespace GameArchiveSync.Business
{
    public interface IGitBusiness
    {
        bool CheckRemoteRepositoryAvailable(string url, GitCredential gitCredential);

        bool IsGitRepository(string workdirPath);

        string CloneRepo(string workdirPath, GameArchiveStorageRepo repoInfo);
    }
}