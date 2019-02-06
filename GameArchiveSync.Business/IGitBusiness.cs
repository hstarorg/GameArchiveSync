using GameArchiveSync.Business.Models;

namespace GameArchiveSync.Business
{
    public interface IGitBusiness
    {
        bool CheckRemoteRepositoryAvailable(string url, GitCredential gitCredential);

        bool IsGitRepository(string workdirPath);









        bool Fetch(string gitPath);

        string CloneRepo(string gitAddress, string workdirPath);
    }
}
