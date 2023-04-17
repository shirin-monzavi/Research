namespace BuilderPatternPractise
{
    public class SubTargetManager : SubTargetManager<SubTargetManager, SubTarget>, ISubTargetOptions
    {
        public SubTargetManager(SubTarget target = null) : base(target)
        {
        }
    }

    public abstract class SubTargetManager<TSelf, TTarget> : TargetManager<TSelf, TTarget>, ISubTargetOptions
        where TSelf : SubTargetManager<TSelf, TTarget>
        where TTarget : SubTarget
    {
        public SubTargetManager(TTarget? target=null):base(target)
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
