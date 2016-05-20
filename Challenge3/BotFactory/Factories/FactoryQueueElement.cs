using BotFactory.Common.Tools;
using BotFactory.Models;
using BotFactory.Interface;
using BotFactory.Factories;
using System;

namespace BotFactory.Factories
{
    public class FactoryQueueElement : IFactoryQueueElement
    {
        #region Properties
        public string Name { get; }
        public Coordinates ParkingPos { get; }
        public Coordinates WorkingPos { get; }
        public Type Model { get; }
        #endregion

        #region Constructor
        public FactoryQueueElement(string inName, Type inModel, Coordinates inParkingPos, Coordinates inWorkingPos )
        {
            Name = inName;
            Model = inModel;
            ParkingPos = inParkingPos;
            WorkingPos = inWorkingPos;
        }
        #endregion


    }
}
