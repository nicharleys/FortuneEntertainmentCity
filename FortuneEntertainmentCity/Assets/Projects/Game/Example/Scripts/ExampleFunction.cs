public class ExampleFunction : ISystemFunction {
    #region State
    public SceneStateContext StateContext { get; private set; }
    #endregion
    #region UI
    public ExampleUI ExampleUI { get; private set; }
    #endregion
    #region System
    private ExampleSystem _exampleSystem = null;
    #endregion
    #region Signleton
    private static ExampleFunction _instance;
    public static ExampleFunction Instance {
        get {
            if(_instance == null)
                _instance = new ExampleFunction();
            return _instance;
        }
    }
    public ExampleFunction() {
    }
    #endregion
    public override void SetStateContext(SceneStateContext stateContext) {
        StateContext = stateContext;
    }
    #region Commonly
    public override void Initialize() {
        #region UI
        ExampleUI = new ExampleUI(this);
        #endregion
        #region System
        _exampleSystem = new ExampleSystem(this);
        #endregion
    }
    public override void Release() {
        #region UI
        ExampleUI = null;
        #endregion
        #region System
        _exampleSystem = null;
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
        StateContext.SetState(new LobbyState(StateContext), "LobbyScene").GetAwaiter();
    }
}
