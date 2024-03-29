﻿public class UserInfoSystem : ISystem {
    private LobbyFunction _lobbyFunction = null;
    public UserInfoSystem(LobbyFunction theFunction) : base(theFunction) {
        _lobbyFunction = theFunction;
        Initialize();
    }
    public override void Initialize() {
        _lobbyFunction.UserInfoUI.ResetPasswordButton.onClick.AddListener(() => OnResetPasswordClick());
        _lobbyFunction.UserInfoUI.BindAccountButton.onClick.AddListener(() => OnBindAccountClick());
        _lobbyFunction.UserInfoUI.SwitchAccountButton.onClick.AddListener(() => OnSwitchClick());
        _lobbyFunction.UserInfoUI.LogoutButton.onClick.AddListener(() => OnLogoutClick());
    }
    private void OnResetPasswordClick() {
    }
    private void OnBindAccountClick() {
    }
    private void OnSwitchClick() {
        DataRequest.LocalDelete("LoginType");
        _lobbyFunction.SetStateLogin();
    }
    private void OnLogoutClick() {
        DataRequest.LocalDelete(DataRequest.LocalLoad<LoginType>("LoginType").Type);
        DataRequest.LocalDelete("LoginType");
        _lobbyFunction.SetStateLogin();
    }
}
