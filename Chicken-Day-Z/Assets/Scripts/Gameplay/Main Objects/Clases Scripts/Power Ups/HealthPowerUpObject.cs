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

        void Start()
        {
            PowerUpLevel = 0;

            ChestInteracted = false;

            _cooldownTimer = new General.Timer(1f);
        }        

        protected override void UsePowerUp() 
        {
            if (PowerUpAvailable) 
            {
                PowerUpLevel += 1;

                float healthIncreased = _objectHealth.InitialHealth * _healthIncreasedPercentage * PowerUpLevel;

                _objectHealth.MaxHealth += healthIncreased;

                PowerUpAvailable = false;                
            }           
        }       
    }
}