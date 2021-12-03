public class ExampleSystem : ISystem {
    private ExampleFunction _exampleFunction = null;
    public ExampleSystem(ISystemFunction theFunction) : base(theFunction) {
        Initialize();
    }
    public override void SetSystemFunction(ISystemFunction theFunction) {
        _exampleFunction = theFunction as ExampleFunction;
    }
    public override void Initialize() {
        _exampleFunction.ExampleUI.BackLobbyButton.onClick.AddListener(() => OnBackLobbyClick());

    }
    private void OnBackLobbyClick() {
        _exampleFunction.SetStateLobby();
    }

}
