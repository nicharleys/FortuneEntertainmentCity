using System;
using UnityEngine;
using UnityEngine.UI;

public class LobbyUI : IUserInterface {
    public GameObject GameList { get; private set; }
    public Button ExitButton { get; private set; }
    #region GameButton
    public Button SlotMachineButton { get; private set; }
    public Button ExampleButton { get; private set; }
    #endregion

    public LobbyUI(LobbyFunction theFunction) : base(theFunction) {
        Initialize();
    }
    public override void Initialize() {
        DynamicRootUI = UITool.FindUIGameObject(CanvasType.Dynamic, "LobbyUI");
        StaticRootUI = UITool.FindUIGameObject(CanvasType.Static, "LobbyUI");

        ExitButton = UITool.GetUIComponent<Button>(StaticRootUI, "ExitButton");

        GameList = UnityTool.FindChildGameObject(DynamicRootUI, "GameList");
        GameObject gameListViewport = UnityTool.FindChildGameObject(GameList, "Viewport");
        GameObject gameListLayoutGroup = UnityTool.FindChildGameObject(gameListViewport, "LayoutGroup");

        #region GameButton Row1
        GameObject row1 = UnityTool.FindChildGameObject(gameListLayoutGroup, "Row1");
        SlotMachineButton = UITool.GetUIComponent<Button>(row1, "SlotMachineButton");
        ExampleButton = UITool.GetUIComponent<Button>(row1, "ExampleButton");
        #endregion
    }
}
