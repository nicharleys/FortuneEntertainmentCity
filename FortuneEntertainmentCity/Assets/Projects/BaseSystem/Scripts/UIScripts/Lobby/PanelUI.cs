using UnityEngine;
using UnityEngine.UI;

public class PanelUI : IUserInterface {
    private LobbyFunction _lobbyFunction = null;
    #region Panel
    public GameObject SettingPanel { get; private set; }
    public GameObject SettingList { get; private set; }
    public Button SettingButton { get; private set; }
    #endregion
    #region PanelButton
    public Button UserInfoButton { get; private set; }
    public Button SelfInfoButton { get; private set; }
    #endregion

    public PanelUI(ISystemFunction theFunction) : base(theFunction) {
        Initialize();
    }
    protected override void SetSystemFunction(ISystemFunction theFunction) {
        _lobbyFunction = theFunction as LobbyFunction;
    }
    public override void Initialize() {
        DynamicRootUI = UITool.FindUIGameObject(CanvasType.Dynamic, "PanelUI");

        SettingPanel = UnityTool.FindChildGameObject(DynamicRootUI, "SettingPanel");
        SettingButton = UITool.GetUIComponent<Button>(SettingPanel, "SettingButton");
        SettingList = UnityTool.FindChildGameObject(SettingPanel, "SettingList");
        GameObject settingListViewport = UnityTool.FindChildGameObject(SettingList, "Viewport");
        GameObject settingListLayoutGroup = UnityTool.FindChildGameObject(settingListViewport, "LayoutGroup");

        #region PanelButton
        UserInfoButton = UITool.GetUIComponent<Button>(settingListLayoutGroup, "UserInfoButton");
        SelfInfoButton = UITool.GetUIComponent<Button>(settingListLayoutGroup, "SelfInfoButton");
        #endregion
    }
}
