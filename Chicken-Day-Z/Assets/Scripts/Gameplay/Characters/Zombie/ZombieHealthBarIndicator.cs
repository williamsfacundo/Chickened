using UnityEngine;
using UnityEngine.UI;

using ChickenDayZ.Gameplay.Health;

namespace ChickenDayZ.Gameplay.Characters.Zombie 
{
    public class ZombieHealthBarIndicator : MonoBehaviour
    {
        [SerializeField] private ObjectHealth _objectHealth;

        [SerializeField] private Image _healthBar;

        [SerializeField] private Canvas _canvasForHealthBar;

        private ZombiesMovementIA _zombiesMovementIA;

        void Awake()
        {
            _objectHealth.OnCurrentHealthChanged += UpdateHealthBar;

            _zombiesMovementIA = GetComponent<ZombiesMovementIA>();

            _zombiesMovementIA.OnZombieIsAlive += ShowHealthBar;

            _zombiesMovementIA.OnZombieIsDead += HideHealthBar;
        }

        void OnDestroy()
        {
            _objectHealth.OnCurrentHealthChanged -= UpdateHealthBar;

            _zombiesMovementIA.OnZombieIsAlive -= ShowHealthBar;

            _zombiesMovementIA.OnZombieIsDead -= HideHealthBar;
        }

        private void UpdateHealthBar()
        {
            _healthBar.fillAmount = _objectHealth.CurrentHealth / _objectHealth.MaxHealth;
        }

        private void ShowHealthBar()
        {
            _canvasForHealthBar.gameObject.SetActive(true);
        }

        private void HideHealthBar()
        {
            _canvasForHealthBar.gameObject.SetActive(false);
        }
    }
}