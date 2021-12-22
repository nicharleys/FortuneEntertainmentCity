public abstract class ISystemObject {
    public ISystemObject(ISystemFunction theFunction) { }
    public virtual void Initialize() { }
    public virtual void Release() { }
    public virtual void Update() { }
}
