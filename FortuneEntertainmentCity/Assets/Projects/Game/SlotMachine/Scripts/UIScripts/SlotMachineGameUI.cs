using UnityEngine.UI;

public class SlotMachineGameUI : IUserInterface {
    public Button BackLobbyButton { get; private set; }

    public SlotMachineGameUI(ISystemFunction theFunction) : base(theFunction) {
        Initialize();
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
