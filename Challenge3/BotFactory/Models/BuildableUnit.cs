namespace BotFactory.Models
{
    public abstract class BuildableUnit
    {
        
        #region Properties
        public double BuildTime { get; set; }
        
        public string Model
        {
            get
            {
                return GetType().Name;
            }
        }
        #endregion

        #region Constructors
        public BuildableUnit( double inBuildTime = 5d)
        {
            BuildTime = inBuildTime ; 
        }
        #endregion

    }

}
