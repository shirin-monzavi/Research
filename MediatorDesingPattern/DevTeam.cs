namespace MediatorDesingPattern
{
    public class DevTeam : DevTeamAbstract
    {
        public DevTeam(MediatorManager manager) : base(manager)
        {
            Name = "DevTeam A";
        }
    }
}