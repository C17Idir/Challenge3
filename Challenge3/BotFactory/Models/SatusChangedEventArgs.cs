using BotFactory.Interface;
using System;

namespace BotFactory.Models
{
    public class SatusChangedEventArgs : EventArgs, IStatusChangedEventArgs
    {
        #region Properties
        public string NewStatus{ get; set; }
        #endregion

        #region Constructors
        public SatusChangedEventArgs()
        {}

        public SatusChangedEventArgs( string inNewStatus)
        {
            NewStatus = inNewStatus;
        }
        
        #endregion
    }
}
