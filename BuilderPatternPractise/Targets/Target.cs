using BuilderPatternPractise.Options;

namespace BuilderPatternPractise.Targets
{
    public class Target : ITarget
    {
        public int Prop1 => prop1;

        public int Prop2 => prop2;

        public string Prop3 => prop3;

        public string Prop4 => prop4;

        private int prop1;

        private int prop2;

        private string prop3;

        private string prop4;

        public Target(ITargetOptions options)
        {
            setUp(options);
        }

        private void setUp(ITargetOptions options)
        {
            prop1 = options.Prop1;

            prop2 = options.Prop2;

            prop3 = options.Prop3;

            prop4 = options.Prop4;
        }

        public void Update(ITargetOptions options)
        {
            setUp(options);
        }

    }
}
