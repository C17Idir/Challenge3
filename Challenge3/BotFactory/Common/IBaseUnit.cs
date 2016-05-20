using BotFactory.Common.Tools;

namespace BotFactory.Interface
{
    public interface IBaseUnit
    {
        #region Properties
        Coordinates CurrentPos { get; }
        #endregion

        #region Methods
        void Move( double inX, double inY );
        #endregion
    }
}
