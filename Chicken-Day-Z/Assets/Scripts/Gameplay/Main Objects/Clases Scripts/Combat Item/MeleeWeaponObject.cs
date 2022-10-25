using UnityEngine;

using ChickenDayZ.Gameplay.MainObjects.Enumerators;

namespace ChickenDayZ.Gameplay.MainObjects.CombatItem 
{
    public class MeleeWeaponObject : CombatItemObject
    {
        [SerializeField] private MeleeWeaponItemObjectTypeEnum _defineMeleeWeaponItemObjectType;

        private MeleeWeaponItemObjectTypeEnum _meleeWeaponItemObjectType;

        public MeleeWeaponItemObjectTypeEnum MeleeWeaponItemObjectType 
        {
            get 
            {
                return _meleeWeaponItemObjectType;
            }
        }

        void Awake()
        {
            _meleeWeaponItemObjectType = _defineMeleeWeaponItemObjectType;
        }

        private MeleeWeaponObject() : base(CombatItemObjectTypeEnum.MELEE_WEAPON)
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