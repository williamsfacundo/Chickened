using System;
using UnityEngine;

using ChickenDayZ.General;
using ChickenDayZ.Gameplay.Controllers;
using ChickenDayZ.Gameplay.MainObjects.Enumerators;

namespace ChickenDayZ.Gameplay.MainObjects.PowerUp 
{
    public abstract class PowerUpObject : MainObject
    {
        [SerializeField] [Range(0.1f, 2f)] private float _interactedCooldownTime;
        
        [SerializeField] [Range(0.1f, 180f)] private float _chestBlockedTime;

        [SerializeField] [Range(1, 20)] private short _maxLevel;        

        public event Action OnBlockedChestTimerChanged;

        protected const KeyCode _usePowerUpInput = KeyCode.E;

        private static bool _powerUpAvailable = false;

        private bool _chestInteracted;

        private bool _isChestBlocked;        

        private Timer _interactedCooldownTimer;

        private Timer _blockedChestTimer;

        public float InteractedCooldownTime 
        {
            get 
            {
                return _interactedCooldownTime;
            }
        }

        public float ChestBlockedTime 
        {
            get 
            {
                return _chestBlockedTime;
            }
        }


        public short MaxLevel 
        {
            get 
            {
                return _maxLevel;
            }
        }

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

        public bool IsChestBlocked 
        {
            set 
            {
                _isChestBlocked = value;

                if (_isChestBlocked == true) 
                {
                    _blockedChestTimer.ResetTimer();

                    OnBlockedChestTimerChanged?.Invoke();
                }
            }
            get           
            {
                return _isChestBlocked;
            }
        }

        protected bool ChestInteracted 
        {
            set 
            {
                _chestInteracted = value;

                if (_chestInteracted == true) 
                {
                    _interactedCooldownTimer.ResetTimer();
                }

            }
            get 
            {
                return _chestInteracted;
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

        void Start()
        {
            _interactedCooldownTimer = new Timer(InteractedCooldownTime);
            
            _blockedChestTimer = new Timer(ChestBlockedTime);

            ResetPowerUp();
        }

        void Update()
        {
            if (ChestInteracted) 
            {
                if (_interactedCooldownTimer.TimerFinished)
                {
                    ChestInteracted = false;
                }
                else
                {
                    _interactedCooldownTimer.DecreaseTimer();
                }
            }

            if (IsChestBlocked) 
            {
                if (_blockedChestTimer.TimerFinished)
                {
                    OnBlockedChestTimerChanged?.Invoke();

                    IsChestBlocked = false;
                }
                else
                {
                    _blockedChestTimer.DecreaseTimer();

                    OnBlockedChestTimerChanged?.Invoke();
                }
            }
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (!ChestInteracted) 
            {
                if (collision.transform.tag == "Player" && Input.GetKeyDown(_usePowerUpInput))
                {
                    UsePowerUp();

                    ChestInteracted = true;
                }
            }
        }

        public float GetBlockedChestTimerCountDown()
        {
            return _blockedChestTimer.CountDown;
        }

        private void ResetPowerUp()
        {
            ResetPowerUpLevel();

            ChestInteracted = false;

            IsChestBlocked = false;

            PowerUpAvailable = false;

            _interactedCooldownTimer.CountDown = 0f;

            _blockedChestTimer.CountDown = 0f;

            OnBlockedChestTimerChanged?.Invoke();
        }        

        protected abstract void UsePowerUp();

        protected abstract void ResetPowerUpLevel();        
    }
}