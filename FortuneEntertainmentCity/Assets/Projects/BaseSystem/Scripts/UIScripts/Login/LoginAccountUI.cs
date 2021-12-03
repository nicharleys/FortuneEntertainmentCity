using UnityEngine.UI;
public class LoginAccountUI : IUserInterface {
    private LoginFunction _loginFunction = null;
    public InputField AccountInputField { get; private set; }
    public InputField PasswordInputField { get; private set; }
    public Button ForgotPasswordButton { get; private set; }
    public Button LoginButton { get; private set; }
    public Button CreateAccountButton { get; private set; }
    public Text ShowFailedText { get; private set; }
    public Button BackButton { get; private set; }
    public LoginAccountUI(ISystemFunction theFunction) : base(theFunction) {
        Initialize();
        HideUI();
    }
    protected override void SetSystemFunction(ISystemFunction theFunction) {
        _loginFunction = theFunction as LoginFunction;
    }
    public override void Initialize() {
        DynamicRootUI = UITool.FindUIGameObject(CanvasType.Dynamic, "LoginAccountUI");
        StaticRootUI = UITool.FindUIGameObject(CanvasType.Static, "LoginAccountUI");

        AccountInputField = UITool.GetUIComponent<InputField>(DynamicRootUI, "AccountInputField");
        PasswordInputField = UITool.GetUIComponent<InputField>(DynamicRootUI, "PasswordInputField");
        ShowFailedText = UITool.GetUIComponent<Text>(DynamicRootUI, "ShowFailedText");
        ForgotPasswordButton = UITool.GetUIComponent<Button>(StaticRootUI, "ForgotPasswordButton");
        LoginButton = UITool.GetUIComponent<Button>(StaticRootUI, "LoginButton");
        CreateAccountButton = UITool.GetUIComponent<Button>(StaticRootUI, "CreateAccountButton");
        BackButton = UITool.GetUIComponent<Button>(StaticRootUI, "BackButton");
    }
    public override void Release() {
        AccountInputField.text = "";
        PasswordInputField.text = "";
        ShowFailedText.text = "";
        ShowFailedText.gameObject.SetActive(false);
    }
    public override void HideUI() {
        Release();
        base.HideUI();
    }
}
