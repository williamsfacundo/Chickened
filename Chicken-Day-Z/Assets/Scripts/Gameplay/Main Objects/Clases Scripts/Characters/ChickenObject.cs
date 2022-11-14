using System;
using UnityEngine;

using ChickenDayZ.Gameplay.Health;
using ChickenDayZ.Gameplay.Controllers;
using ChickenDayZ.Gameplay.MainObjects.Enumerators;
using ChickenDayZ.Gameplay.Characters.Chicken.Score;

namespace ChickenDayZ.Gameplay.MainObjects.Characters
{
    [RequireComponent(typeof(ObjectHealth), typeof(ChickenScore))]
    public class ChickenObject : CharacterObject
    {
        public PlayerObjectTypeEnum _definePlayersObjectTypeEnum;

        private PlayerObjectTypeEnum _playersObjectTypeEnum;

        private ChickenScore _chickenScore;

        private ObjectHealth _objectHealth;

        public static event Action<Transform> OnChickenObject;

        public PlayerObjectTypeEnum PlayersObjectTypeEnum 
        {
            get 
            {
                return _playersObjectTypeEnum;
            }
        }

        public ChickenScore ChickenScore 
        {
            get 
            {
                return _chickenScore;
            }
        }

        void Awake()
        {
            _playersObjectTypeEnum = _definePlayersObjectTypeEnum;

            _objectHealth = GetComponent<ObjectHealth>();

            _chickenScore = GetComponent<ChickenScore>();
        }

        void Start()
        {
            OnChickenObject?.Invoke(transform);
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