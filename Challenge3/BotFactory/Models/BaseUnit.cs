using BotFactory.Common.Tools;
using System.Threading;
using System.Threading.Tasks;

namespace BotFactory.Models
{
    public class BaseUnit : ReportingUnit
    {
        #region Attributes
        string m_Name;
        double M_Speed;
        #endregion

        #region Properties
        public string Name
        {
            get
            {
                return m_Name; 
            }
        }
        public Coordinates CurrentPos { get; }
        
        #endregion
        
        #region Constructors
        public BaseUnit(string inName, double inSpeed = 1d, double inBuildTime = 5d)
        {
            BuildTime = inBuildTime;
            m_Name = inName;
            M_Speed = inSpeed;
            CurrentPos = new Coordinates( 0, 0 ); 
        }
        #endregion

        #region Methods
        /// <summary>
        /// Simule le mouvement d'un BaseUnit
        /// </summary>
        /// <param name="inX">Abcisse de destination</param>
        /// <param name="inY">Ordonnée de destination</param>
        public  void Move(double inX, double inY)
        {
            double lLenght;
            Vector lVector;
                        
            lVector = Vector.FromCoordinate( CurrentPos, new Coordinates( inX, inY ) );
            lLenght = lVector.Lenght();
            int time = (int) (lLenght * M_Speed);

            Thread.Sleep( time * 500 );
            CurrentPos.X = inX;
            CurrentPos.Y = inY;


            //SatusChangedEventArgs lMove = new SatusChangedEventArgs("Voyage effectué");
            //OnStatusChanged( lMove );
        }
        #endregion


    }
}
