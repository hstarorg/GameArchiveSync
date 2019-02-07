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
        public bool Fetch(string gitPath)
        {
            using (var repo = new Repository(gitPath))
            {
                var fetchOpt = new FetchOptions
                {
                    CredentialsProvider = (url, user, cred) => new DefaultCredentials()
                    {
                    }
                };
                string logMessage = "";
                var remote = repo.Network.Remotes["origin"];
                IEnumerable<string> refSpecs = remote.FetchRefSpecs.Select(x => x.Specification);
                Commands.Fetch(repo, remote.Name, refSpecs, fetchOpt, logMessage);
            }
            return true;
        }

        public string CloneRepo(string gitAddress, string workdirPath)
        {
            return Repository.Clone(gitAddress, workdirPath, new CloneOptions
            {
                BranchName = "master",

                CredentialsProvider = (url, usernameFromUrl, type) => new UsernamePasswordCredentials
                {
                    Username = "",
                    Password = ""
                }
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