using UnityEngine;

using ChickenDayZ.Animations;
using ChickenDayZ.Gameplay.Health;
using ChickenDayZ.Gameplay.MainObjects.Enumerators;

namespace ChickenDayZ.Gameplay.MainObjects.PowerUp 
{
    public class HealthPowerUpObject : PowerUpObject
    {
        [SerializeField] [Range(0f, 1f)] private float _healthIncreasedPercentage;

        [SerializeField] private ObjectHealth _objectHealth;

        private ChestPlayAnimation _chestAnimation;        

        private static short _powerUpLevel;        

        private HealthPowerUpObject() : base(PowerUpObjectTypeEnum.HEALTH) 
        {
            
        }

        void Awake()
        {
            _chestAnimation = GetComponent<ChestPlayAnimation>();            
        }        

        protected override void UsePowerUp()
        {
            if (PowerUpAvailable && !IsChestBlocked)
            {
                if (_powerUpLevel < MaxLevel) 
                {
                    float healthIncreased = _objectHealth.InitialHealth * _healthIncreasedPercentage;

                    _objectHealth.MaxHealth += healthIncreased;

                    _powerUpLevel += 1;

                    PowerUpAvailable = false;

                    IsChestBlocked = true;
                }
                else 
                {
                    _objectHealth.ResetCurrentHealth();

                    PowerUpAvailable = false;

                    IsChestBlocked = true;
                }

                _chestAnimation.SetAnimation("Opened");                
            }
            else 
            {
                _chestAnimation.SetAnimation("Blocked");
            }
        }

        protected override void ResetPowerUpLevel()
        {
            _powerUpLevel = 0;
        }
    }
}