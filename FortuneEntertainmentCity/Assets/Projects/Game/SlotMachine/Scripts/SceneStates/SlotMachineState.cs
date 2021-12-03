using UnityEngine;
using UnityEngine.AddressableAssets;
public class SlotMachineState : ISceneState {
    public SlotMachineState(SceneStateContext theContext) : base(theContext) {
        StateName = "SlotMachineState";
        SlotMachineFunction.Instance.SetStateContext(theContext);
    }
    public override void StateStart() {
        HideWaitInitUI();
        SlotMachineFunction.Instance.Initialize();
    }
    public override void StateEnd() {
        SlotMachineFunction.Instance.Release();
        Addressables.UnloadSceneAsync(StateContext.LastSceneHandle, true);
    }
    public void HideWaitInitUI() {
        GameObject waitInitUI = UITool.FindUIGameObject(CanvasType.Dynamic, "WaitInitUI");
        waitInitUI.SetActive(false);
    }
}
