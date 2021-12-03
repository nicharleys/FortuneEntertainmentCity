public abstract class ISystem {
    public ISystem(ISystemFunction theFunction) {
        SetSystemFunction(theFunction);
    }
    public abstract void SetSystemFunction(ISystemFunction theFunction);
    public virtual void Initialize() { }
    public virtual void Release() { }
    public virtual void Update() { }
    public virtual void FixedUpdate() { }
}
