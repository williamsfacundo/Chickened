using UnityEngine;

using ChickenDayZ.Gameplay.Controllers;
using ChickenDayZ.Gameplay.MainObjects.Enumerators;

namespace ChickenDayZ.Gameplay.MainObjects.PowerUp 
{
    public abstract class PowerUpObject : MainObject
    {
        protected const KeyCode _usePowerUpInput = KeyCode.E;

        private static bool _powerUpAvailable = false;

        private short _powerUpLevel;

        public static bool PowerUpAvailable 
        {
            set
            {
                _powerUpAvailable = value; 
            }
            get 
            {
                return _powerUpAvailable;
            }
        }

        protected short PowerUpLevel 
        {
            set 
            {
                _powerUpLevel = value;
            }
            get 
            {
                return _powerUpLevel;
            }
        }

        private PowerUpObjectTypeEnum _powerUpObjectType;

        public PowerUpObjectTypeEnum PowerUpObjectType
        {
            get 
            {
                return _powerUpObjectType;
            }
        }

        protected PowerUpObject(PowerUpObjectTypeEnum powerUpObjectType) : base(MainObjectTypeEnum.POWER_UP) 
        {
            _powerUpObjectType = powerUpObjectType;            
        }

        void OnEnable()
        {
            GameplayResetter.OnGameplayReset += ResetPowerUp;
        }

        void OnDisable()
        {
            GameplayResetter.OnGameplayReset -= ResetPowerUp;
        }       

        private void ResetPowerUp() 
        {
            _powerUpLevel = 0;

            _powerUpAvailable = false;
        }

        protected abstract void UsePowerUp();
    }
}