using BuilderPatternPractise.Options;
using BuilderPatternPractise.Targets;

namespace BuilderPatternPractise.Managers
{
    public interface ITargetManager : ITargetManager<ITargetManager, ITarget>
    {
    }

    public interface ITargetManager<TSelf, TITarget> : ITargetOptions
        where TSelf : ITargetManager<TSelf, TITarget>
        where TITarget : ITarget
    {
        TITarget Build();

        void Update(TITarget target);

        TSelf WithProp1(int value);

        TSelf WithProp2(int value);

        TSelf WithProp3(string value);

        TSelf WithProp4(string value);
    }
}