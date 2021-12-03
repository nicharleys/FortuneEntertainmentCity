using UnityEngine;
public class SceneStateController : MonoBehaviour {
    private SceneStateContext _sceneStateContext = new SceneStateContext();
    private static SceneStateController _instance;
    public static SceneStateController Instance {
        get {
            return _instance;
        }
    }
    public SceneStateController() { }
    private void Awake() {
        if(_instance) {
            Destroy(this);
        }
        else {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        _sceneStateContext.SetState(new StartState(_sceneStateContext), "").GetAwaiter();
    }
    private void Update() {
        _sceneStateContext.StateUpdate();
    }
    private void FixedUpdate() {
        _sceneStateContext.StateFixedUpdate();
    }
}
