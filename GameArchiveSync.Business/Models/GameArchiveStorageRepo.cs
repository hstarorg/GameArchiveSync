namespace GameArchiveSync.Business.Models
{
    public class GameArchiveStorageRepo
    {
        public GameArchiveStorageRepo()
        {
            this.GitCredential = new GitCredential();
        }
        public string RepoAddress { get; set; } = "";

        public string Branch { get; set; } = "master";

        public GitCredential GitCredential { get; set; }
    }
}