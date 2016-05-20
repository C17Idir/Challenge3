namespace BotFactory.Common.Tools
{
    public class Coordinates
    {
        #region Attributes
        #endregion

        #region Properties
        public double X { get; set; }
        public double Y { get; set; }
        #endregion

        #region Constructors
        public Coordinates( double inX = 0, double inY = 0)
        {
            X = inX;
            Y = inY; 
        }
        #endregion

        #region Methods
        public override bool Equals( object inCoordinate )
        {
            // Tente de caster le parametre en Coordinate
            Coordinates temp = inCoordinate as Coordinates;
             // Si temp est null, c'est que incoordinates n'est pas une coordonnée
            return ( (temp != null) && ( X == temp.X) && ( Y == temp.Y) );
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion
    }
}
