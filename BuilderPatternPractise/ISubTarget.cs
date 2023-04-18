namespace BuilderPatternPractise
{
    public interface ISubTarget:ITarget,ISubTargetOptions
    {
        void Update(ISubTargetOptions options);
    }
}