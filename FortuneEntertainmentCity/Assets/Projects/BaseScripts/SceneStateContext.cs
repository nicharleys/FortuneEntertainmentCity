using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
public class SceneStateContext {
    public AsyncOperationHandle<SceneInstance> LoadSceneHandle { get; private set; }
    public AsyncOperationHandle<SceneInstance> LastSceneHandle { get; private set; }
    private ISceneState _sceneState;
    private string _sceneName = "";
    private bool _isAction = false;
    private bool _isLoaded = false;
    public SceneStateContext() { }
    public async Task SetState(ISceneState theState, string theSceneName) {
        _isLoaded = false;
        LastSceneHandle = LoadSceneHandle;
        _sceneName = theSceneName;
        Task loadSceneTask = LoadScene();
        while(!loadSceneTask.IsCompleted)
            await Task.Yield();
        if(_sceneState != null)
            _sceneState.StateEnd();
        _sceneState = theState;
        _isAction = false;
    }
    public void StateUpdate() {
        if(_sceneState == null)
            return;
        if(!_isAction) {
            _isAction = true;
            _sceneState.StateStart();
        }
        else {
            _sceneState.StateUpdate();
        }
    }
    public void StateFixedUpdate() {
        if(_sceneState == null)
            return;
        if(_isAction)
            _sceneState.StateFixedUpdate();
    }
    private async Task LoadScene() {
        Task networkTestTask = DataCenter.Instance.NetworkTest();
        while(!networkTestTask.IsCompleted)
            await Task.Yield();

        if(!_isLoaded && _sceneName != "") {
            LoadSceneHandle = Addressables.LoadSceneAsync(_sceneName, LoadSceneMode.Additive);
            while(!LoadSceneHandle.IsDone)
                await Task.Yield();
            _isLoaded = true;
        }
    }
}
