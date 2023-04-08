namespace HostSample
{
    public interface IMyClassSecurity
    {
        int DoWithSecurity(User user);
        Task<int> DoWithSecurityAsync(User user);
    }
}