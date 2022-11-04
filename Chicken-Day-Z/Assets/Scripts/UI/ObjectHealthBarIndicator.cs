using UnityEngine;

using UnityEngine.UI;
using ChickenDayZ.Gameplay.Health;

namespace ChickenDayZ.UI 
{
    public class ObjectHealthBarIndicator : MonoBehaviour
    {
        [SerializeField] private ObjectHealth _objectHealth;

        [SerializeField] private Image _healthBar;

        void Awake()
        {
            _objectHealth.OnCurrentHealthChanged += UpdateHealthBar;
        }

        void OnDestroy()
        {
            _objectHealth.OnCurrentHealthChanged -= UpdateHealthBar;
        }        

        private void UpdateHealthBar()
        {
            _healthBar.fillAmount = _objectHealth.CurrentHealth / _objectHealth.MaxHealth;
        }
    }
}