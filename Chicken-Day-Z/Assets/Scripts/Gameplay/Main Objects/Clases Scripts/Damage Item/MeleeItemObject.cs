using UnityEngine;

using ChickenDayZ.Gameplay.MainObjects.Enumerators;

namespace ChickenDayZ.Gameplay.MainObjects.DamageItem
{
    public class MeleeItemObject : DamageItemObject
    {
        [SerializeField] private MeleeItemObjectTypeEnum _defineMeleeItemObjectType;

        private MeleeItemObjectTypeEnum _meleeItemObjectType;

        public MeleeItemObjectTypeEnum MeleeItemObjectType 
        {
            get 
            {
                return _meleeItemObjectType;
            }
        }

        void Awake()
        {
            _meleeItemObjectType = _defineMeleeItemObjectType;
        }

        private MeleeItemObject()
        {

        } 

        public override void GameplayResset()
        {

        }

        public override void RoundResset()
        {

        }        
    }
}