using System.Collections.Generic;
using BotFactory.Interface;
using BotFactory.Common.Tools;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace BotFactory.Factories
{
    public class UnitFactory : IUnitFactory
    {
        #region Attributes
        readonly int m_QueueCapacity;
        readonly int m_StorageCapacity;

        List<IFactoryQueueElement> m_Queue;
        List<ITestingUnit> m_Storage;


        bool m_IsBuilding = false;
        #endregion

        #region Properties
        public int QueueCapacity
        {
            get
            {
                return m_QueueCapacity;
            }
        }
        public int StorageCapacity
        {
            get
            {
                return m_StorageCapacity;
            }
        }

        public int MyProperty { get; set; }
        public List<IFactoryQueueElement> Queue
        {
            get
            {
                return m_Queue.ToList();
            }
        }

        public List<ITestingUnit> Storage
        {
            get
            {
                return m_Storage.ToList();

            }
        }
        public int QueueFreeSlots
        {
            get
            {
                return m_QueueCapacity - m_Queue.Count;
            }
        }
        public int StorageFreeSlots
        {
            get
            {
                return m_StorageCapacity - m_Storage.Count;
            }
        }
        public TimeSpan QueueTime
        {
            get
            {
                double lTime = 0d;
                // Méthode caca pour récupérer le temps restant dans la liste
                // TODO : trouver une méthode pour acceder à la propriété buildTime (la passer en statique?)
                foreach(IFactoryQueueElement element in Queue)
                {
                    ITestingUnit lUnit = Activator.CreateInstance(element.Model, new string[] { element.Name }) as ITestingUnit;
                    lTime += lUnit.BuildTime;
                }
                return new TimeSpan(0, 0, 0, (int)(lTime), 0);
            }
        }

        
        #endregion

        #region Constructors
        public UnitFactory(int inQueueCapacity, int inStorageCapacity)
        {
            m_QueueCapacity = inQueueCapacity;
            m_StorageCapacity = inStorageCapacity;
            m_Queue = new List<IFactoryQueueElement>();
            m_Storage = new List<ITestingUnit>();
        }

        #endregion

        #region Methods
        /// <summary>
        /// Ajoute un nouvel élément à la liste de commande et relance la production si besoin
        /// </summary>
        /// <param name="inModel">Type de robot à construire</param>
        /// <param name="inUnitName">Nom du robot</param>
        /// <param name="inWorkingPos">Position de travail</param>
        /// <param name="inParkPos">Position de recharge</param>
        /// <returns></returns>
        public bool AddWorkableUnitToQueue(Type inModel, string inUnitName, Coordinates inWorkingPos, Coordinates inParkPos)
        {
            if (m_Queue.Count >= m_QueueCapacity)
            {
                return false;
            }

            // l'ajoute à la liste
            FactoryQueueElement lOrder = new FactoryQueueElement(inUnitName, inModel, inParkPos, inWorkingPos);
            m_Queue.Add(lOrder);

            //On met à jour l'event
            FactoryProgressEventArgs lNewOrder = new FactoryProgressEventArgs();
            lNewOrder.QueueElement = lOrder;
            OnStatusChanged(lNewOrder);

            // lance la construction si ce n'est pas déjà en cours
            if (!m_IsBuilding)
            {
                BuildWorkableUnit();
            }
            return true;
        }

        /// <summary>
        /// Construit les robots qui sont dans la liste de commande
        /// </summary>
        private async void BuildWorkableUnit()
        {
            // Pseudo mutex
            m_IsBuilding = true;
            ITestingUnit lUnit = null;
            // On teste que l'on a pas atteint la capacité max et qu'il reste des éléments dans la Queue

            while (m_Storage.Count <= StorageCapacity && m_Queue.Count > 0)
            {
                lUnit = Activator.CreateInstance(m_Queue[0].Model, new string[] { m_Queue[0].Name }) as ITestingUnit;
                lUnit.WorkingPos = m_Queue[0].WorkingPos;
                lUnit.ParkingPos = m_Queue[0].ParkingPos;
                await Task.Delay((int)(500d * lUnit.BuildTime));
                m_Queue.RemoveAt(0);
                m_Storage.Add(lUnit);

                //On met à jour l'event
                FactoryProgressEventArgs lNewUnit = new FactoryProgressEventArgs();
                lNewUnit.TestingUnit = lUnit;
                OnStatusChanged(lNewUnit);
            }

            // previent que les constructions sont finies
            m_IsBuilding = false;
        }


        public virtual void OnStatusChanged(IFactoryProgressEventArgs inE)
        {
            if (null != FactoryProgress)
            {
                FactoryProgress(this, inE);
            }
        }
        #endregion

        #region Events
        public event EventHandler<IFactoryProgressEventArgs> FactoryProgress;
        #endregion
    }
}
