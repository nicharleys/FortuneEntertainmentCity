public abstract class ISystem : ISystemObject {
    public ISystem(ISystemFunction theFunction) : base(theFunction) { }
    public override void Initialize() { }
    public override void Release() { }
    public override void Update() { }
    public virtual void FixedUpdate() { }
}
