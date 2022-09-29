using UnityEngine;

using ChickenDayZ.Gameplay.Interfaces;
using ChickenDayZ.Gameplay.Controllers;
using ChickenDayZ.Gameplay.Enumerators;

namespace ChickenDayZ.Gameplay.Characters.Health 
{
    public abstract class ObjectHealth : MonoBehaviour, IDamageable, IResettable
    {
        [SerializeField] private float _initialHealth;

        private float _health;

        public float Health
        {
            set 
            {
                Health = value;
            }
            get
            {
                return _health;
            }
        }

        private void OnEnable()
        {
            GameplayResetter.OnGameplayReset += ResetObject;
        }

        private void OnDisable()
        {
            GameplayResetter.OnGameplayReset -= ResetObject;
        }

        void Start()
        {
            _health = _initialHealth;
        }

        public void ReceiveDamage(float value)
        {
            _health -= value;

            if (_health <= 0f)
            {
                HealthReachedZero();
            }
        }

        public void ResetObject()
        {
            _health = _initialHealth;
        }

        public abstract void HealthReachedZero();

        public abstract CharacterTypeEnum GetCharacterType();         
    }
}