using MediatorDesingPattern;

internal class Program
{
    public static void Main(string[] args)
    {
        var mediator = new MediatorManager();
        var dev = new DevTeam(mediator);
        mediator.Team = dev;

        var client = new ClientA(mediator);
        mediator.Client = client;

        client.SendRequirementToMetidator();

        dev.SendQueryToMediator();
    }
}