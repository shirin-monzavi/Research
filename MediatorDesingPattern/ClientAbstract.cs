namespace MediatorDesingPattern
{
    public abstract class ClientAbstract
    {
        protected MediatorManager Manager;
        public string ClientName;

        public ClientAbstract(MediatorManager mediatorManager)
        {
            Manager = mediatorManager;
        }

        public void SendRequirementToMetidator()
        {
            Manager.ReceieveRequirementsFromClient();
        }

        public void ReceiveQueryFromMediator(DevTeamAbstract devTeam)
        {
            Console.WriteLine("Query has received from " + devTeam.Name);
        }
    }

    public class ClientA : ClientAbstract
    {
        public ClientA(MediatorManager mediatorManager) : base(mediatorManager)
        {
            this.ClientName = "Client A";
        }
    }
}