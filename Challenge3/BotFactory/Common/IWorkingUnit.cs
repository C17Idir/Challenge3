using BotFactory.Common.Tools;
using System.Threading.Tasks;

namespace BotFactory.Interface
{
    public interface IWorkingUnit
    {
        #region Properties
        Coordinates ParkingPos { get; set; }
        Coordinates WorkingPos { get; set; }
        bool IsWorking { get; set; }
        #endregion

        #region Methods
        Task<bool> WorkEnds();
        Task<bool> WorkBegins();
        #endregion
    }
}
