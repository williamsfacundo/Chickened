using UnityEngine;

using ChickenDayZ.Gameplay.Health;
using ChickenDayZ.Gameplay.Controllers;
using ChickenDayZ.Gameplay.MainObjects.Enumerators;

namespace ChickenDayZ.Gameplay.MainObjects.Characters
{
    [RequireComponent(typeof(ObjectHealth))]
    public class ChickenObject : CharacterObject
    {
        public PlayerObjectTypeEnum _definePlayersObjectTypeEnum;

        private PlayerObjectTypeEnum _playersObjectTypeEnum;

        private ObjectHealth _objectHealth;
        
        public PlayerObjectTypeEnum PlayersObjectTypeEnum 
        {
            get 
            {
                return _playersObjectTypeEnum;
            }
        }

        void Awake()
        {
            _playersObjectTypeEnum = _definePlayersObjectTypeEnum;

            _objectHealth = GetComponent<ObjectHealth>();
        }

        private void OnEnable()
        {
            _objectHealth.OnHealthReachedZero += GameplayResetter.ResetGameplay;

            GameplayResetter.OnGameplayReset += _objectHealth.ResetCurrentHealth;
        }

        private void OnDisable()
        {
            _objectHealth.OnHealthReachedZero -= GameplayResetter.ResetGameplay;

            GameplayResetter.OnGameplayReset -= _objectHealth.ResetCurrentHealth;
        }

        private ChickenObject() : base(CharacterObjectTypeEnum.CHICKEN)
        {

        }
    }
}