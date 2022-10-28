using UnityEngine;

using ChickenDayZ.Gameplay.StatsScripts;
using ChickenDayZ.Gameplay.MainObjects.Enumerators;

namespace ChickenDayZ.Gameplay.MainObjects.CombatItem 
{
    public class FirearmObject : CombatItemObject
    {
        [SerializeField] private FirearmObjectTypeEnum _defineFirearmObjectType;

        private FirearmObjectTypeEnum _firearmObjectType;

        private FirearmCharger _firearmCharger;

        private FirearmCanyon _firearmCanyon;

        public FirearmObjectTypeEnum FirearmObjectType 
        {
            get 
            {
                return _firearmObjectType;
            }
        }

        public FirearmCharger FirearmCharger 
        {
            get 
            {
                return _firearmCharger;
            }
        }

        public FirearmCanyon FirearmCanyon 
        {
            get 
            {
                return _firearmCanyon;
            }
        }

        void Awake()
        {
            _firearmObjectType = _defineFirearmObjectType;

            _firearmCharger = new FirearmCharger();

            _firearmCanyon = new FirearmCanyon();
        }

        private FirearmObject() : base(CombatItemObjectTypeEnum.FIREARM)
        {
                                                
        }
    }
}