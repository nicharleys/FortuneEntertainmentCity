public class SlotMachineFunction : ISystemFunction {
    #region UI
    public SlotMachineGameUI SlotMachineGameUI { get; private set; }
    #endregion
    #region System
    private SlotMachineGameSystem _slotMachineGameSystem = null;
    #endregion
    #region Signleton
    private static SlotMachineFunction _instance;
    public static SlotMachineFunction Instance {
        get {
            if(_instance == null)
                _instance = new SlotMachineFunction();
            return _instance;
        }
    }
    public SlotMachineFunction() {
    }
    #endregion
    #region Commonly
    public override void Initialize() {
        #region UI
        SlotMachineGameUI = new SlotMachineGameUI(this);
        #endregion
        #region System
        _slotMachineGameSystem = new SlotMachineGameSystem(this);
        #endregion
    }
    public override void Release() {
        #region UI
        SlotMachineGameUI = null;
        #endregion
        #region System
        _slotMachineGameSystem = null;
        #endregion
    }
    public override void Update() {
        #region UI

        #endregion
        #region System

        #endregion
    }
    public override void FixedUpdate() {
        #region System
        #endregion
    }
    #endregion
    public void SetStateLobby() {
        SceneSwitchController.SwitchScene("LobbyScene").GetAwaiter();
    }
    public void ClearInstance() {
        _instance = null;
    }
}
