using BotFactory.Interface;
using System;

namespace BotFactory.Models
{
    public abstract class ReportingUnit  : BuildableUnit, IReportingUnit
    {
        #region Methods
        public virtual void OnStatusChanged(IStatusChangedEventArgs inE )
        {
            if( UnitStatusChanged != null )
            {
                UnitStatusChanged( this, inE ); 
            }
        }
        #endregion

        #region Events
        public event EventHandler<IStatusChangedEventArgs> UnitStatusChanged;
        #endregion


    }
}
