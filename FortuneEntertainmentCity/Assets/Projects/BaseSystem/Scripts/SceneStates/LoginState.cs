using UnityEngine;
using UnityEngine.AddressableAssets;

public class LoginState : ISceneState {
    public LoginState(SceneStateContext theContext) : base(theContext) {
        StateName = "LoginState";
        LoginFunction.Instance.SetStateContext(theContext);
    }
    public override void StateStart() {
        LoginFunction.Instance.Initialize();
        HideWaitInitUI();
        LoginFunction.Instance.AutoLogin();
    }
    public override void StateEnd() {
        LoginFunction.Instance.Release();
        Addressables.UnloadSceneAsync(StateContext.LastSceneHandle, true);
    }
    public void HideWaitInitUI() {
        GameObject waitInitUI = UITool.FindUIGameObject(CanvasType.Dynamic, "WaitInitUI");
        waitInitUI.SetActive(false);
    }
}
