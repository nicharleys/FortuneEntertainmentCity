using System.Threading.Tasks;
using UnityEngine;

public class UserInfoMemento {
    private DataCenter _dataCenter = null;
    private string _postAddress = "";

    public UserInfoMemento(DataCenter dataCenter, string postAddress) {
        _dataCenter = dataCenter;
        _postAddress = postAddress; 
    }
    private UserInfo _userInfoData;
    public UserInfo UserInfoData { get { return _userInfoData; } private set { _userInfoData = value; } }

    public async Task<string> LoginAccount(string account, string password) {
        if(!await _dataCenter.NetworkPing())
            return null;
        UserInfo userInfo = new UserInfo() {
            Account = account,
            Password = password
        };
        string jsonData = JsonUtility.ToJson(userInfo);
        string result = await DataRequest.RemotePost(_postAddress + "/LoginAccount", jsonData);
        if(result == "1")
            _userInfoData = userInfo;
        return result;
    }
    public async Task<string> ForgotPassword(string email, string account) {
        if(!await _dataCenter.NetworkPing())
            return null;
        EmailInfo emailInfo = new EmailInfo() {
            Email = email,
            Account = account,
        };
        string jsonData = JsonUtility.ToJson(emailInfo);
        string result = await DataRequest.RemotePost(_postAddress + "/ForgotPassword", jsonData);
        return result;
    }
    public async Task<string> SendVerification(string email, string account) {
        if(!await _dataCenter.NetworkPing())
            return null;
        EmailInfo verificationInfo = new EmailInfo() {
            Email = email,
            Account = account,
        };
        string jsonData = JsonUtility.ToJson(verificationInfo);
        string result = await DataRequest.RemotePost(_postAddress + "/SendVerification", jsonData);
        return result;
    }
    public async Task<string> CreateAccount(string email, string account, string password, string verification) {
        if(!await _dataCenter.NetworkPing())
            return null;
        CreateAccountInfo createAccountInfo = new CreateAccountInfo() {
            Email = email,
            Account = account,
            Password = password,
            Verification = verification
        };
        string jsonData = JsonUtility.ToJson(createAccountInfo);
        string result = await DataRequest.RemotePost(_postAddress + "/CreateAccount", jsonData);
        return result;
    }
}
[SerializeField]
public struct UserInfo {
    public string Account;
    public string Password;
}
[SerializeField]
public struct CreateAccountInfo {
    public string Email;
    public string Account;
    public string Password;
    public string Verification;
}
[SerializeField]
public struct EmailInfo {
    public string Email;
    public string Account;
}
[SerializeField]
public struct LoginType {
    public string Type;
}