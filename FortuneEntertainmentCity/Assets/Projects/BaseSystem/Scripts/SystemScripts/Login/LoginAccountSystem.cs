using System.Threading.Tasks;

public class LoginAccountSystem : ISystem {
    private LoginFunction _loginFunction = null;
    public LoginAccountSystem(ISystemFunction theFunction) : base(theFunction) {
        Initialize();
    }
    public override void SetSystemFunction(ISystemFunction theFunction) {
        _loginFunction = theFunction as LoginFunction;
        DataCenter.Instance.NetworkFailedHandler += OnNetworkFailed;
    }
    public override void Initialize() {
        _loginFunction.LoginAccountUI.ForgotPasswordButton.onClick.AddListener(() => OnForgotPasswordClick());
        _loginFunction.LoginAccountUI.LoginButton.onClick.AddListener(() => OnAccountLoginClick());
        _loginFunction.LoginAccountUI.CreateAccountButton.onClick.AddListener(() => OnCreateAccountClick());
        _loginFunction.LoginAccountUI.BackButton.onClick.AddListener(() => OnBackClick());
        _loginFunction.LoginAccountUI.ShowFailedText.gameObject.SetActive(false);
    }
    public override void Release() {
        _loginFunction.LoginAccountUI.AccountInputField.text = "";
        _loginFunction.LoginAccountUI.PasswordInputField.text = "";
        ShowLoginFailed(false, "");
    }
    private void OnForgotPasswordClick() {
        _loginFunction.LoginAccountUI.HideUI();
        _loginFunction.ForgotPasswordUI.ShowUI();
    }
    private void OnAccountLoginClick() {
        Login().GetAwaiter();
    }
    private void OnCreateAccountClick() {
        _loginFunction.LoginAccountUI.HideUI();
        _loginFunction.CreateAccountUI.ShowUI();
    }
    private void OnBackClick() {
        _loginFunction.LoginAccountUI.HideUI();
        _loginFunction.SelectLoginUI.ShowUI();
    }
    private async Task Login() {
        SetUiEnabled(false);
        Task networkTestTask = DataCenter.Instance.NetworkTest();
        while(!networkTestTask.IsCompleted)
            await Task.Yield();

        Task<string> loginTask = DataCenter.Instance.UserInfoMemento.LoginAccount(_loginFunction.LoginAccountUI.AccountInputField.text, _loginFunction.LoginAccountUI.PasswordInputField.text);
        while(!loginTask.IsCompleted)
            await Task.Yield();

        if(loginTask.Result == "0") {
            ShowLoginFailed(true, "* 帳號或密碼錯誤 *");
            SetUiEnabled(true);
            return;
        }
        else if(loginTask.Result == "1") {
            UserInfo newUserInfo = new UserInfo();
            newUserInfo.Account = _loginFunction.LoginAccountUI.AccountInputField.text;
            newUserInfo.Password = _loginFunction.LoginAccountUI.PasswordInputField.text;
            DataRequest.LocalSave(newUserInfo, "AccountUserInfo");

            LoginType loginType = new LoginType();
            loginType.Type = "AccountUserInfo";
            DataRequest.LocalSave(loginType, "LoginType");

            await Task.Delay(500);
            SetUiEnabled(true);

            _loginFunction.SetStateLobby();
        }
    }
    private void SetUiEnabled(bool enabled) {
        _loginFunction.LoginAccountUI.AccountInputField.interactable = enabled;
        _loginFunction.LoginAccountUI.PasswordInputField.interactable = enabled;
        _loginFunction.LoginAccountUI.ForgotPasswordButton.interactable = enabled;
        _loginFunction.LoginAccountUI.LoginButton.interactable = enabled;
        _loginFunction.LoginAccountUI.CreateAccountButton.interactable = enabled;
        _loginFunction.LoginAccountUI.BackButton.interactable = enabled;
    }
    private void ShowLoginFailed(bool active, string failMessage) {
        _loginFunction.LoginAccountUI.ShowFailedText.text = failMessage;
        _loginFunction.LoginAccountUI.ShowFailedText.gameObject.SetActive(active);
    }
    private void OnNetworkFailed() {
        SetUiEnabled(true);
    }
}
