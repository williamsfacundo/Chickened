using UnityEngine;

using ChickenDayZ.Gameplay.Interfaces;
using ChickenDayZ.Gameplay.Controllers;

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

        private void Start()
        {
            ResetObject();
        }

        public void ReceiveDamage(float value)
        {
            Health -= value;

            if (Health <= 0f)
            {
                HealthReachedZero();
            }
        }

        public abstract void HealthReachedZero();

        public void ResetObject() 
        {
            _health = _initialHealth;
        }
    }
}