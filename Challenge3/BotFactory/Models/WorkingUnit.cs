using BotFactory.Common.Tools;
using BotFactory.Interface;
using System.Threading.Tasks;

namespace BotFactory.Models
{
    public abstract class WorkingUnit : BaseUnit, ITestingUnit
    {
        
        #region properties
        public Coordinates ParkingPos { get; set; }
        public Coordinates WorkingPos { get; set; }
        public bool IsWorking { get; set; }
        #endregion

        #region constructors
        public WorkingUnit( string inName, double inSpeed = 1, double inBuildTime = 5 )
            : base( inName, inSpeed, inBuildTime )
        {
        }
        #endregion

        #region Methods
        /// <summary>
        /// Envoie une working unit à sa position de travail
        /// </summary>
        /// <returns>True si l'unit a atteint sa position</returns>
        public virtual async Task<bool> WorkBegins()
        {
            SatusChangedEventArgs lPrepWork = new SatusChangedEventArgs("départ pour la zone de travail");
            OnStatusChanged(lPrepWork);

            await Task.Run( ()=> Move(WorkingPos.X, WorkingPos.Y ) );
            IsWorking = true;

            SatusChangedEventArgs lStartWork = new SatusChangedEventArgs("Arrivé au travail");
            OnStatusChanged(lStartWork);

            return true;
        }

        /// <summary>
        /// Envoie une working unit à sa station de recharge
        /// </summary>
        /// <returns>True si le robot arrive à sa destination</returns>
        public virtual async Task<bool> WorkEnds()
        {
            IsWorking = false;

            SatusChangedEventArgs lPrepEnd = new SatusChangedEventArgs("Départ pour le parking");
            OnStatusChanged(lPrepEnd);
                        
            await Task.Run(() => Move(ParkingPos.X, ParkingPos.Y));
            
            SatusChangedEventArgs lEnd = new SatusChangedEventArgs("Arrivé au parking");
            OnStatusChanged(lEnd);

            return true;
        }
        #endregion

    }
}
