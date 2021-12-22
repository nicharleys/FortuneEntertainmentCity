using UnityEngine;

public abstract class IUserInterface: ISystemObject {
    protected GameObject DynamicRootUI { 
        get { 
            return _dynamicRootUI; 
        }
        set { 
            _dynamicRootUI = value; 
            _dynamicRootCanvas = _dynamicRootUI.GetComponent<Canvas>();
        } 
    }
    protected GameObject StaticRootUI {
        get {
            return _staticRootUI;
        }
        set {
            _staticRootUI = value;
            _staticRootCanvas = _staticRootUI.GetComponent<Canvas>();
        }
    }
    private GameObject _dynamicRootUI = null;
    private GameObject _staticRootUI = null;
    private Canvas _dynamicRootCanvas = null;
    private Canvas _staticRootCanvas = null;
    private bool _isAction = true;
    public IUserInterface(ISystemFunction theFunction) : base(theFunction) {
    }
    public bool GetActionState() {
        return _isAction;
    }
    public virtual void ShowUI() {
        SetUIAction(true);
    }
    public virtual void HideUI() {
        SetUIAction(false);
    }
    private void SetUIAction(bool enable) {
        if(DynamicRootUI != null)
            _dynamicRootCanvas.enabled = enable;
        if(StaticRootUI != null)
            _staticRootCanvas.enabled = enable;
        _isAction = enable;
    }
    public override void Initialize() { }
    public override void Release() { }
    public override void Update() { }

}
