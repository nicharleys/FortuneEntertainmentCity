using UnityEngine.UI;

public class UserInfoUI : IUserInterface {
    private LobbyFunction _lobbyFunction = null;
    public Button ResetPasswordButton { get; private set; }
    public Button BindAccountButton { get; private set; }
    public Button SwitchAccountButton { get; private set; }
    public Button LogoutButton { get; private set; }
    public Text ShowAccountText { get; private set; }

    public UserInfoUI(ISystemFunction theFunction) : base(theFunction) {
        Initialize();
        HideUI();
    }
    protected override void SetSystemFunction(ISystemFunction theFunction) {
        _lobbyFunction = theFunction as LobbyFunction;
    }
    public override void Initialize() {
        StaticRootUI = UITool.FindUIGameObject(CanvasType.Static, "UserInfoUI");

        ResetPasswordButton = UITool.GetUIComponent<Button>(StaticRootUI, "ResetPasswordButton");
        BindAccountButton = UITool.GetUIComponent<Button>(StaticRootUI, "BindAccountButton");
        SwitchAccountButton = UITool.GetUIComponent<Button>(StaticRootUI, "SwitchAccountButton");
        LogoutButton = UITool.GetUIComponent<Button>(StaticRootUI, "LogoutButton");
        ShowAccountText = UITool.GetUIComponent<Text>(StaticRootUI, "ShowAccountText");
    }
    public override void Release() {
        ShowAccountText.text = "";
    }
}
