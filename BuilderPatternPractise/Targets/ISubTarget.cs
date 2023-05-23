using BuilderPatternPractise.Options;

namespace BuilderPatternPractise.Targets
{
    public interface ISubTarget : ITarget, ISubTargetOptions
    {
        void Update(ISubTargetOptions options);
    }
}