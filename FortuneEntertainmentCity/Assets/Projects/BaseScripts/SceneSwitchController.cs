using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public class SceneSwitchController {
    private Dictionary<string, AsyncOperationHandle<SceneInstance>> _addSceneHandles = new Dictionary<string, AsyncOperationHandle<SceneInstance>>();
    private static SceneSwitchController _instance;
    public static SceneSwitchController Instance {
        get {
            if(_instance == null)
                _instance = new SceneSwitchController();
            return _instance;
        }
    }
    public SceneSwitchController() { }
    public async Task SwitchScene(string theSceneName) {
        Task networkTestTask = DataCenter.Instance.NetworkTest();
        while(!networkTestTask.IsCompleted)
            await Task.Yield();
        AsyncOperationHandle<SceneInstance> loadSceneHandle = Addressables.LoadSceneAsync(theSceneName, LoadSceneMode.Single);
        while(!loadSceneHandle.IsDone)
            await Task.Yield();
    }
    public async Task AddScene(string theSceneName) {
        AsyncOperationHandle<SceneInstance> addSceneHandle;
        if(_addSceneHandles.TryGetValue(theSceneName, out addSceneHandle))
            return;
        Task networkTestTask = DataCenter.Instance.NetworkTest();
        while(!networkTestTask.IsCompleted)
            await Task.Yield();
        _addSceneHandles.Add(theSceneName, Addressables.LoadSceneAsync(theSceneName, LoadSceneMode.Additive));
        while(!_addSceneHandles[theSceneName].IsDone)
            await Task.Yield();
    }
    public async Task UnloadScene(string theSceneName) {
        AsyncOperationHandle<SceneInstance> addSceneHandle;
        if(!_addSceneHandles.TryGetValue(theSceneName, out addSceneHandle))
            return;
        Task networkTestTask = DataCenter.Instance.NetworkTest();
        while(!networkTestTask.IsCompleted)
            await Task.Yield();
        AsyncOperationHandle<SceneInstance> unloadHandle = Addressables.UnloadSceneAsync(addSceneHandle, true);
        while(!unloadHandle.IsDone)
            await Task.Yield();
        _addSceneHandles.Remove(theSceneName);
    }
    public async Task UnloadAllScene() {
        Task networkTestTask = DataCenter.Instance.NetworkTest();
        while(!networkTestTask.IsCompleted)
            await Task.Yield();

        foreach(KeyValuePair<string, AsyncOperationHandle<SceneInstance>> addSceneHandle in _addSceneHandles) {
            AsyncOperationHandle<SceneInstance> unloadHandle = Addressables.UnloadSceneAsync(addSceneHandle.Value, true);
            while(!unloadHandle.IsDone)
                await Task.Yield();
        }
        _addSceneHandles.Clear();
    }
}
