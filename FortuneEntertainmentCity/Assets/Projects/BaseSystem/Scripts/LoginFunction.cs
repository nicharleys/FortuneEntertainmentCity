using UnityEngine;

public class LoginFunction : ISystemFunction {
    #region UI
    public SelectLoginUI SelectLoginUI { get; private set; }
    public LoginAccountUI LoginAccountUI { get; private set; }
    public ForgotPasswordUI ForgotPasswordUI { get; private set; }
    public CreateAccountUI CreateAccountUI { get; private set; }
    #endregion
    #region System
    private SelectLoginSystem _selectLoginSystem = null;
    private LoginAccountSystem _loginAccountSystem = null;
    private ForgotPasswordSystem _forgotPasswordSystem = null;
    private CreateAccountSystem _createAccountSystem = null;
    #endregion
    #region Signleton
    private static LoginFunction _instance;
    public static LoginFunction Instance {
        get {
            if(_instance == null)
                _instance = new LoginFunction();
            return _instance;
        }
    }
    public LoginFunction() {
    }
    #endregion
    #region Commonly
    public override void Initialize() {
        #region UI
        SelectLoginUI = new SelectLoginUI(this);
        LoginAccountUI = new LoginAccountUI(this);
        CreateAccountUI = new CreateAccountUI(this);
        ForgotPasswordUI = new ForgotPasswordUI(this);
        #endregion
        #region System
        _selectLoginSystem = new SelectLoginSystem(this);
        _loginAccountSystem = new LoginAccountSystem(this);
        _forgotPasswordSystem = new ForgotPasswordSystem(this);
        _createAccountSystem = new CreateAccountSystem(this);
        #endregion
    }
    public override void Release() {
        #region UI
        SelectLoginUI = null;
        LoginAccountUI = null;
        CreateAccountUI = null;
        ForgotPasswordUI = null;
        #endregion
        #region System
        _selectLoginSystem = null;
        _loginAccountSystem = null;
        _forgotPasswordSystem = null;
        _createAccountSystem = null;
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
    public void AutoLogin() {
        _selectLoginSystem.AutoLogin();
    }
    public void SetStateLobby() {
        SceneSwitchController.SwitchScene("LobbyScene").GetAwaiter();
    }
    public void ClearInstance() {
        _instance = null;
    }
}
