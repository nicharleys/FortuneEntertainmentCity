using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.U2D;
using UnityEngine.UI;

public class LobbySystem : ISystem {
    private LobbyFunction _lobbyFunction = null;

    private bool _isDownloadGame = false;
    private string _nowPreloadGame = "";
    private GameLoadedInfo _gameLoadedInfo;
    private Dictionary<string, AsyncOperationHandle>  _preLoadHandles = new Dictionary<string, AsyncOperationHandle>();
    private UnityAction _switchGameAction = null;

    private AsyncOperationHandle<SpriteAtlas> _loadSpriteAtlasHandle;
    private delegate void GameStateSwitch();
    public LobbySystem(ISystemFunction theFunction) : base(theFunction) {
        Initialize();
    }
    public override void SetSystemFunction(ISystemFunction theFunction) {
        _lobbyFunction = theFunction as LobbyFunction;
        DataCenter.Instance.NetworkFailedHandler += OnNetworkFailed;
    }
    public override void Initialize() {
        if(!DataRequest.CheckFile("GameLoadInfo")) {
            GameLoadedInfo gameLoadInfo = new GameLoadedInfo();
            DataRequest.LocalSave(gameLoadInfo, "GameLoadInfo");
        }
        _loadSpriteAtlasHandle = Addressables.LoadAssetAsync<SpriteAtlas>("LobbyButtonSpritsAtlas");
        _loadSpriteAtlasHandle.Completed += (AsyncOperationHandle<SpriteAtlas> handle) => {
            _lobbyFunction.LobbyUI.SlotMachineButton.gameObject.GetComponent<Image>().sprite = handle.Result.GetSprite("SlotMachine");
            _lobbyFunction.LobbyUI.ExampleButton.gameObject.GetComponent<Image>().sprite = handle.Result.GetSprite("Home");
        };
        //Game Set
        _lobbyFunction.LobbyUI.SlotMachineButton.onClick.AddListener(() => OnGameClick("SlotMachine", "老虎機", _lobbyFunction.SetStateSlotMachine));
        _lobbyFunction.LobbyUI.ExampleButton.onClick.AddListener(() => OnGameClick("Example", "範例", _lobbyFunction.SetStateExample));

    }
    public override void Release() {
        Addressables.ReleaseInstance(_loadSpriteAtlasHandle);
    }
    public override void Update() {
        CheckLoadProgress();
    }
    #region Commonly
    private void OnGameClick(string loadGameName, string showGameName, GameStateSwitch gameStateSwitch) {
        Task getSizeTask = CheckGameSize(loadGameName);
        getSizeTask.GetAwaiter().OnCompleted(() => {
            ShowDownloadGameUI(showGameName, loadGameName, () => {
                foreach(KeyValuePair<string, AsyncOperationHandle> preLoadHandle in _preLoadHandles) {
                    Addressables.Release(preLoadHandle.Value);
                }
                _preLoadHandles.Clear();
                gameStateSwitch();
            });
        });
    }
    private void ShowDownloadGameUI(string showGameName, string loadGameLable, UnityAction switchGameAction) {
        _lobbyFunction.SettingButtonClose();
        _switchGameAction = switchGameAction;
        _gameLoadedInfo = DataRequest.LocalLoad<GameLoadedInfo>("GameLoadInfo");
        if(!_gameLoadedInfo.LoadedGames.Contains(loadGameLable)) {
            _lobbyFunction.DownloadGameUI.LoadButton.transform.GetComponentInChildren<Text>().text = "下載";
            _lobbyFunction.DownloadGameUI.UnloadButton.gameObject.SetActive(false);

            _lobbyFunction.DownloadGameUI.LoadButton.onClick.RemoveAllListeners();
            _lobbyFunction.DownloadGameUI.LoadButton.onClick.AddListener(() => OnLoadClick(loadGameLable));
        }
        else if(_gameLoadedInfo.LoadedGames.Contains(loadGameLable) && _lobbyFunction.DownloadGameUI.GameSizeText.text != "0B") {
            _lobbyFunction.DownloadGameUI.LoadButton.transform.GetComponentInChildren<Text>().text = "更新";

            _lobbyFunction.DownloadGameUI.UnloadButton.onClick.RemoveAllListeners();
            _lobbyFunction.DownloadGameUI.UnloadButton.onClick.AddListener(() => OnUnloadClick(loadGameLable));
            _lobbyFunction.DownloadGameUI.UnloadButton.gameObject.SetActive(true);

            _lobbyFunction.DownloadGameUI.LoadButton.onClick.RemoveAllListeners();
            _lobbyFunction.DownloadGameUI.LoadButton.onClick.AddListener(() => OnLoadClick(loadGameLable));
        }
        else if(_gameLoadedInfo.LoadedGames.Contains(loadGameLable) && _lobbyFunction.DownloadGameUI.GameSizeText.text == "0B") {
            _lobbyFunction.DownloadGameUI.LoadButton.transform.GetComponentInChildren<Text>().text = "啟動";

            _lobbyFunction.DownloadGameUI.UnloadButton.onClick.RemoveAllListeners();
            _lobbyFunction.DownloadGameUI.UnloadButton.onClick.AddListener(() => OnUnloadClick(loadGameLable));
            _lobbyFunction.DownloadGameUI.UnloadButton.gameObject.SetActive(true);

            _lobbyFunction.DownloadGameUI.LoadButton.onClick.RemoveAllListeners();
            _lobbyFunction.DownloadGameUI.LoadButton.onClick.AddListener(_switchGameAction);
        }
        _lobbyFunction.DownloadGameUI.GameNameText.text = showGameName;
        _lobbyFunction.DownloadGameUI.BackButton.onClick.AddListener(() => OnHideDownloadGameUIClick());
        _lobbyFunction.DownloadGameUI.ShowUI();
    }
    private void OnUnloadClick(string lable) {
        _lobbyFunction.DownloadGameUI.LoadButton.interactable = false;
        _lobbyFunction.DownloadGameUI.BackButton.interactable = false;
        if(_preLoadHandles.ContainsKey(lable)) {
            Addressables.Release(_preLoadHandles[lable]);
            _preLoadHandles.Remove(lable);
        }
        Addressables.ClearDependencyCacheAsync(lable);
        _gameLoadedInfo.LoadedGames.Remove(lable);
        DataRequest.LocalSave(_gameLoadedInfo, "GameLoadInfo");
        _lobbyFunction.DownloadGameUI.LoadButton.transform.GetComponentInChildren<Text>().text = "下載";
        _lobbyFunction.DownloadGameUI.LoadingSlider.value = 0;
        _lobbyFunction.DownloadGameUI.LoadingPercentText.text = "0%";
        _lobbyFunction.DownloadGameUI.UnloadButton.gameObject.SetActive(false);

        Task getSizeTask = CheckGameSize(lable);
        getSizeTask.GetAwaiter().OnCompleted(() => {
            _lobbyFunction.DownloadGameUI.LoadButton.onClick.RemoveAllListeners();
            _lobbyFunction.DownloadGameUI.LoadButton.onClick.AddListener(() => OnLoadClick(lable));
            _lobbyFunction.DownloadGameUI.LoadButton.interactable = true;
            _lobbyFunction.DownloadGameUI.BackButton.interactable = true;
        });
    }
    private void OnLoadClick(string lable) {
        _lobbyFunction.DownloadGameUI.UnloadButton.interactable = false;
        _lobbyFunction.DownloadGameUI.BackButton.interactable = false;
        Task preloadTask = PreloadScenes(lable);
        preloadTask.GetAwaiter().OnCompleted(()=> {
            _lobbyFunction.DownloadGameUI.UnloadButton.interactable = true;
            _lobbyFunction.DownloadGameUI.BackButton.interactable = true;
        });
    }
    private void OnHideDownloadGameUIClick() {
        _lobbyFunction.DownloadGameUI.LoadingSlider.value = 0;
        _lobbyFunction.DownloadGameUI.LoadingPercentText.text = "0%";
        _lobbyFunction.DownloadGameUI.HideUI();
        _lobbyFunction.PanelUI.SettingButton.interactable = true;
    }
    private async Task CheckGameSize(string lable) {
        Task networkTestTask = DataCenter.Instance.NetworkTest();
        while(!networkTestTask.IsCompleted)
            await Task.Yield();

        AsyncOperationHandle<long> getSizeHandle = Addressables.GetDownloadSizeAsync(lable);
        while(!getSizeHandle.IsDone)
            await Task.Yield();
        _lobbyFunction.DownloadGameUI.GameSizeText.text = MathCount.GetDataSize(getSizeHandle.Result);
    }
    private void CheckLoadProgress() {
        if(!_isDownloadGame || !_preLoadHandles.ContainsKey(_nowPreloadGame))
            return;
        if(!_preLoadHandles[_nowPreloadGame].IsDone) {
            _lobbyFunction.DownloadGameUI.LoadingSlider.value = _preLoadHandles[_nowPreloadGame].GetDownloadStatus().Percent;
            _lobbyFunction.DownloadGameUI.LoadingPercentText.text = Math.Round(_lobbyFunction.DownloadGameUI.LoadingSlider.value * 100, 2).ToString() + "%";
        }
    }
    private async Task PreloadScenes(string lable) {
        Task networkTestTask = DataCenter.Instance.NetworkTest();
        while(!networkTestTask.IsCompleted)
            await Task.Yield();

        _isDownloadGame = true;
        _nowPreloadGame = lable;

        _preLoadHandles.Add(lable, Addressables.DownloadDependenciesAsync(lable, false));

        while(!_preLoadHandles[lable].IsDone)
            await Task.Yield();

        if(!_gameLoadedInfo.LoadedGames.Contains(lable)) {
            _gameLoadedInfo.LoadedGames.Add(lable);
            DataRequest.LocalSave(_gameLoadedInfo, "GameLoadInfo");
        }
        _nowPreloadGame = "";
        _isDownloadGame = false;

        Task getSizeTask = CheckGameSize(lable);
        while(!getSizeTask.IsCompleted)
            await Task.Yield();

        if(_gameLoadedInfo.LoadedGames.Contains(lable) && _lobbyFunction.DownloadGameUI.GameSizeText.text == "0B") {
            _lobbyFunction.DownloadGameUI.LoadButton.transform.GetComponentInChildren<Text>().text = "啟動";
            _lobbyFunction.DownloadGameUI.UnloadButton.onClick.RemoveAllListeners();
            _lobbyFunction.DownloadGameUI.UnloadButton.onClick.AddListener(() => OnUnloadClick(lable));
            _lobbyFunction.DownloadGameUI.UnloadButton.gameObject.SetActive(true);

            _lobbyFunction.DownloadGameUI.LoadButton.onClick.RemoveAllListeners();
            _lobbyFunction.DownloadGameUI.LoadButton.onClick.AddListener(_switchGameAction);
        }
        else {
            _lobbyFunction.DownloadGameUI.LoadButton.transform.GetComponentInChildren<Text>().text = "更新";
            _lobbyFunction.DownloadGameUI.UnloadButton.onClick.RemoveAllListeners();
            _lobbyFunction.DownloadGameUI.UnloadButton.onClick.AddListener(() => OnUnloadClick(lable));
            _lobbyFunction.DownloadGameUI.UnloadButton.gameObject.SetActive(true);
        }
    }
    #endregion
    private void OnNetworkFailed() {
        if(_isDownloadGame && string.IsNullOrEmpty(_nowPreloadGame))
            PreloadScenes(_nowPreloadGame).GetAwaiter();
    }
    [SerializeField]
    public struct GameLoadedInfo {
        public List<string> LoadedGames;
    }
}
