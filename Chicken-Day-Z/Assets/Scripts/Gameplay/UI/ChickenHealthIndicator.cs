using UnityEngine;

using TMPro;
using ChickenDayZ.Gameplay.Health;

namespace ChickenDayZ.UI 
{
    public class ChickenHealthIndicator : MonoBehaviour
    {
        [SerializeField] private ObjectHealth _chickenHealth;

        [SerializeField] private TMP_Text _showChickenHealthText;

        void Awake()
        {
            _chickenHealth.OnCurrentHealthChanged += UpdateBaseHealthText;
        }

        void OnDestroy()
        {
            _chickenHealth.OnCurrentHealthChanged -= UpdateBaseHealthText;
        }

        void Start()
        {
            UpdateBaseHealthText();
        }

        private void UpdateBaseHealthText()
        {
            _showChickenHealthText.text = "Base Health: " + _chickenHealth.CurrentHealth;
        }
    }
}