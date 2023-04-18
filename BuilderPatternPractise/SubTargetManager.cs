namespace BuilderPatternPractise
{
    public class SubTargetManager : SubTargetManager<ISubTargetManager, ISubTarget,SubTarget>, ISubTargetManager
    {
        public SubTargetManager(ISubTarget target = null) : base(target)
        {
        }

    }

    public abstract class SubTargetManager<TSelf, TITarget,TTarget> :
        TargetManager<TSelf, TITarget, TTarget>,
        ISubTargetManager<TSelf, TITarget>

        where TSelf : ISubTargetManager<TSelf, TITarget>
        where TITarget : class, ISubTarget
        where TTarget : TITarget
    {
        public SubTargetManager(TITarget? target = null) : base(target)
        {
            if (target == null) return;

            WithProp5(target.Prop5);
        }
        private string prop5;
        public string Prop5 => prop5;

        public TSelf WithProp5(string value)
        {
            prop5 = value;
            return this;
        }
    }
}
