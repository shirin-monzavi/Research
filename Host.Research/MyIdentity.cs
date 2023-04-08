namespace HostSample
{
    public class MyIdentity
    {
        public Dictionary<string, List<string>> MyRole { get; private set; }

        public MyIdentity()
        {
            MyRole = new Dictionary<string, List<string>>();

            MyRole.Add("MyClassSecurity.DoWithSecurity", new List<string>
            {
                new string("Access1"),
            });
        }
    }
}
