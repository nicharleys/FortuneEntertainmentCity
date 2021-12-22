using UnityEngine;

public class LobbyScene : MonoBehaviour {
    private void Awake() {
        LobbyFunction.Instance.Initialize();
    }
    private void Update() {
        LobbyFunction.Instance.Update();
    }
    private void OnDestroy() {
        LobbyFunction.Instance.Release();
        LobbyFunction.Instance.ClearInstance();
        System.GC.Collect();
    }
}
