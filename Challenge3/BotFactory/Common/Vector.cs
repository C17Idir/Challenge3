using System;

namespace BotFactory.Common.Tools
{
    public class Vector
    {
        #region Attributes
        #endregion

        #region Properties
        public double X { get; set; }
        public double Y { get; set; }
        #endregion

        #region Constructors
        public Vector(double inX = 0, double inY = 0)
        {
            X = inX;
            Y = inY; 
        }

        #endregion

        #region Methods
        // Calcul du vecteur entre deux points
        public static Vector FromCoordinate (Coordinates inBegin, Coordinates inEnd)
        {
            return new Vector(inEnd.X - inBegin.X, inEnd.Y - inBegin.Y);
        }

        //Calcule la longueur d'un vecteur
        public double Lenght()
        {
            return Math.Sqrt( Math.Pow( X, 2 ) + Math.Pow( Y, 2 ) ); 
        }

        public override bool Equals( object inVector )
        {
            Vector temp = inVector as Vector;
            return ( ( temp != null ) && ( temp.X == X ) && ( temp.Y == Y ) );
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
