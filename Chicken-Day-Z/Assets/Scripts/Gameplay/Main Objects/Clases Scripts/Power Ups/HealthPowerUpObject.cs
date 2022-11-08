using UnityEngine;

using ChickenDayZ.Gameplay.Health;
using ChickenDayZ.Gameplay.MainObjects.Enumerators;
namespace ChickenDayZ.Gameplay.MainObjects.PowerUp 
{
    public class HealthPowerUpObject : PowerUpObject
    {
        [SerializeField] private HealthPowerUpObjectTypeEnum _defineHealthPowerUpObjectTypeEnum;

        [SerializeField] [Range(0f, 1f)] private float _healthIncreasedPercentage;

        [SerializeField] private ObjectHealth _objectHealth;

        private HealthPowerUpObjectTypeEnum _healthPowerUpObjectTypeEnum;

        public HealthPowerUpObjectTypeEnum HealthPowerUpObjectTypeEnum 
        {
            get 
            {
                return _healthPowerUpObjectTypeEnum;
            }
        }
        private HealthPowerUpObject() : base(PowerUpObjectTypeEnum.HEALTH) 
        {
            
        }

        void Awake()
        {
            _healthPowerUpObjectTypeEnum = _defineHealthPowerUpObjectTypeEnum;
        }                

        protected override void UsePowerUp() 
        {
            if (PowerUpAvailable && !IsChestBlocked) 
            {

                float healthIncreased = _objectHealth.InitialHealth * _healthIncreasedPercentage * PowerUpLevel;

                _objectHealth.MaxHealth += healthIncreased;

                PowerUpLevel += 1;
                
                PowerUpAvailable = false;

                IsChestBlocked = true;                
            }           
        }       
    }
}