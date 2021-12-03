using UnityEngine.UI;

public class ForgotPasswordUI : IUserInterface {
    private LoginFunction _loginFunction = null;
    public InputField EmailInputField { get; private set; }
    public InputField AccountInputField { get; private set; }
    public Text ShowFailedText { get; private set; }
    public Button SendButton { get; private set; }
    public Button BackButton { get; private set; }
    public ForgotPasswordUI(ISystemFunction theFunction) : base(theFunction) {
        Initialize();
        HideUI();
    }
    protected override void SetSystemFunction(ISystemFunction theFunction) {
        _loginFunction = theFunction as LoginFunction;
    }
    public override void Initialize() {
        DynamicRootUI = UITool.FindUIGameObject(CanvasType.Dynamic, "ForgotPasswordUI");
        StaticRootUI = UITool.FindUIGameObject(CanvasType.Static, "ForgotPasswordUI");

        EmailInputField = UITool.GetUIComponent<InputField>(DynamicRootUI, "EmailInputField");
        AccountInputField = UITool.GetUIComponent<InputField>(DynamicRootUI, "AccountInputField");
        ShowFailedText = UITool.GetUIComponent<Text>(DynamicRootUI, "ShowFailedText");
        SendButton = UITool.GetUIComponent<Button>(StaticRootUI, "SendButton");
        BackButton = UITool.GetUIComponent<Button>(StaticRootUI, "BackButton");
    }
    public override void Release() {
        AccountInputField.text = "";
        EmailInputField.text = "";
        ShowFailedText.text = "";
    }
    public override void HideUI() {
        Release();
        base.HideUI();
    }
}
