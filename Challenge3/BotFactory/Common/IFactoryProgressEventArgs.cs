namespace BotFactory.Interface
{
    public interface IFactoryProgressEventArgs
    {
        IFactoryQueueElement QueueElement { get; set; }
        ITestingUnit TestingUnit { get;set;}

    }
}
