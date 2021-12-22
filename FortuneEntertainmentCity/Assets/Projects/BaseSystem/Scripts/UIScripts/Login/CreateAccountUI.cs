using UnityEngine.UI;
public class CreateAccountUI : IUserInterface {
    public InputField EmailInputField { get; private set; }
    public InputField AccountInputField { get; private set; }
    public InputField PasswordInputField { get; private set; }

    public InputField RePasswordInputField { get; private set; }
    public InputField VerificationInputField { get; private set; }
    public Button SendVerificationButton { get; private set; }
    public Text SendVerificationText { get; private set; }
    public Text VerificationMessageText { get; private set; }
    public Button LoginButton { get; private set; }
    public Button BackButton { get; private set; }
    public CreateAccountUI(ISystemFunction theFunction) : base(theFunction) {
        Initialize();
        HideUI();
    }
    public override void Initialize() {
        DynamicRootUI = UITool.FindUIGameObject(CanvasType.Dynamic, "CreateAccountUI");
        StaticRootUI = UITool.FindUIGameObject(CanvasType.Static, "CreateAccountUI");

        EmailInputField = UITool.GetUIComponent<InputField>(DynamicRootUI, "EmailInputField");
        AccountInputField = UITool.GetUIComponent<InputField>(DynamicRootUI, "AccountInputField");
        PasswordInputField = UITool.GetUIComponent<InputField>(DynamicRootUI, "PasswordInputField");
        RePasswordInputField = UITool.GetUIComponent<InputField>(DynamicRootUI, "RePasswordInputField");
        VerificationInputField = UITool.GetUIComponent<InputField>(DynamicRootUI, "VerificationInputField");
        SendVerificationButton = UITool.GetUIComponent<Button>(DynamicRootUI, "SendVerificationButton");
        SendVerificationText = SendVerificationButton.gameObject.GetComponentInChildren<Text>();
        VerificationMessageText = UITool.GetUIComponent<Text>(DynamicRootUI, "VerificationMessageText");
        LoginButton = UITool.GetUIComponent<Button>(StaticRootUI, "LoginButton");
        BackButton = UITool.GetUIComponent<Button>(StaticRootUI, "BackButton");
    }
    public override void Release() {
        AccountInputField.text = "";
        PasswordInputField.text = "";
        VerificationInputField.text = "";
        SendVerificationText.text = "發送驗證";
        VerificationMessageText.text = "";
    }
    public override void HideUI() {
        Release();
        base.HideUI();
    }
}
