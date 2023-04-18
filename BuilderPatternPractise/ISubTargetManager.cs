﻿namespace BuilderPatternPractise
{
    public interface ISubTargetManager : ISubTargetManager<ISubTargetManager, ISubTarget>
    {
    }

    public interface ISubTargetManager<TSelf, TTarget> : ITargetManager<TSelf, TTarget>, ISubTargetOptions
        where TSelf : ISubTargetManager<TSelf, TTarget>
        where TTarget : ISubTarget
    {
        TSelf WithProp5(string value);
    }
}