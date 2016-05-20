using System;

namespace BotFactory.Interface
{
    public interface IReportingUnit
    {
        #region Events
        event EventHandler<IStatusChangedEventArgs> UnitStatusChanged;
        void OnStatusChanged(IStatusChangedEventArgs inE);
        #endregion
    }
}
