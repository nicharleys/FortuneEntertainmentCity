using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class StartScene : MonoBehaviour {
    private GameObject _dynamicRootUI;
    private GameObject _StaticRootUI;
    private Text _sceneSizeText = null;
    private Text _loadingPercentText = null;
    private Slider _loadingSlider = null;
    private bool _isDownloadBase = false;

    private AsyncOperationHandle _preLoadHandle;

    private void Awake() {
        DataCenter.Instance.NetworkFailedHandler += PreloadScenes;
        Initialize();
    }
    private void Start() {
        PreloadScenes("Base").GetAwaiter();
    }
    private void Initialize() {
        _dynamicRootUI = UITool.FindUIGameObject(CanvasType.Dynamic, "LoadSceneUI");
        _StaticRootUI = UITool.FindUIGameObject(CanvasType.Static, "LoadSceneUI");

        _sceneSizeText = UITool.GetUIComponent<Text>(_StaticRootUI, "SceneSizeText");
        _loadingPercentText = UITool.GetUIComponent<Text>(_dynamicRootUI, "LoadingPercentText");
        _loadingSlider = UITool.GetUIComponent<Slider>(_dynamicRootUI, "LoadingSlider");

        _loadingSlider.value = 0;
        _loadingPercentText.text = "0%";
    }

    private void Update() {
        CheckLoadProgress();
    }
    private async Task CheckSceneSize(string sceneName) {
        AsyncOperationHandle<long> getSizeHandle = Addressables.GetDownloadSizeAsync(sceneName);
        while(!getSizeHandle.IsDone)
            await Task.Yield();
        _sceneSizeText.text = MathCount.GetDataSize(getSizeHandle.Result);
    }
    private void CheckLoadProgress() {
        if(!_preLoadHandle.IsDone && _isDownloadBase) {
            _loadingSlider.value = _preLoadHandle.GetDownloadStatus().Percent;
            _loadingPercentText.text = Math.Round(_loadingSlider.value * 100, 2).ToString() + "%";
        }
    }
    private async Task PreloadScenes(string lable) {
        Task networkTestTask = DataCenter.Instance.NetworkTest();
        while(!networkTestTask.IsCompleted)
            await Task.Yield();

        _isDownloadBase = true;
        Task checkSizeTask = CheckSceneSize(lable);
        while(!checkSizeTask.IsCompleted)
            await Task.Yield();

        _preLoadHandle = Addressables.DownloadDependenciesAsync(lable, false);
        while(!_preLoadHandle.IsDone)
            await Task.Yield();

        _loadingSlider.value = 1;
        _loadingPercentText.text = "100%";
        _isDownloadBase = false;

        await Task.Delay(1000);
        SceneSwitchController.Instance.SwitchScene("LoginScene").GetAwaiter();
    }
    private void PreloadScenes() {
        if(_isDownloadBase)
            PreloadScenes("Base").GetAwaiter();
    }
    private void OnDestroy() {
        GC.Collect();
    }
}
