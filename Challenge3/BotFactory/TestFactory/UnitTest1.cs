using BotFactory.Common.Tools;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using BotFactory.Interface;
using BotFactory.Models;

namespace BotFactory.Factories.Tests
{
    [TestClass()]
    public class Factories
    {
        #region UnitFactory
        [TestMethod()]
        public void AddWorkableUnitToQueue()
        {
            
            UnitFactory lFactory = new UnitFactory(3,3);
           
            // Test qu'on peut envoyer des commandes à la volée
            Assert.IsTrue( lFactory.AddWorkableUnitToQueue( typeof(Wall_E), "Machina 1", new Coordinates(), new Coordinates() ), "Assert 1" );
            Assert.IsTrue( lFactory.AddWorkableUnitToQueue( typeof(R2D2), "Machina 2", new Coordinates(), new Coordinates() ), "Assert 2" );
            Assert.IsTrue( lFactory.AddWorkableUnitToQueue( typeof(T_800), "Machina 3", new Coordinates(), new Coordinates() ), "Assert 3" );

            // Test de la réponse quand la queue est pleine
            Assert.IsFalse( lFactory.AddWorkableUnitToQueue(typeof(Wall_E), "Machina 4", new Coordinates(), new Coordinates() ), "Assert 4" );

            //On attend la construction du premier robot pour déposer une nouvelle demande
            Thread.Sleep( 10000 );
            // Si une place se libère, on doit pouvoir créer une nouvelle commmande etc...
            Assert.IsTrue( lFactory.AddWorkableUnitToQueue(typeof(HAL), "Machina 5", new Coordinates(), new Coordinates() ), "Assert 5" );
            Thread.Sleep( 10000 );
            Assert.IsTrue( lFactory.AddWorkableUnitToQueue(typeof(R2D2), "Machina 6", new Coordinates(), new Coordinates() ), "Assert 6" );
            Thread.Sleep( 10000 );
            Assert.IsTrue( lFactory.AddWorkableUnitToQueue(typeof(T_800), "Machina 6", new Coordinates(), new Coordinates() ), "Assert 7" );
            Thread.Sleep( 10000 );
            Assert.IsTrue( lFactory.AddWorkableUnitToQueue(typeof(R2D2), "Machina 6", new Coordinates(), new Coordinates() ), "Assert 8" );

            // On teste que l'on ne puisse plus envoyer de demandes quand les deux files sont pleines
            Thread.Sleep( 10000 );
            Assert.IsFalse( lFactory.AddWorkableUnitToQueue(typeof(T_800), "Machina 6", new Coordinates(), new Coordinates() ), "Assert 9" );
           
            
        }
        #endregion
    }
}

namespace BotFactory.Models.Tests
{
    [TestClass()]
    public class Models
    {
        #region BaseUnit
        [TestMethod()]
        public void Move()
        {
            // Test de la méthode move de BaseUnit
            BaseUnit lUnit = new BaseUnit( "RobotTest" );
            lUnit.Move( 2, 0 );
            Assert.AreEqual( new Coordinates( 2, 0 ), lUnit.CurrentPos );
            lUnit.Move( 0, 4 );
            Assert.AreEqual( new Coordinates( 0, 4 ), lUnit.CurrentPos );
        }
        #endregion
    }
}

namespace BotFactory.Common.Tools.Tests
{
    [TestClass()]
    public class Tools
    {
        #region Coordinate
        [TestMethod()]
        public void EqualsTest()
        {
            // test de la surcharge de Equals dans Coordinates
            Coordinates lCoordinate1 = new Coordinates(1,2),
                        lCoordinate2 = new Coordinates(1,3),
                        lCoordinate3 = new Coordinates(1,2);

            Assert.IsTrue( lCoordinate1.Equals( lCoordinate3 ) );
            Assert.IsTrue( lCoordinate3.Equals( lCoordinate1 ) );

            Assert.IsFalse( lCoordinate1.Equals( lCoordinate2 ) );
            Assert.IsFalse( lCoordinate2.Equals( lCoordinate1 ) );

            Assert.IsTrue( lCoordinate1.Equals( lCoordinate1 ) );

        }
        #endregion Coordinate

        #region Vector
        [TestMethod()]
        public void FromCoordinate()
        {
            // test de la méthode FromCoordinate dans Vector
            Coordinates lPointA = new Coordinates(),
                        lPointB = new Coordinates( 1,1 );

            Vector lResult = new Vector( 1,1 ),
                   lExpected;
            lExpected = Vector.FromCoordinate( lPointA, lPointB );


            Assert.IsTrue( lExpected.Equals( lResult ) );
        }


        [TestMethod()]
        public void Equals()
        {
            // test de la surcharge de Equals dans Vector
            Vector lVector1 = new Vector(1,2),
                   lVector2 = new Vector(1,3),
                   lVector3 = new Vector(1,2);

            Assert.IsTrue( lVector1.Equals( lVector3 ) );
            Assert.IsTrue( lVector3.Equals( lVector1 ) );

            Assert.IsFalse( lVector1.Equals( lVector2 ) );
            Assert.IsFalse( lVector2.Equals( lVector1 ) );

            Assert.IsTrue( lVector1.Equals( lVector1 ) );
        }

        [TestMethod()]
        public void Lenght()
        {
            // Test de la méthode Lenght dans Vector
            Vector lVector1 = new Vector( 1, 0 ),
                   lVector2 = new Vector( 2, 5 );

            Assert.AreEqual(1, lVector1.Lenght() );
            Assert.AreEqual( Math.Sqrt( 29 ), lVector2.Lenght() ); 
        }
        #endregion

        
    }
}
