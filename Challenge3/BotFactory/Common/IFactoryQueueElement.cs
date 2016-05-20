using BotFactory.Common.Tools;
using System;

namespace BotFactory.Interface
{
    public interface IFactoryQueueElement
    {
        #region Properties
        string Name { get; }
        Coordinates ParkingPos { get; }
        Coordinates WorkingPos { get; }
        Type Model { get; }
        #endregion
    }
}
