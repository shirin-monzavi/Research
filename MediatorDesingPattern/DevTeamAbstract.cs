namespace MediatorDesingPattern
{
    public abstract class DevTeamAbstract
    {
        protected MediatorManager Manager;
        protected string Name;

        public DevTeamAbstract(MediatorManager manager)
        {
            Manager = manager;
        }

        public void RecieveRequirementFromMediator(ClientAbstract client)
        {
            Console.WriteLine("Dev has Received requirements from " + client.ClientName);
        }

        public void SendQueryToMediator()
        {
            Manager.ReceieveQueryFromTeam();
        }
    }
}