using BotFactory.Common.Tools;
using System.Collections.Generic;
using System;

namespace BotFactory.Interface
{
    public interface IUnitFactory
    {
        #region Properties
        int QueueCapacity{ get; }
        int StorageCapacity { get; }
        TimeSpan QueueTime { get; }
        List<IFactoryQueueElement> Queue { get; }
        List<ITestingUnit> Storage { get; }
        
        int QueueFreeSlots { get; }
        int StorageFreeSlots { get; }

        event EventHandler<IFactoryProgressEventArgs> FactoryProgress;
        #endregion

        #region Methods
        bool AddWorkableUnitToQueue(Type inModel, string inUnitName, Coordinates inWorkingPos, Coordinates inParkPos);
        void OnStatusChanged(IFactoryProgressEventArgs inE);
        #endregion
    }
}
