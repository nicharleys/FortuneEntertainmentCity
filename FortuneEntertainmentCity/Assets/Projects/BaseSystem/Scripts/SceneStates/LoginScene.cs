using UnityEngine;

public class LoginScene : MonoBehaviour {
    private void Awake() {
        LoginFunction.Instance.Initialize();
    }
    private void Start() {
        LoginFunction.Instance.AutoLogin();
    }
    private void OnDestroy() {
        LoginFunction.Instance.Release();
        LoginFunction.Instance.ClearInstance();
        System.GC.Collect();
    }
}
