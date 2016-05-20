using BotFactory.Interface;
using System;

namespace BotFactory.Factories
{
    public class FactoryProgressEventArgs : EventArgs, IFactoryProgressEventArgs
    {
        public IFactoryQueueElement QueueElement { get; set; }
        
        public ITestingUnit TestingUnit { get;  set; }
        
    }
}
