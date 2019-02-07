using GameArchiveSync.Business.Models;
using LibGit2Sharp;
using LibGit2Sharp.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameArchiveSync.Business.Implements
{
    public class DefaultGitBusiness : IGitBusiness
    {
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

        public bool CheckRemoteRepositoryAvailable(string url, GitCredential gitCredential)
        {
            var x = Repository.ListRemoteReferences(url, this.GetCredentialsHandler(gitCredential)).ToList();
            return x.Count > 0;
        }
    }
}