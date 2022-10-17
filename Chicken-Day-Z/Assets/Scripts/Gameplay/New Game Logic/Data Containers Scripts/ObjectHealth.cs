using System;

using ChickenDayZ.Gameplay.MainObjects.Interfaces;

namespace ChickenDayZ.Gameplay.StatsScripts 
{
    public class ObjectHealth : IObjectDamageable, IObjectRessetable
    {
        public event Action OnCurrentHealthChanged;

        public event Action OnMaxHealthChanged;

        public event Action OnHealthReachedZero;

        private float _initialHealth;
        
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

        public ObjectHealth(float initialHealth) 
        {
            _initialHealth = initialHealth;

            GameplayResset();
        }

        public void ObjectReceiveDamage(float value)
        {
            CurrentHealth -= value;

            if (CurrentHealth <= 0f)
            {
                CurrentHealth = 0f;

                OnHealthReachedZero?.Invoke();
            }
        }

        public void GameplayResset() 
        {
            MaxHealth = InitialHealth;

            CurrentHealth = InitialHealth;
        }

        public void RoundResset() 
        {
            ResetCurrentHealth();
        }        

        public void ResetCurrentHealth()
        {
            CurrentHealth = MaxHealth;
        }
    }
}