using UnityEngine;

using ChickenDayZ.Gameplay.MainObjects.Enumerators;

namespace ChickenDayZ.Gameplay.MainObjects.DamageItem
{
    public class ProjectileObject : DamageItemObject
    {
        [SerializeField] private ProjectileObjectTypeEnum _defineProjectileObjectType;

        private ProjectileObjectTypeEnum _projectileObjectType;

        public ProjectileObjectTypeEnum ProjectileObjectType 
        {
            get 
            {
                return _projectileObjectType;
            }
        }

        void Awake()
        {
            _projectileObjectType = _defineProjectileObjectType;            
        }

        private ProjectileObject()
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