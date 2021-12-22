using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.U2D;
using UnityEngine.UI;

public class PanelSystem : ISystem {
    private LobbyFunction _lobbyFunction = null;

    private bool _isSettingClick = false;
    private bool _isUserInfoClick = false;
    private bool _isSelfInfoClick = false;

    private AsyncOperationHandle<SpriteAtlas> _loadSpriteAtlasHandle;
    public PanelSystem(LobbyFunction theFunction) : base(theFunction) {
        _lobbyFunction = theFunction;
        Initialize();
    }
    public override void Initialize() {
        _loadSpriteAtlasHandle = Addressables.LoadAssetAsync<SpriteAtlas>("LobbyUiSpritsAtlas");
        _loadSpriteAtlasHandle.Completed += (AsyncOperationHandle<SpriteAtlas> handle) => {
            _lobbyFunction.PanelUI.SettingButton.gameObject.GetComponent<Image>().sprite = handle.Result.GetSprite("LeftTriangle");
            _lobbyFunction.LobbyUI.ExitButton.gameObject.GetComponent<Image>().sprite = handle.Result.GetSprite("TurnOff");
        };
        _lobbyFunction.LobbyUI.ExitButton.onClick.AddListener(() => OnExitClick());
        _lobbyFunction.PanelUI.SettingButton.onClick.AddListener(() => OnSettingButtonClick());
        _lobbyFunction.PanelUI.UserInfoButton.onClick.AddListener(() => OnUserInfoClick());
        _lobbyFunction.PanelUI.SelfInfoButton.onClick.AddListener(() => OnSelfInfoClick());
    }
    public override void Release() {
        Addressables.ReleaseInstance(_loadSpriteAtlasHandle);
    }
    private void OnSettingButtonClick() {
        SettingButtonClick().GetAwaiter();
    }
    private async Task SettingButtonClick() {
        if(_isSettingClick) {
            _isSettingClick = false;
            SetClickAllFalse();
            SetUiClose();
            _lobbyFunction.PanelUI.SettingPanel.GetComponent<Animation>().Play("HideSettingPanel");
            while(_lobbyFunction.PanelUI.SettingPanel.GetComponent<Animation>().isPlaying)
                await Task.Yield();
            _lobbyFunction.PanelUI.SettingButton.gameObject.GetComponent<Image>().sprite = _loadSpriteAtlasHandle.Result.GetSprite("LeftTriangle");
        }
        else {
            _isSettingClick = true;
            _lobbyFunction.PanelUI.SettingPanel.GetComponent<Animation>().Play("ShowSettingPanel");
            while(_lobbyFunction.PanelUI.SettingPanel.GetComponent<Animation>().isPlaying)
                await Task.Yield();
            _lobbyFunction.PanelUI.SettingButton.gameObject.GetComponent<Image>().sprite = _loadSpriteAtlasHandle.Result.GetSprite("RightTriangle");
        }
    }
    public void OnSettingButtonClose() {
        SettingButtonClose().GetAwaiter();
    }
    private async Task SettingButtonClose() {
        _lobbyFunction.PanelUI.SettingButton.interactable = false;
        if(_isSettingClick) {
            _isSettingClick = false;
            SetClickAllFalse();
            SetUiClose();
            _lobbyFunction.PanelUI.SettingPanel.GetComponent<Animation>().Play("HideSettingPanel");
            while(_lobbyFunction.PanelUI.SettingPanel.GetComponent<Animation>().isPlaying)
                await Task.Yield();
            _lobbyFunction.PanelUI.SettingButton.gameObject.GetComponent<Image>().sprite = _loadSpriteAtlasHandle.Result.GetSprite("LeftTriangle");
        }
    }
    private void OnExitClick() {
        Application.Quit();
    }
    private void OnUserInfoClick() {
        if(_isUserInfoClick) {
            _isUserInfoClick = false;
            SetUiClose();
        }
        else {
            SetClickAllFalse();
            _isUserInfoClick = true;
            _lobbyFunction.UserInfoUI.ShowAccountText.text = DataCenter.Instance.UserInfoMemento.UserInfoData.Account;
            SetUiClose();
            _lobbyFunction.UserInfoUI.ShowUI();
        }
    }
    private void OnSelfInfoClick() {
        if(_isSelfInfoClick) {
            _isSelfInfoClick = false;
            SetUiClose();
            Debug.Log("OnSelfInfoClose");
        }
        else {
            _isSelfInfoClick = true;
            SetClickAllFalse();
            SetUiClose();
            Debug.Log("SelfInfoOpen");
        }
    }
    private void SetUiClose() {
        _lobbyFunction.UserInfoUI.HideUI();
    }
    private void SetClickAllFalse() {
        _isUserInfoClick = false;
        _isSelfInfoClick = false;
    }
}
