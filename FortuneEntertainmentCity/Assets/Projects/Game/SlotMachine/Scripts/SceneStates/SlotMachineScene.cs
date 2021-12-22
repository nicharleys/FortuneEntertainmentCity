using UnityEngine;

public class SlotMachineScene : MonoBehaviour {
    private void Awake() {
        SlotMachineFunction.Instance.Initialize();
    }
    private void OnDestroy() {
        SlotMachineFunction.Instance.Release();
        SlotMachineFunction.Instance.ClearInstance();
        System.GC.Collect();
    }
}
