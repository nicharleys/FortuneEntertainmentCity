using UnityEngine.UI;
public class ExampleUI : IUserInterface {
    private ExampleFunction _exampleFunction = null;
    public Button BackLobbyButton { get; private set; }

    public ExampleUI(ISystemFunction theFunction) : base(theFunction) {
        Initialize();
    }
    protected override void SetSystemFunction(ISystemFunction theFunction) {
        _exampleFunction = theFunction as ExampleFunction;
    }
    public override void Initialize() {
        StaticRootUI = UITool.FindUIGameObject(CanvasType.Static, "GameUI");

        BackLobbyButton = UITool.GetUIComponent<Button>(StaticRootUI, "BackLobbyButton");
    }
    public override void Release() {
    }
    public override void HideUI() {
        Release();
        base.HideUI();
    }
}
