using UnityEngine;

using ChickenDayZ.Gameplay.MainObjects.Enumerators;

namespace ChickenDayZ.Gameplay.MainObjects.PowerUp 
{
    public class HealthPowerUpObject : PowerUpObject
    {
        [SerializeField] private HealthPowerUpObjectTypeEnum _defineHealthPowerUpObjectTypeEnum;

        public HealthPowerUpObjectTypeEnum _healthPowerUpObjectTypeEnum;

        public HealthPowerUpObjectTypeEnum HealthPowerUpObjectTypeEnum 
        {
            get 
            {
                return _healthPowerUpObjectTypeEnum;
            }
        }

        void Awake()
        {
            _healthPowerUpObjectTypeEnum = _defineHealthPowerUpObjectTypeEnum;
        }

        private HealthPowerUpObject() : base(PowerUpObjectTypeEnum.HEALTH) 
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