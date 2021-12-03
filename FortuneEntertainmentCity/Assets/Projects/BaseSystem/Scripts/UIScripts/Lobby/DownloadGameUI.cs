using UnityEngine.UI;

public class DownloadGameUI : IUserInterface {
    private LobbyFunction _lobbyFunction = null;
    public Button BackButton { get; private set; }
    public Button LoadButton { get; private set; }
    public Button UnloadButton { get; private set; }
    public Slider LoadingSlider { get; private set; }
    public Text GameNameText { get; private set; }
    public Text GameSizeText { get; private set; }
    public Text LoadingPercentText { get; private set; }

    public DownloadGameUI(ISystemFunction theFunction) : base(theFunction) {
        Initialize();
        HideUI();
    }
    protected override void SetSystemFunction(ISystemFunction theFunction) {
        _lobbyFunction = theFunction as LobbyFunction;
    }
    public override void Initialize() {
        DynamicRootUI = UITool.FindUIGameObject(CanvasType.Dynamic, "DownloadGameUI");
        StaticRootUI = UITool.FindUIGameObject(CanvasType.Static, "DownloadGameUI");

        LoadingSlider = UITool.GetUIComponent<Slider>(DynamicRootUI, "LoadingSlider");
        LoadingPercentText = UITool.GetUIComponent<Text>(DynamicRootUI, "LoadingPercentText");
        GameNameText = UITool.GetUIComponent<Text>(StaticRootUI, "GameNameText");
        GameSizeText = UITool.GetUIComponent<Text>(StaticRootUI, "GameSizeText");
        BackButton = UITool.GetUIComponent<Button>(StaticRootUI, "BackButton");
        LoadButton = UITool.GetUIComponent<Button>(StaticRootUI, "LoadButton");
        UnloadButton = UITool.GetUIComponent<Button>(StaticRootUI, "UnloadButton");

        UnloadButton.gameObject.SetActive(false);
    }
    public override void Release() {
        LoadingSlider.value = 0;
        GameNameText.text = "";
        GameSizeText.text = "";
        LoadingPercentText.text = "0.0%";
        LoadButton.GetComponentInChildren<Text>().text = "啟動";
    }
    public override void HideUI() {
        Release();
        base.HideUI();
    }
}
