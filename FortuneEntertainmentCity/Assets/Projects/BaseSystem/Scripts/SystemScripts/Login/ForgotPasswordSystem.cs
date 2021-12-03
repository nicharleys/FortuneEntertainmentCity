using System.Threading.Tasks;

public class ForgotPasswordSystem : ISystem {
    private LoginFunction _loginFunction = null;
    public ForgotPasswordSystem(ISystemFunction theFunction) : base(theFunction) {
        Initialize();
    }
    public override void SetSystemFunction(ISystemFunction theFunction) {
        _loginFunction = theFunction as LoginFunction;
        DataCenter.Instance.NetworkFailedHandler += OnNetworkFailed;
    }
    public override void Initialize() {
        _loginFunction.ForgotPasswordUI.SendButton.onClick.AddListener(() => OnSendPasswordClick());
        _loginFunction.ForgotPasswordUI.BackButton.onClick.AddListener(() => OnBackClick());
        _loginFunction.ForgotPasswordUI.ShowFailedText.gameObject.SetActive(false);
    }
    private void OnSendPasswordClick() {
        SendPassword().GetAwaiter();
    }
    private async Task SendPassword() {
        if(string.IsNullOrEmpty(_loginFunction.ForgotPasswordUI.EmailInputField.text) || string.IsNullOrEmpty(_loginFunction.ForgotPasswordUI.AccountInputField.text)) {
            ShowSendFailed(true, "* 請填寫信箱跟帳號 *");
            return;
        }
        SetUiEnabled(false);
        Task networkTestTask = DataCenter.Instance.NetworkTest();
        while(!networkTestTask.IsCompleted)
            await Task.Yield();

        Task<string> SendPasswordTask = DataCenter.Instance.UserInfoMemento.ForgotPassword(_loginFunction.ForgotPasswordUI.EmailInputField.text, _loginFunction.ForgotPasswordUI.AccountInputField.text);
        while(!SendPasswordTask.IsCompleted)
            await Task.Yield();

        if(SendPasswordTask.Result == "1") {
            ShowSendFailed(true, "* 信箱錯誤 *");
            ResetUI();
            SetUiEnabled(true);
            return;
        }
        else if(SendPasswordTask.Result == "2") {
            ResetUI();
            ShowSendFailed(true, "* 帳號錯誤 *");
            SetUiEnabled(true);
            return;
        }
        else if(SendPasswordTask.Result == "3") {
            ResetUI();
            ShowSendFailed(true, "* 已發送至信箱 *");
            SetUiEnabled(true);
            return;
        }
        else if(SendPasswordTask.Result == "0") {
            ShowSendFailed(false, "");
            SetUiEnabled(true);
            OnBackClick();
            return;
        }
    }
    private void OnBackClick() {
        _loginFunction.LoginAccountUI.ShowUI();
        _loginFunction.ForgotPasswordUI.HideUI();
    }
    private void SetUiEnabled(bool enabled) {
        _loginFunction.ForgotPasswordUI.EmailInputField.interactable = enabled;
        _loginFunction.ForgotPasswordUI.AccountInputField.interactable = enabled;
        _loginFunction.ForgotPasswordUI.BackButton.interactable = enabled;
        _loginFunction.ForgotPasswordUI.SendButton.interactable = enabled;
    }
    private void ShowSendFailed(bool active, string failMessage) {
        _loginFunction.ForgotPasswordUI.ShowFailedText.text = failMessage;
        _loginFunction.ForgotPasswordUI.ShowFailedText.gameObject.SetActive(active);
    }
    private void ResetUI() {
        _loginFunction.ForgotPasswordUI.EmailInputField.text = "";
        _loginFunction.ForgotPasswordUI.AccountInputField.text = "";
    }
    private void OnNetworkFailed() {
        SetUiEnabled(true);
    }
}
