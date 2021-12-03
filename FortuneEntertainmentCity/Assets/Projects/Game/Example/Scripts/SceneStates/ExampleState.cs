using UnityEngine;
using UnityEngine.AddressableAssets;
public class ExampleState : ISceneState {
    public ExampleState(SceneStateContext theContext) : base(theContext) {
        StateName = "ExampleState";
        ExampleFunction.Instance.SetStateContext(theContext);
    }
    public override void StateStart() {
        HideWaitInitUI();
        ExampleFunction.Instance.Initialize();
    }
    public override void StateEnd() {
        ExampleFunction.Instance.Release();
        Addressables.UnloadSceneAsync(StateContext.LastSceneHandle, true);
    }
    public void HideWaitInitUI() {
        GameObject waitInitUI = UITool.FindUIGameObject(CanvasType.Dynamic, "WaitInitUI");
        waitInitUI.SetActive(false);
    }
}
