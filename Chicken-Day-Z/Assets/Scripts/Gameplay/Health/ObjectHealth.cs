using System;
using UnityEngine;

using ChickenDayZ.Gameplay.Interfaces;

namespace ChickenDayZ.Gameplay.Health 
{
    public class ObjectHealth : MonoBehaviour, IDamageable, IResettable
    {
        [SerializeField] [Range(1, 200)] private float _initialHealth;

        public event Action OnCurrentHealthChanged;

        public event Action OnMaxHealthChanged;

        public event Action OnHealthReachedZero;

        private float _maxHealth;

        private float _currentHealth;

        public float InitialHealth 
        {            
            get 
            {
                return _initialHealth;
            }
        }

        public float MaxHealth 
        {
            set 
            {
                _maxHealth = value;

                OnMaxHealthChanged?.Invoke();
            }
            get 
            {
                return _maxHealth;
            }
        }

        public float CurrentHealth
        {
            set 
            {
                _currentHealth = value;

                OnCurrentHealthChanged?.Invoke();
            }
            get
            {
                return _currentHealth;
            }
        }

        void Start()
        {
            ResetObject();            
        }

        public void ReceiveDamage(float value)
        {
            CurrentHealth -= value;

            if (CurrentHealth <= 0f)
            {
                CurrentHealth = 0f;

                OnHealthReachedZero?.Invoke();
            }
        }               

        public void ResetObject() 
        {
            MaxHealth = InitialHealth;

            CurrentHealth = InitialHealth;
        }
        
        public void ResetCurrentHealth() 
        {
            CurrentHealth = MaxHealth;
        }
    }
}