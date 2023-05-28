namespace SingletonDesignPatternSample
{
    public class Singletone1
    {
        private static Singletone1 singletone1;
        private static object obj = new object();

        private Singletone1()
        {
        }

        public static Singletone1 CreateInstance()
        {
            if (singletone1 == null)
            {
                lock (obj)
                {
                    if (singletone1 == null)
                    {
                        return new Singletone1();
                    }
                }
            }
            return singletone1;
        }
    }
}