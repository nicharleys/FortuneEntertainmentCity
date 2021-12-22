using UnityEngine.UI;
public class SelectLoginUI : IUserInterface {
    public Button AccountLoginButton { get; private set; }
    public Button GuestLoginButton { get; private set; }
    public SelectLoginUI(ISystemFunction theFunction) : base(theFunction) {
        Initialize();
    }
    public override void Initialize() {
        StaticRootUI = UITool.FindUIGameObject(CanvasType.Static, "SelectLoginUI");

        AccountLoginButton = UITool.GetUIComponent<Button>(StaticRootUI, "AccountLoginButton");
        GuestLoginButton = UITool.GetUIComponent<Button>(StaticRootUI, "GuestLoginButton");
    }
}
