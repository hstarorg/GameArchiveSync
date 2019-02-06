namespace GameArchiveSync.Business.Models
{
    public class GitCredential
    {
        public AuthorizationMode AuthorizationMode { get; set; } = AuthorizationMode.UserNameAndPassword;

        #region AuthorizationMode = DeployKey
        public string DeployKey { get; set; }
        #endregion

        #region AuthorizationMode = UserNameAndPassword
        public string UserName { get; set; }

        public string Password { get; set; }
        #endregion
    }
}
