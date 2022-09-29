using UnityEngine;
using TMPro;
using ChickenDayZ.Gameplay.EggBase;

namespace ChickenDayZ.UI 
{
    public class BaseHealthIndicator : MonoBehaviour
    {
        [SerializeField] private TMP_Text _showBaseHealthText;

        private EggBaseHealth _baseHealth;
        
        private void Start()
        {
            _baseHealth = FindObjectOfType<EggBaseHealth>();
        }

        private void Update()
        {
            UpdateBaseHealthText();
        }

        private void UpdateBaseHealthText()
        {
            _showBaseHealthText.text = "Base Health: " + _baseHealth.Health;
        }
    }
}