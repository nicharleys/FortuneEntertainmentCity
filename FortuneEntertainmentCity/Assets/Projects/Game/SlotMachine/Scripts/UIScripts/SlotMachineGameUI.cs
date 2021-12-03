using UnityEngine.UI;

public class SlotMachineGameUI : IUserInterface {
    private SlotMachineFunction _slotMachineFunction = null;
    public Button BackLobbyButton { get; private set; }

    public SlotMachineGameUI(ISystemFunction theFunction) : base(theFunction) {
        Initialize();
    }
    protected override void SetSystemFunction(ISystemFunction theFunction) {
        _slotMachineFunction = theFunction as SlotMachineFunction;
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
