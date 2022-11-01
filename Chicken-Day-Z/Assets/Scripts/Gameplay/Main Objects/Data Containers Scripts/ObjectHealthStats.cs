using System;

using ChickenDayZ.Gameplay.MainObjects.Interfaces;

namespace ChickenDayZ.Gameplay.StatsScripts 
{
    public class ObjectHealthStats : IObjectDamageable, IObjectRessetable
    {
        public event Action OnCurrentHealthChanged;

        public event Action OnHealthReachedZero;

        private float _gameplayStartingHealth;

        private float _currentHealth;

        public float GameplayStartingHealth
        {
            set
            {
                _gameplayStartingHealth = 0;
            }
            get
            {
                return _gameplayStartingHealth;
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

        public ObjectHealthStats()
        {
            _gameplayStartingHealth = 0;

            _currentHealth = 0;
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
        public void ResetCurrentHealth()
        {
            CurrentHealth = GameplayStartingHealth;
        }

        public void GameplayResset()
        {
            ResetCurrentHealth();
        }

        public void RoundResset() 
        {
                        
        }
    }
}