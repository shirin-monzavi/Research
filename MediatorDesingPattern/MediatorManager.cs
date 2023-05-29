namespace MediatorDesingPattern
{
    public class MediatorManager
    {
        public ClientAbstract Client { get; set; }

        public DevTeamAbstract Team { get; set; }

        public void ReceieveRequirementsFromClient()
        {
            Team.RecieveRequirementFromMediator(Client);
        }

        public void ReceieveQueryFromTeam()
        {
            Client.ReceiveQueryFromMediator(Team);
        }
    }
}