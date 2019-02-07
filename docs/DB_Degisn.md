# DB Design

## 1、GameArchiveStorageRepo 存储仓库配置表

用于存储将游戏存档存储到哪个Git仓库中。

### 表结构

```c#
// 核心对象
public class GameArchiveStorageRepo
{
    public string RepoAddress { get; set; } = "";

    public string Branch { get; set; } = "master";

    public GitCredential GitCredential { get; set; }
}

// 认证相关对象
public class GitCredential
{
    public AuthorizationMode AuthorizationMode { get; set; } = AuthorizationMode.UserNameAndPassword;

    #region AuthorizationMode = DeployKey

    public string DeployKey { get; set; }

    #endregion AuthorizationMode = DeployKey

    #region AuthorizationMode = UserNameAndPassword

    public string UserName { get; set; }

    public string Password { get; set; }

    #endregion AuthorizationMode = UserNameAndPassword
}

// 认证模式枚举
public enum AuthorizationMode
{
    DeployKey,
    UserNameAndPassword
}
```
## 2、