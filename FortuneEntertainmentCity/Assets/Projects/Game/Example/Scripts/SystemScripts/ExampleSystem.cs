public class ExampleSystem : ISystem {
    private ExampleFunction _exampleFunction = null;
    public ExampleSystem(ExampleFunction theFunction) : base(theFunction) {
        _exampleFunction = theFunction;
        Initialize();
    }
    public override void Initialize() {
        _exampleFunction.ExampleUI.BackLobbyButton.onClick.AddListener(() => OnBackLobbyClick());

    }
    private void OnBackLobbyClick() {
        _exampleFunction.SetStateLobby();
    }

}
