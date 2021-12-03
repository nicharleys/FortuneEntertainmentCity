public class SlotMachineGameSystem : ISystem {
    private SlotMachineFunction _slotMachineFunction = null;
    public SlotMachineGameSystem(ISystemFunction theFunction) : base(theFunction) {
        Initialize();
    }
    public override void SetSystemFunction(ISystemFunction theFunction) {
        _slotMachineFunction = theFunction as SlotMachineFunction;
    }
    public override void Initialize() {
        _slotMachineFunction.SlotMachineGameUI.BackLobbyButton.onClick.AddListener(() => OnBackLobbyClick());

    }
    private void OnBackLobbyClick() {
        _slotMachineFunction.SetStateLobby();
    }

}
