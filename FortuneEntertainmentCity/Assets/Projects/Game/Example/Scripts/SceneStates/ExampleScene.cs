using UnityEngine;

public class ExampleScene : MonoBehaviour {
    private void Awake() {
        ExampleFunction.Instance.Initialize();
    }
    private void OnDestroy() {
        ExampleFunction.Instance.Release();
        ExampleFunction.Instance.ClearInstance();
        System.GC.Collect();
    }
}
