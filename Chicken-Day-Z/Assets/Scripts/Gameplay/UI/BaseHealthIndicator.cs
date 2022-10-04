using UnityEngine;
using TMPro;
using ChickenDayZ.Gameplay.EggBase;

namespace ChickenDayZ.UI 
{
    public class BaseHealthIndicator : MonoBehaviour
    {
        [SerializeField] private TMP_Text _showBaseHealthText;

        private EggBaseHealth _baseHealth;
        
        void Awake()
        {
            _baseHealth = FindObjectOfType<EggBaseHealth>();

            _baseHealth.OnHealthChanged += UpdateBaseHealthText;
        }

        void OnDestroy()
        {
            _baseHealth.OnHealthChanged -= UpdateBaseHealthText;
        }

        void Start()
        {
            UpdateBaseHealthText();
        }        

        private void UpdateBaseHealthText()
        {
            _showBaseHealthText.text = "Base Health: " + _baseHealth.Health;
        }
    }
}