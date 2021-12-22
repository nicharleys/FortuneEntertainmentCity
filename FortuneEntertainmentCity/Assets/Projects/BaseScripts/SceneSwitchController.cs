using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public static class SceneSwitchController {
    private static Dictionary<string, AsyncOperationHandle<SceneInstance>> _addSceneHandles = new Dictionary<string, AsyncOperationHandle<SceneInstance>>();
    public static async Task SwitchScene(string theSceneName) {
        Task networkTestTask = DataCenter.Instance.NetworkTest();
        while(!networkTestTask.IsCompleted)
            await Task.Yield();
        AsyncOperationHandle<SceneInstance> loadSceneHandle = Addressables.LoadSceneAsync(theSceneName, LoadSceneMode.Single);
        while(!loadSceneHandle.IsDone)
            await Task.Yield();
    }
    public static async Task AddScene(string theSceneName) {
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
    public static async Task UnloadScene(string theSceneName) {
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
    public static async Task UnloadAllScene() {
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
