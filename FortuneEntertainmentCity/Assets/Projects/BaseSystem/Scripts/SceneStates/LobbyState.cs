using UnityEngine;
using UnityEngine.AddressableAssets;
public class LobbyState : ISceneState {
    public LobbyState(SceneStateContext theContext) : base(theContext) {
        StateName = "LobbyState";
        LobbyFunction.Instance.SetStateContext(theContext);
    }
    public override void StateStart() {
        LobbyFunction.Instance.Initialize();
        HideWaitInitUI();
    }
    public override void StateUpdate() {
        LobbyFunction.Instance.Update();
    }
    public override void StateEnd() {
        LobbyFunction.Instance.Release();
        Addressables.UnloadSceneAsync(StateContext.LastSceneHandle, true);
    }
    public void HideWaitInitUI() {
        GameObject waitInitUI = UITool.FindUIGameObject(CanvasType.Dynamic, "WaitInitUI");
        waitInitUI.SetActive(false);
    }
}
