using GameArchiveSync.Business.Models;
using LibGit2Sharp;
using LibGit2Sharp.Handlers;
using System;
using System.Linq;

namespace GameArchiveSync.Business.Implements
{
    public class DefaultGitBusiness : IGitBusiness
    {
        /// <summary>
        /// Clone仓库
        /// </summary>
        /// <param name="workdirPath"></param>
        /// <param name="repoInfo"></param>
        /// <returns></returns>
        public string CloneRepo(string workdirPath, GameArchiveStorageRepo repoInfo)
        {
            return Repository.Clone(repoInfo.RepoAddress, workdirPath, new CloneOptions
            {
                BranchName = repoInfo.Branch,
                CredentialsProvider = this.GetCredentialsHandler(repoInfo.GitCredential)
            });
        }

        public bool IsGitRepository(string workdirPath)
        {
            return Repository.IsValid(workdirPath);
        }

        private CredentialsHandler GetCredentialsHandler(GitCredential gitCredential)
        {
            return (url, usernameFromUrl, types) =>
            {
                switch (gitCredential.AuthorizationMode)
                {
                    case AuthorizationMode.UserNameAndPassword:
                        return new UsernamePasswordCredentials
                        {
                            Username = gitCredential.UserName,
                            Password = gitCredential.Password
                        };

                    default:
                        throw new ArgumentException("Invalid AuthorizationMode");
                }
            };
        }

        /// <summary>
        /// 检查仓库是否可用
        /// </summary>
        /// <param name="url"></param>
        /// <param name="gitCredential"></param>
        /// <returns></returns>
        public bool CheckRemoteRepositoryAvailable(string url, GitCredential gitCredential)
        {
            var x = Repository.ListRemoteReferences(url, this.GetCredentialsHandler(gitCredential)).ToList();
            return x.Count > 0;
        }

        public bool CommitAndPush(string workdir, string message, GitCredential gitCredential)
        {
            using (var repo = new Repository(workdir))
            {
                Commands.Stage(repo, "*");

                // Create the committer's signature and commit
                Signature author = new Signature("GameArchiveSync", "hm910705@163.com", DateTime.Now);
                Signature committer = author;

                // Commit to the repository
                Commit commit = repo.Commit(message, author, committer);

                // Push
                var pushOpt = new PushOptions()
                {
                    CredentialsProvider = this.GetCredentialsHandler(gitCredential)
                };
                repo.Network.Push(repo.Branches["master"], pushOpt);
                return true;
            }
        }
    }
}