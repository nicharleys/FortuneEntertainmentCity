public class LobbyFunction : ISystemFunction {
    #region State
    public SceneStateContext StateContext { get; private set; }
    #endregion
    #region UI
    public LobbyUI LobbyUI { get; private set; }
    public PanelUI PanelUI { get; private set; }
    public UserInfoUI UserInfoUI { get; private set; }
    public DownloadGameUI DownloadGameUI { get; private set; }
    #endregion
    #region System
    private LobbySystem _lobbySystem = null;
    private PanelSystem _panelSystem = null;
    private UserInfoSystem _userInfoSystem = null;
    #endregion
    #region Signleton
    private static LobbyFunction _instance;
    public static LobbyFunction Instance {
        get {
            if(_instance == null)
                _instance = new LobbyFunction();
            return _instance;
        }
    }
    public LobbyFunction() {
    }
    #endregion
    public override void SetStateContext(SceneStateContext stateContext) {
        StateContext = stateContext;
    }
    #region Commonly
    public override void Initialize() {
        #region UI
        LobbyUI = new LobbyUI(this);
        PanelUI = new PanelUI(this);
        UserInfoUI = new UserInfoUI(this);
        DownloadGameUI = new DownloadGameUI(this);
        #endregion
        #region System
        _lobbySystem = new LobbySystem(this);
        _panelSystem = new PanelSystem(this);
        _userInfoSystem = new UserInfoSystem(this);
        #endregion
    }
    public override void Release() {
        #region UI
        LobbyUI = null;
        UserInfoUI = null;
        #endregion
        #region System
        _panelSystem.Release();
        _lobbySystem.Release();
        _lobbySystem = null;
        _panelSystem = null;
        _userInfoSystem = null;
        #endregion
    }
    public override void Update() {
        #region UI

        #endregion
        #region System
        _lobbySystem.Update();
        #endregion
    }
    #endregion
    public void SetStateLogin() {
        StateContext.SetState(new LoginState(StateContext), "LoginScene").GetAwaiter();
    }
    public void SetStateSlotMachine() {
        StateContext.SetState(new SlotMachineState(StateContext), "SlotMachineScene").GetAwaiter();
    }
    public void SetStateExample() {
        StateContext.SetState(new ExampleState(StateContext), "ExampleScene").GetAwaiter();
    }
    public void SettingButtonClose() {
        _panelSystem.OnSettingButtonClose();
    }
}
