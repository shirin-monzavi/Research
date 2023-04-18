namespace BuilderPatternPractise
{
    public interface ITarget : ITargetOptions
    {
        void Update(ITargetOptions options);
    }
}