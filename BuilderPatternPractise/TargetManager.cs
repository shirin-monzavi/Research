using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BuilderPatternPractise
{
    public class TargetManager : TargetManager<ITargetManager, ITarget, Target>, ITargetManager
    {
        public TargetManager(ITarget? target = null) : base(target)
        {
        }
    }
    public abstract class TargetManager<TSelf, TITarget, TTarget> : ITargetManager<TSelf, TITarget>
        where TSelf : ITargetManager<TSelf, TITarget>
        where TITarget : class, ITarget
        where TTarget : TITarget
    {
        private static ConcurrentDictionary<Type, MethodInfo> dic = new();
        public TargetManager(TITarget? target = null)
        {
            if (target == null) return;

            WithProp1(target.Prop1);
            WithProp2(target.Prop2);
            WithProp3(target.Prop3);
            WithProp4(target.Prop4);
        }

        private int prop1;

        private int prop2;

        private string prop3;

        private string prop4;

        public int Prop1 => prop1;

        public int Prop2 => prop2;

        public string Prop3 => prop3;

        public string Prop4 => prop4;

        public TSelf WithProp1(int value)
        {
            prop1 = value;
            return this;
        }

        public TSelf WithProp2(int value)
        {
            prop2 = value;
            return this;
        }


        public TSelf WithProp3(string value)
        {
            prop3 = value;
            return this;
        }


        public TSelf WithProp4(string value)
        {
            prop4 = value;
            return this;
        }

        public TITarget Build()
        {
            return (TITarget)Activator.CreateInstance(typeof(TTarget), this)!;
        }

        public void Update(TITarget target)
        {
            var methodInfo = dic.GetOrAdd(typeof(TITarget), getMethodInfo());

            methodInfo.Invoke(target, new object[] { this });
        }

        private static MethodInfo getMethodInfo()
        {
            var types = getInheritanceHierarchy(typeof(TITarget));

            var findUpdateMethod = typeof(TITarget)
                .GetMethods(BindingFlags.Public | BindingFlags.Instance).
                   Where(x => x.Name == "Update");

            var methodInfo = types.Join(
                            findUpdateMethod, t => t.Name,
                            mi => mi.DeclaringType.Name,
                            (t, mi) => mi)
                            .First();
            return methodInfo;
        }

        private static IEnumerable<Type> getInheritanceHierarchy(Type type)
        {
            for (var current = type; current != null; current = current.BaseType)
            {
                yield return current;
            }
        }

        public static implicit operator TSelf(TargetManager<TSelf, TITarget, TTarget> manager)
        {
            return (TSelf)(ITargetManager<TSelf, TITarget>)manager;
        }
    }
}
