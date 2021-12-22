using System.Threading.Tasks;

public class CreateAccountSystem : ISystem {
    private LoginFunction _loginFunction = null;
    private bool _isRunLogin = false;
    private bool _isSendVerification = false;
    public CreateAccountSystem(LoginFunction theFunction) : base(theFunction) {
        _loginFunction = theFunction;
        DataCenter.Instance.NetworkFailedHandler += OnNetworkFailed;
        Initialize();
    }
    public override void Initialize() {
        _loginFunction.CreateAccountUI.SendVerificationButton.onClick.AddListener(() => OnSendVerificationClick());
        _loginFunction.CreateAccountUI.LoginButton.onClick.AddListener(() => OnLoginClick());
        _loginFunction.CreateAccountUI.BackButton.onClick.AddListener(() => OnBackClick());
        _loginFunction.CreateAccountUI.VerificationMessageText.gameObject.SetActive(false);
    }
    private void OnSendVerificationClick() {
        SendVerification().GetAwaiter();
    }
    private async Task SendVerification() {
        if(string.IsNullOrEmpty(_loginFunction.CreateAccountUI.EmailInputField.text) || string.IsNullOrEmpty(_loginFunction.CreateAccountUI.AccountInputField.text)) {
            ShowLoginFailed(true, "* 請填寫信箱跟帳號 *");
            return;
        }
        _loginFunction.CreateAccountUI.SendVerificationButton.interactable = false;
        Task networkTestTask = DataCenter.Instance.NetworkTest();
        while(!networkTestTask.IsCompleted)
            await Task.Yield();

        _isSendVerification = true;
        _loginFunction.CreateAccountUI.SendVerificationButton.interactable = false;
        Task<string> sendVerificationTask = DataCenter.Instance.UserInfoMemento.SendVerification(_loginFunction.CreateAccountUI.EmailInputField.text,  _loginFunction.CreateAccountUI.AccountInputField.text);
        while(!sendVerificationTask.IsCompleted)
            await Task.Yield();

        if(sendVerificationTask.Result == "0")
            ShowLoginFailed(true, "* 信箱錯誤 *");

        TimeCount.Timer(60);
        _loginFunction.CreateAccountUI.VerificationMessageText.gameObject.SetActive(true);
        while(!TimeCount.IsTimeUp) {
            _loginFunction.CreateAccountUI.SendVerificationText.text = TimeCount.Seconds.ToString() + "秒";
            await Task.Yield();
        }
        _loginFunction.CreateAccountUI.SendVerificationText.text = "發送驗證";
        _loginFunction.CreateAccountUI.SendVerificationButton.interactable = true;
        _isSendVerification = false;
    }
    private void OnLoginClick() {
        CreateAccount().GetAwaiter();
    }
    private async Task CreateAccount() {
        if(string.IsNullOrEmpty(_loginFunction.CreateAccountUI.EmailInputField.text) || string.IsNullOrEmpty(_loginFunction.CreateAccountUI.AccountInputField.text) || string.IsNullOrEmpty(_loginFunction.CreateAccountUI.PasswordInputField.text) || string.IsNullOrEmpty(_loginFunction.CreateAccountUI.RePasswordInputField.text) || string.IsNullOrEmpty(_loginFunction.CreateAccountUI.VerificationInputField.text)) {
            ShowLoginFailed(true, "* 請填寫資料 *");
            return;
        }
        if(_loginFunction.CreateAccountUI.PasswordInputField.text != _loginFunction.CreateAccountUI.RePasswordInputField.text) {
            ShowLoginFailed(true, "* 密碼輸入錯誤 *");
            return;
        }
        SetUiEnabled(false);
        Task networkTestTask = DataCenter.Instance.NetworkTest();
        while(!networkTestTask.IsCompleted)
            await Task.Yield();

        Task<string> createAccountTask = DataCenter.Instance.UserInfoMemento.CreateAccount(_loginFunction.CreateAccountUI.EmailInputField.text, _loginFunction.CreateAccountUI.AccountInputField.text,
            _loginFunction.CreateAccountUI.PasswordInputField.text, _loginFunction.CreateAccountUI.VerificationInputField.text);
        while(!createAccountTask.IsCompleted)
            await Task.Yield();

        if(createAccountTask.Result == "0") {
            ShowLoginFailed(true, "* 帳號已註冊 *");
            SetUiEnabled(true);
            return;
        }
        else if(createAccountTask.Result == "2") {
            ShowLoginFailed(true, "* 驗證碼錯誤 *");
            SetUiEnabled(true);
            return;
        }
        Login().GetAwaiter().OnCompleted(() => { SetUiEnabled(true); });
    }
    private async Task Login() {
        _isRunLogin = true;
        Task networkTestTask = DataCenter.Instance.NetworkTest();
        while(!networkTestTask.IsCompleted)
            await Task.Yield();

        Task<string> loginTask = DataCenter.Instance.UserInfoMemento.LoginAccount(_loginFunction.CreateAccountUI.AccountInputField.text, _loginFunction.CreateAccountUI.PasswordInputField.text);
        while(!loginTask.IsCompleted)
            await Task.Yield();
 
        if(loginTask.Result == "0") {
            OnBackClick();
            _isRunLogin = false;
            return;
        }
        else if(loginTask.Result == "1") {
            UserInfo newUserInfo = new UserInfo();
            newUserInfo.Account = _loginFunction.CreateAccountUI.AccountInputField.text;
            newUserInfo.Password = _loginFunction.CreateAccountUI.PasswordInputField.text;
            DataRequest.LocalSave(newUserInfo, "AccountUserInfo");

            LoginType loginType = new LoginType();
            loginType.Type = "AccountUserInfo";
            DataRequest.LocalSave(loginType, "LoginType");

            await Task.Delay(500);
            _isRunLogin = false;

            _loginFunction.SetStateLobby();
        }
    }
    private void OnBackClick() {
        _loginFunction.LoginAccountUI.ShowUI();
        _loginFunction.CreateAccountUI.HideUI();
    }
    private void SetUiEnabled(bool enabled) {
        _loginFunction.CreateAccountUI.EmailInputField.interactable = enabled;
        _loginFunction.CreateAccountUI.AccountInputField.interactable = enabled;
        _loginFunction.CreateAccountUI.RePasswordInputField.interactable = enabled;
        _loginFunction.CreateAccountUI.PasswordInputField.interactable = enabled;
        if(!_isSendVerification)
            _loginFunction.CreateAccountUI.SendVerificationButton.interactable = enabled;
        _loginFunction.CreateAccountUI.VerificationInputField.interactable = enabled;
        _loginFunction.CreateAccountUI.LoginButton.interactable = enabled;
        _loginFunction.CreateAccountUI.BackButton.interactable = enabled;
    }
    private void ShowLoginFailed(bool active, string failMessage) {
        _loginFunction.CreateAccountUI.VerificationMessageText.text = failMessage;
        _loginFunction.CreateAccountUI.VerificationMessageText.gameObject.SetActive(active);
    }
    private void OnNetworkFailed() {
        if(_isRunLogin) {
            OnBackClick();
            _isRunLogin = false;
        }
        SetUiEnabled(true);
    }
}
