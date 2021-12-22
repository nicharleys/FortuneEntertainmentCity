using System.Threading.Tasks;

public class SelectLoginSystem : ISystem {
    private LoginFunction _loginFunction = null;
    public SelectLoginSystem(LoginFunction theFunction) : base(theFunction) {
        _loginFunction = theFunction;
        DataCenter.Instance.NetworkFailedHandler += OnNetworkFailed;
    }
    public void AutoLogin() {
        if(!DataRequest.CheckFile("LoginType")) {
            _loginFunction.SelectLoginUI.AccountLoginButton.onClick.AddListener(() => OnAccountLoginClick());
            _loginFunction.SelectLoginUI.GuestLoginButton.onClick.AddListener(() => OnGuestLoginClick());
            return;
        }
        Login(DataRequest.LocalLoad<LoginType>("LoginType").Type).GetAwaiter().OnCompleted(() => {
            _loginFunction.SelectLoginUI.AccountLoginButton.onClick.AddListener(() => OnAccountLoginClick());
            _loginFunction.SelectLoginUI.GuestLoginButton.onClick.AddListener(() => OnGuestLoginClick());
        });
    }
    private void OnAccountLoginClick() {
        SetUiEnabled(false);
        if(!DataRequest.CheckFile("AccountUserInfo")) {
            _loginFunction.LoginAccountUI.ShowUI();
            _loginFunction.SelectLoginUI.HideUI();
            SetUiEnabled(true);
            return;
        }
        Login("AccountUserInfo").GetAwaiter();
    }
    private void OnGuestLoginClick() {
        SetUiEnabled(false);
        if(!DataRequest.CheckFile("GuestUserInfo")) {
            UserInfo newUserInfo = new UserInfo();
            newUserInfo.Account = MathCount.GetRandom(15);
            newUserInfo.Password = MathCount.GetRandom(15);
            DataRequest.LocalSave(newUserInfo, "GuestUserInfo");
        }
        Login("GuestUserInfo").GetAwaiter();
    }
    private async Task Login(string loginInfo) {
        SetUiEnabled(false);
        Task networkTestTask = DataCenter.Instance.NetworkTest();
        while(!networkTestTask.IsCompleted)
            await Task.Yield();
        if(!DataRequest.CheckFile(loginInfo)) {
            SetUiEnabled(true);
            return;
        }
        UserInfo oldUserInfo = DataRequest.LocalLoad<UserInfo>(loginInfo);
        Task<string> loginTask = DataCenter.Instance.UserInfoMemento.LoginAccount(oldUserInfo.Account, oldUserInfo.Password);
        while(!loginTask.IsCompleted)
            await Task.Yield();

        if(loginTask.Result == "0") {
            DataRequest.LocalDelete(loginInfo);
            SetUiEnabled(true);
        }
        else if(loginTask.Result == "1") {
            LoginType loginType = new LoginType();
            loginType.Type = loginInfo;
            DataRequest.LocalSave(loginType, "LoginType");

            await Task.Delay(500);
            SetUiEnabled(true);

            _loginFunction.SetStateLobby();
        }
    }
    private void SetUiEnabled(bool enabled) {
        _loginFunction.SelectLoginUI.AccountLoginButton.interactable = enabled;
        _loginFunction.SelectLoginUI.GuestLoginButton.interactable = enabled;
    }
    private void OnNetworkFailed() {
        SetUiEnabled(true);
    }
}
