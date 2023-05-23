using BuilderPatternPractise.Options;

namespace BuilderPatternPractise.Targets
{
    public interface ITarget : ITargetOptions
    {
        void Update(ITargetOptions options);
    }
}