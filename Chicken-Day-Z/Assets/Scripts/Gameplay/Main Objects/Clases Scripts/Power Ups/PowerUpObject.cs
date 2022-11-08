using System;
using UnityEngine;

using ChickenDayZ.Gameplay.Controllers;
using ChickenDayZ.Gameplay.MainObjects.Enumerators;
using ChickenDayZ.General;

namespace ChickenDayZ.Gameplay.MainObjects.PowerUp 
{
    public abstract class PowerUpObject : MainObject
    {
        public event Action OnPowerUpInteracted;

        protected const KeyCode _usePowerUpInput = KeyCode.E;

        private static bool _powerUpAvailable = false;

        private bool _chestInteracted;

        private short _powerUpLevel;

        protected Timer _cooldownTimer;

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

        protected bool ChestInteracted 
        {
            set 
            {
                _chestInteracted = value;

            }
            get 
            {
                return _chestInteracted;
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

        void Update()
        {
            if (_chestInteracted) 
            {
                if (!_cooldownTimer.TimerFinished)
                {
                    _cooldownTimer.DecreaseTimer();
                }
                else
                {
                    _cooldownTimer.ResetTimer();

                    _chestInteracted = false;
                }
            }            
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (!_chestInteracted) 
            {
                if (collision.transform.tag == "Player" && Input.GetKeyDown(_usePowerUpInput))
                {
                    CallOnPowerUpInteracted();

                    UsePowerUp();

                    _chestInteracted = true;
                }
            }
        }

        private void ResetPowerUp() 
        {
            _powerUpLevel = 0;

            _powerUpAvailable = false;
        }

        protected void CallOnPowerUpInteracted() 
        {
            OnPowerUpInteracted?.Invoke();
        }

        protected abstract void UsePowerUp();
    }
}