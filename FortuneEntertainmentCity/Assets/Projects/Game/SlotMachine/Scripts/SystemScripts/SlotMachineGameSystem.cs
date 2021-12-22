public class SlotMachineGameSystem : ISystem {
    private SlotMachineFunction _slotMachineFunction = null;
    public SlotMachineGameSystem(SlotMachineFunction theFunction) : base(theFunction) {
        _slotMachineFunction = theFunction;
        Initialize();
    }
    public override void Initialize() {
        _slotMachineFunction.SlotMachineGameUI.BackLobbyButton.onClick.AddListener(() => OnBackLobbyClick());

    }
    private void OnBackLobbyClick() {
        _slotMachineFunction.SetStateLobby();
    }

}
