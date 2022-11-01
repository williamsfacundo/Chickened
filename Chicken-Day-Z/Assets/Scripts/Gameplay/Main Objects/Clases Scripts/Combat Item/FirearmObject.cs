using UnityEngine;

using ChickenDayZ.Gameplay.MainObjects.Enumerators;

namespace ChickenDayZ.Gameplay.MainObjects.CombatItem 
{
    public class FirearmObject : CombatItemObject
    {
        [SerializeField] private FirearmObjectTypeEnum _defineFirearmObjectType;

        private FirearmObjectTypeEnum _firearmObjectType;       

        public FirearmObjectTypeEnum FirearmObjectType 
        {
            get 
            {
                return _firearmObjectType;
            }
        }        

        void Awake()
        {
            _firearmObjectType = _defineFirearmObjectType;            
        }

        private FirearmObject() : base(CombatItemObjectTypeEnum.FIREARM)
        {
                                                
        }
    }
}