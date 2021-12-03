public class ISceneState {
    private string _stateName = "SceneState";
    public string StateName {
        get {
            return _stateName;
        }
        set {
            _stateName = value;
        }
    }
    protected SceneStateContext StateContext;
    public ISceneState(SceneStateContext theContext) {
        StateContext = theContext;
    }
    public virtual void StateStart() { }
    public virtual void StateUpdate() { }
    public virtual void StateFixedUpdate() { }
    public virtual void StateEnd() { }
    public override string ToString() {
        return string.Format("[ISceneState: StateName={0}]", StateName);
    }
}
